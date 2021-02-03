using Dapper;
using Logics.Interfaces;
using Logics.Models;
using Scriban;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using static Logics.Enums.Errors;
using static Logics.Enums.Events.DatabaseLogCreatorEvents;
using static Logics.Enums.Types;
using static Logics.Models.CustomEventArgs.DatabaseLogCreatorArgs;

namespace Logics
{
    /// <summary>
    /// Настройка логирования изменений в таблицах базы данных в СУБД MS SQL
    /// </summary>
    public class MsSqlDatabaseLogCreator : IDatabaseLogCreator, IDisposable
    {
        private ProgressNoticesHandler _progressNotify;
        /// <summary>
        /// Уведомления о прогрессе выполнения
        /// </summary>
        public event ProgressNoticesHandler ProgressNotify
        {
            add
            {
                if (this._progressNotify == null || this._progressNotify.GetInvocationList().Contains(value) == false)
                {
                    this._progressNotify += value;
                }
            }
            remove
            {
                this._progressNotify -= value;
            }
        }

        #region Запросы

        private readonly string _queryDatabaseList = @"SELECT database_id ID, 
    name Name 
FROM sys.databases 
WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb') 
    AND state = 0 
ORDER BY name";

        private readonly string _queryUseDatabase = @"USE {0}";

        private readonly string _queryTableList = @"SELECT object_id ID, 
    name  Name
FROM sys.all_objects 
WHERE type = 'U' 
ORDER BY name";

        private readonly string _queryCreateLogTableScript = @"IF OBJECT_ID('{{ LogTableSettings.LogTableName }}') IS NULL
BEGIN
	CREATE TABLE [{{ LogTableSettings.LogTableName }}] (
		[{{ LogTableSettings.EventTypeColumnName }}] CHAR(1) NOT NULL,
		[{{ LogTableSettings.TableNameColumnName }}] VARCHAR(128) NOT NULL,
		[{{ LogTableSettings.EventDateColumnName }}] DATETIME NOT NULL DEFAULT (GETDATE()),
		[{{ LogTableSettings.UserNameColumnName }}] VARCHAR(128) NOT NULL DEFAULT (SUSER_SNAME()),
		[{{ LogTableSettings.PrimaryKeyColumnName }}] BIGINT NULL,
		[{{ LogTableSettings.RowDataColumnName }}] TEXT NULL
	)

	ALTER TABLE [{{ LogTableSettings.LogTableName }}] WITH CHECK ADD CHECK ([{{ LogTableSettings.EventTypeColumnName }}] = 'E' OR [{{ LogTableSettings.EventTypeColumnName }}] = 'D' OR [{{ LogTableSettings.EventTypeColumnName }}] = 'U' OR [{{ LogTableSettings.EventTypeColumnName }}] = 'I')
END";

        private readonly string _queryCreateLogTrigger = @"CREATE TRIGGER [{{ LogTriggerVariables.TriggerName }}]
ON [{{ LogTriggerVariables.TableName }}]
AFTER DELETE, INSERT, UPDATE
AS
BEGIN
    --UPDATE
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
        INSERT INTO [{{ LogTableSettings.LogTableName }}] ([{{ LogTableSettings.EventTypeColumnName }}], [{{ LogTableSettings.TableNameColumnName }}], [{{ LogTableSettings.PrimaryKeyColumnName }}], [{{ LogTableSettings.RowDataColumnName }}])
		SELECT 'U', '{{ LogTriggerVariables.TableName }}', inserted.[{{ LogTriggerVariables.PrimaryKeyColumnName }}]{{ if LogTriggerSettings.RowDataDisable == false }}, {{ LogTriggerVariables.RowDataQuery }}{{ else }}, NULL{{ end }} 
        FROM inserted

    --INSERT
    ELSE IF EXISTS (SELECT 1 FROM inserted)
        INSERT INTO [{{ LogTableSettings.LogTableName }}] ([{{ LogTableSettings.EventTypeColumnName }}], [{{ LogTableSettings.TableNameColumnName }}], [{{ LogTableSettings.PrimaryKeyColumnName }}], [{{ LogTableSettings.RowDataColumnName }}])
		SELECT 'I', '{{ LogTriggerVariables.TableName }}', inserted.[{{ LogTriggerVariables.PrimaryKeyColumnName }}]{{ if LogTriggerSettings.RowDataDisable == false }}, {{ LogTriggerVariables.RowDataQuery }}{{ else }}, NULL{{ end }} 
        FROM inserted

    --DELETE
    ELSE IF EXISTS (SELECT 1 FROM deleted)
		INSERT INTO [{{ LogTableSettings.LogTableName }}] ([{{ LogTableSettings.EventTypeColumnName }}], [{{ LogTableSettings.TableNameColumnName }}], [{{ LogTableSettings.PrimaryKeyColumnName }}], [{{ LogTableSettings.RowDataColumnName }}])
		SELECT 'D', '{{ LogTriggerVariables.TableName }}', deleted.[{{ LogTriggerVariables.PrimaryKeyColumnName }}]{{ if LogTriggerSettings.RowDataDisable == false }}, {{ LogTriggerVariables.RowDataQuery }}{{ else }}, NULL{{ end }} 
        FROM deleted
END";

        private readonly string _queryDeleteLogTrigger = @"IF OBJECT_ID ('{{ TriggerName }}', 'TR') IS NOT NULL  
DROP TRIGGER {{ TriggerName }}";

        private readonly string _queryTriggerList = @"SELECT so.id ID, 
    so.name Name, 
	USER_NAME(so.uid) OwnerName, 
	s.name SchemaName, 
	OBJECT_NAME(parent_obj) TableName, 
	OBJECTPROPERTY(so.id, 'ExecIsUpdateTrigger') IsUpdate, 
    OBJECTPROPERTY(so.id, 'ExecIsDeleteTrigger') IsDelete, 
    OBJECTPROPERTY(so.id, 'ExecIsInsertTrigger') IsInsert, 
    OBJECTPROPERTY(so.id, 'ExecIsAfterTrigger') IsAfter, 
    OBJECTPROPERTY(so.id, 'ExecIsInsteadOfTrigger') IsInsteadOf, 
    OBJECTPROPERTY(so.id, 'ExecIsTriggerDisabled') IsDisabled 
FROM sysobjects so
	INNER JOIN sys.tables t 
		ON so.parent_obj = t.object_id 

	INNER JOIN sys.schemas s 
		ON t.schema_id = s.schema_id 
WHERE so.type = 'TR'
	AND (
        @TriggerName IS NULL
        OR so.name LIKE @TriggerName
    )";

        private readonly string _queryTableColumnList = @"SELECT DISTINCT tc.column_id ID, 
    tc.name Name,
	ct.name TypeName,
	COALESCE(tcp.is_primary_key, 0) IsIdentity
FROM sys.schemas s 
    INNER JOIN sys.tables t 
		ON s.schema_id = t.schema_id

    INNER JOIN sys.columns tc 
		ON t.object_id = tc.object_id

	INNER JOIN sys.types ct
		ON tc.system_type_id = ct.system_type_id

	LEFT OUTER JOIN (
		SELECT i.object_id, tc.column_id, i.is_primary_key
		FROM sys.indexes i 
			INNER JOIN sys.index_columns ic 
				ON i.object_id = ic.object_id 
					AND i.index_id = ic.index_id

			INNER JOIN sys.columns tc 
				ON ic.object_id = tc.object_id 
					AND ic.column_id = tc.column_id
		WHERE i.is_primary_key = 1
	) tcp 
		ON t.object_id = tcp.object_id
			AND tc.column_id = tcp.column_id
WHERE t.name = @TableName";

        private readonly string _patternGetDataFromColumn = "'{{ Name }}' + '=' + ISNULL(CAST([{{ Name }}] AS NVARCHAR), '') + ';'";

        #endregion Запросы

        /// <summary>
        /// Наименование сервера
        /// </summary>
        public string ServerName { get; private set; }
        /// <summary>
        /// Имя для подключения
        /// </summary>
        public string LoginName { get; private set; }
        /// <summary>
        /// Пароль для подключения
        /// </summary>
        public string LoginPassword { get; private set; }
        /// <summary>
        /// Используется Windows аутентификация
        /// </summary>
        public bool IsWindowsAuthentication { get; private set; }
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public string ConnectionString { get; private set; }
        /// <summary>
        /// Наименование базы данных
        /// </summary>
        public string DatabaseName { get; private set; }
        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        private IDbConnection Connection { get; set; }
        /// <summary>
        /// Настройки таблицы с логами
        /// </summary>
        public LogTableSettings LogTableSettings { get; set; }
        /// <summary>
        /// Настройки триггера для логирования
        /// </summary>
        public LogTriggerSettings LogTriggerSettings { get; set; }
        /// <summary>
        /// Заменять существующий триггер
        /// </summary>
        public bool ReplaceExistTrigger { get; set; }

        /// <summary>
        /// Является пустой строка подключения к базе данных
        /// </summary>
        public bool IsEmptyConnectionString
        {
            get
            {
                return string.IsNullOrEmpty(this.ServerName) || string.IsNullOrEmpty(this.ConnectionString);
            }
        }
        /// <summary>
        /// Является пустым наименование базы данных
        /// </summary>
        public bool IsEmptyDatabaseName
        {
            get
            {
                return string.IsNullOrEmpty(this.DatabaseName);
            }
        }
        /// <summary>
        /// Является пустым подключение к базе данных
        /// </summary>
        public bool IsEmptyConnection
        {
            get
            {
                return this.Connection == null;
            }
        }
        /// <summary>
        /// Является пустым подключение к выбранной базе данных
        /// </summary>
        public bool IsEmptyConnectionToDatabase
        {
            get
            {
                return this.IsEmptyConnection == true || this.IsEmptyDatabaseName == true;
            }
        }

        public MsSqlDatabaseLogCreator()
        {
            this.LogTableSettings = new LogTableSettings
            {
                LogTableName = "AuditData",
                EventTypeColumnName = "EventType",
                TableNameColumnName = "TableName",
                EventDateColumnName = "EventDate",
                UserNameColumnName = "UserName",
                PrimaryKeyColumnName = "PrimaryKey",
                RowDataColumnName = "RowData"
            };

            this.LogTriggerSettings = new LogTriggerSettings
            {
                PrefixType = PrefixTypes.Text,
                PrefixText = "Audit",
                PrefixRandomNumberCount = null,
                PostfixType = PostfixTypes.RandomNumber,
                PostfixRandomNumberCount = 5,
                PostfixText = string.Empty,
                RowDataDisable = false,
                IgnoreColumnNames = new List<string>() { },
                IgnoreDataTypeNames = new List<string>() {
                    "text",
                    "ntext",
                    "image",
                    "binary",
                    "varbinary"
                }
            };
        }

        /// <summary>
        /// Подключиться к серверу базы данных
        /// </summary>
        /// <param name="serverName">Наименование сервера</param>
        /// <param name="loginName">Имя для подключения</param>
        /// <param name="loginPassword">Пароль для подключения</param>
        /// <param name="isWindowsAuthentication">Используется Windows аутентификация</param>
        public void ConnectToServer(string serverName, string loginName, string loginPassword, bool isWindowsAuthentication)
        {
            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.ConnectToServerStart, serverName, null, null, null));

            this.ServerName = serverName;
            this.LoginName = loginName;
            this.LoginPassword = loginPassword;
            this.IsWindowsAuthentication = isWindowsAuthentication;

            this.ConnectionString = "Persist Security Info=false;Data Source=" + this.ServerName + ";";

            if (this.IsWindowsAuthentication)
            {
                this.ConnectionString += "Integrated Security=SSPI;";
            }
            else
            {
                this.ConnectionString += "User ID=" + this.LoginName + ";Password=" + this.LoginPassword + ";";
            }

            if (this.IsEmptyConnectionString)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionString.GetStringValue());
            }

            this.Connection = new SqlConnection(this.ConnectionString);

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.ConnectToServerEnd, this.ServerName));
        }

        /// <summary>
        /// Отключиться от сервера базы данных
        /// </summary>
        public void DisconnectFromServer()
        {
            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DisconnectFromServerStart, this.ServerName));

            this.Connection.Dispose();

            this.Connection = null;

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DisconnectFromServerEnd, this.ServerName));
        }

        /// <summary>
        /// Получить наименования баз данных
        /// </summary>
        /// <returns>Список наименований баз данных</returns>
        public async Task<List<Database>> GetDatabaseNameListAsync()
        {
            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GetDatabaseNameListStart, this.ServerName));

            if (this.IsEmptyConnection)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnection.GetStringValue());
            }

            List<Database> result = new List<Database>();

            var databaseList = await this.Connection.QueryAsync<Database>(this._queryDatabaseList);

            result.AddRange(databaseList.ToList());

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GetDatabaseNameListEnd, this.ServerName));

            return result;
        }

        /// <summary>
        /// Получить наименования баз данных
        /// </summary>
        /// <returns>Список наименований баз данных</returns>
        public List<Database> GetDatabaseNameList()
        {
            return this.GetDatabaseNameListAsync().Result;
        }

        /// <summary>
        /// Подключиться к базе данных
        /// </summary>
        /// <param name="databaseName">Наименование базы данных</param>
        public async Task ConnectionToDatabaseAsync(string databaseName)
        {
            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DisconnectFromServerStart, this.ServerName, databaseName));

            this.DatabaseName = databaseName;

            if (this.IsEmptyConnection)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnection.GetStringValue());
            }

            if (this.IsEmptyDatabaseName)
            {
                throw new Exception(DatabaseLogCreatorError.MissingDatabaseName.GetStringValue());
            }

            await this.Connection.ExecuteAsync(string.Format(this._queryUseDatabase, this.DatabaseName));

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DisconnectFromServerEnd, this.ServerName, this.DatabaseName));
        }

        /// <summary>
        /// Подключиться к базе данных
        /// </summary>
        /// <param name="databaseName">Наименование базы данных</param>
        public void ConnectionToDatabase(string databaseName)
        {
            this.ConnectionToDatabaseAsync(databaseName).Wait();
        }

        /// <summary>
        /// Отключиться от базы данных
        /// </summary>
        public void DisconnectFromDatabase()
        {
            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DisconnectFromDatabaseStart, this.ServerName, this.DatabaseName));

            this.DatabaseName = string.Empty;

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DisconnectFromDatabaseEnd, this.ServerName, this.DatabaseName));
        }

        /// <summary>
        /// Получить наименования таблиц
        /// </summary>
        /// <returns>Список наименований таблиц</returns>
        public async Task<List<Table>> GetTableNameListAsync()
        {
            List<Table> result = new List<Table>();

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GetTableNameListStart, this.ServerName, this.DatabaseName));

            if (this.IsEmptyConnectionToDatabase)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionToDatabase.GetStringValue());
            }

            var tableList = await this.Connection.QueryAsync<Table>(this._queryTableList);

            result.AddRange(tableList.ToList());

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GetTableNameListEnd, this.ServerName, this.DatabaseName));

            return result;
        }

        /// <summary>
        /// Получить наименования таблиц
        /// </summary>
        /// <returns>Список наименований таблиц</returns>
        public List<Table> GetTableNameList()
        {
            return this.GetTableNameListAsync().Result;
        }

        /// <summary>
        /// Генерировать триггеры для логирования
        /// </summary>
        /// <param name="tableNameList">Список наименований таблиц</param>
        public async Task GenerateLogTriggersAsync(List<string> tableNameList)
        {
            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GenerateLogTriggersStart, this.ServerName, this.DatabaseName));

            if (tableNameList.Count == 0)
            {
                throw new Exception(DatabaseLogCreatorError.TableNameListForLogIsEmpty.GetStringValue());
            }

            if (this.IsEmptyConnectionToDatabase)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionToDatabase.GetStringValue());
            }

            await this.CreateLogTable(this.LogTableSettings);

            foreach (string tableName in tableNameList)
            {
                var triggerNameGenerator = new TriggerNameGenerator(tableName, this.LogTriggerSettings);

                var triggerExistsList = await this.GetTriggerList(triggerNameGenerator.NameSearchPattern);

                if (tableName.ToUpper().Equals(this.LogTableSettings.LogTableName.ToUpper()))
                {
                    continue;
                }

                if (this.ReplaceExistTrigger == false && triggerExistsList.Count > 0)
                {
                    continue;
                }

                if (this.ReplaceExistTrigger && triggerExistsList.Count > 0)
                {
                    if (triggerExistsList.Count > 1)
                    {
                        throw new Exception(DatabaseLogCreatorError.TriggerAmbiguous.GetStringValue().Format(new { TableName = tableName, TriggerNameList = string.Join(", ", triggerExistsList.Select(s => s.Name).ToArray()) }));
                    }

                    var triggerExistsName = triggerExistsList.FirstOrDefault()?.Name;

                    await this.DeleteLogTrigger(triggerExistsName);
                }

                var triggerName = triggerNameGenerator.Name;

                this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GenerateLogTriggerStart, this.ServerName, this.DatabaseName, tableName, triggerName));

                var tableColumnList = await this.GetTableColumnList(tableName);

                var getDataFromColumnTemplate = Template.Parse(_patternGetDataFromColumn);

                var columnInfo = tableColumnList
                    .Where(w => this.LogTriggerSettings.IgnoreColumnNames.Contains(w.Name) == false && this.LogTriggerSettings.IgnoreDataTypeNames.Contains(w.TypeName) == false)
                    .Select(s => getDataFromColumnTemplate.Render(new { Name = s.Name }, member => member.Name));

                await this.CreateLogTrigger(this.LogTableSettings,
                    this.LogTriggerSettings,
                    new LogTriggerVariables
                    {
                        TriggerName = triggerName,
                        TableName = tableName,
                        LogTableName = this.LogTableSettings.LogTableName,
                        PrimaryKeyColumnName = tableColumnList.FirstOrDefault(f => f.IsIdentity == true)?.Name,
                        RowDataQuery = string.Join(" + ", columnInfo.Distinct().ToArray())
                    }
                );

                this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GenerateLogTriggerEnd, this.ServerName, this.DatabaseName, tableName, triggerName));
            }

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GenerateLogTriggersEnd, this.ServerName, this.DatabaseName));
        }

        /// <summary>
        /// Генерировать триггеры для логирования
        /// </summary>
        /// <param name="tableNameList">Список наименований таблиц</param>
        public void GenerateLogTriggers(List<string> tableNameList)
        {
            this.GenerateLogTriggersAsync(tableNameList).Wait();
        }

        /// <summary>
        /// Удалить триггеры для логирования
        /// </summary>
        /// <param name="tableNameList">Список наименований таблиц</param>
        public async Task DeleteLogTriggersAsync(List<string> tableNameList)
        {
            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DeleteLogTriggersStart, this.ServerName, this.DatabaseName));

            if (tableNameList.Count == 0)
            {
                throw new Exception(DatabaseLogCreatorError.TableNameListForLogIsEmpty.GetStringValue());
            }

            if (this.IsEmptyConnectionToDatabase)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionToDatabase.GetStringValue());
            }

            foreach (string tableName in tableNameList)
            {
                var triggerNameGenerator = new TriggerNameGenerator(tableName, this.LogTriggerSettings);

                var triggerExistsList = await this.GetTriggerList(triggerNameGenerator.NameSearchPattern);

                if (triggerExistsList.Count == 0)
                {
                    continue;
                }

                if (triggerExistsList.Count > 1)
                {
                    throw new Exception(DatabaseLogCreatorError.TriggerAmbiguous.GetStringValue().Format(new { TableName = tableName, TriggerNameList = string.Join(", ", triggerExistsList.Select(s => s.Name).ToArray()) }));
                }

                var triggerExistsName = triggerExistsList.FirstOrDefault()?.Name;

                this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DeleteLogTriggerStart, this.ServerName, this.DatabaseName, tableName, triggerExistsName));

                await this.DeleteLogTrigger(triggerExistsName);

                this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.GenerateLogTriggerEnd, this.ServerName, this.DatabaseName, tableName, triggerExistsName));
            }

            this._progressNotify?.Invoke(this, new ProgressNoticesEventArgs(ProgressNotices.DeleteLogTriggerEnd, this.ServerName, this.DatabaseName));
        }

        /// <summary>
        /// Удалить триггеры для логирования
        /// </summary>
        /// <param name="tableNameList">Список наименований таблиц</param>
        public void DeleteLogTriggers(List<string> tableNameList)
        {
            this.DeleteLogTriggersAsync(tableNameList).Wait();
        }

        /// <summary>
        /// Создать таблицу с логами
        /// </summary>
        /// <param name="logTableSettings">Настройки таблицы с логами</param>
        private async Task CreateLogTable(LogTableSettings logTableSettings)
        {
            if (this.LogTableSettings.IsValid == false)
            {
                throw new Exception(DatabaseLogCreatorError.LogTableSettingsIncorrect.GetStringValue());
            }

            if (this.IsEmptyConnectionToDatabase)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionToDatabase.GetStringValue());
            }

            var createLogTableTemplate = Template.Parse(this._queryCreateLogTableScript);
            var createLogTableString = createLogTableTemplate.Render(new { LogTableSettings = logTableSettings }, member => member.Name);

            await this.Connection.ExecuteAsync(createLogTableString);
        }

        /// <summary>
        /// Получить список триггеров
        /// </summary>
        /// <param name="triggerName">Наименование триггера</param>
        /// <returns>Список триггеров</returns>
        private async Task<List<Trigger>> GetTriggerList(string triggerName = null)
        {
            List<Trigger> result = new List<Trigger>() { };

            if (this.IsEmptyConnectionToDatabase)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionToDatabase.GetStringValue());
            }

            var triggerList = await this.Connection.QueryAsync<Trigger>(this._queryTriggerList, new { TriggerName = triggerName });

            result.AddRange(triggerList);

            return result;
        }

        /// <summary>
        /// Получить список столбцов таблицы
        /// </summary>
        /// <param name="tableName">Наименование таблицы</param>
        /// <returns>Список столбцов</returns>
        private async Task<List<Column>> GetTableColumnList(string tableName)
        {
            List<Column> result = new List<Column>() { };

            if (this.IsEmptyConnectionToDatabase)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionToDatabase.GetStringValue());
            }

            var tableColumnList = await this.Connection.QueryAsync<Column>(this._queryTableColumnList, new { TableName = tableName });

            result.AddRange(tableColumnList);

            return result;
        }

        /// <summary>
        /// Создать триггер для логирования
        /// </summary>
        /// <param name="logTableSettings">Настройки таблицы с логами</param>
        /// <param name="logTriggerSettings">Настройки триггера для логирования</param>
        /// <param name="logTriggerVariables">Переменные триггера для логирования</param>
        private async Task CreateLogTrigger(LogTableSettings logTableSettings, LogTriggerSettings logTriggerSettings, LogTriggerVariables logTriggerVariables)
        {
            if (logTableSettings.IsValid == false)
            {
                throw new Exception(DatabaseLogCreatorError.LogTableSettingsIncorrect.GetStringValue());
            }

            if (logTriggerSettings.IsValid == false)
            {
                throw new Exception(DatabaseLogCreatorError.LogTriggerSettingsIncorrect.GetStringValue());
            }

            if (logTriggerVariables.IsValid == false)
            {
                throw new Exception(DatabaseLogCreatorError.LogTriggerVariablesIncorrect.GetStringValue());
            }

            if (this.IsEmptyConnectionToDatabase)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionToDatabase.GetStringValue());
            }

            var createLogTriggerTemplate = Template.Parse(this._queryCreateLogTrigger);
            var createLogTriggerString = createLogTriggerTemplate.Render(new { LogTableSettings = logTableSettings, LogTriggerSettings = logTriggerSettings, LogTriggerVariables = logTriggerVariables }, member => member.Name);

            await this.Connection.ExecuteAsync(createLogTriggerString);
        }

        /// <summary>
        /// Удалить триггер для логирования
        /// </summary>
        /// <param name="triggerName">Наименование триггера</param>
        private async Task DeleteLogTrigger(string triggerName)
        {
            if (this.IsEmptyConnectionToDatabase)
            {
                throw new Exception(DatabaseLogCreatorError.MissingConnectionToDatabase.GetStringValue());
            }

            var deleteLogTriggerTemplate = Template.Parse(this._queryDeleteLogTrigger);
            var deleteLogTriggerString = deleteLogTriggerTemplate.Render(new { TriggerName = triggerName }, member => member.Name);

            await this.Connection.ExecuteAsync(deleteLogTriggerString);
        }

        #region IDisposable Support

        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    try
                    {
                        this.DisconnectFromServer();
                    }
                    catch
                    {
                    }
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}
