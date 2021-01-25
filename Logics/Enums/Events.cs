using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.AdditionalAttributes;

namespace Logics.Enums
{
    public static class Events
    {
        static public class DatabaseLogCreatorEvents
        {
            public enum ProgressNotices : int
            {
                [StringValue("Подключение к серверу {{ ServerName }}")]
                ConnectToServerStart = 1,
                [StringValue("Завершено подключение к серверу {{ ServerName }}")]
                ConnectToServerEnd = 2,
                [StringValue("Отключение от сервера {{ ServerName }}")]
                DisconnectFromServerStart = 3,
                [StringValue("Завершено отключение от сервера {{ ServerName }}")]
                DisconnectFromServerEnd = 4,
                [StringValue("Получение списка баз данных на сервере {{ ServerName }}")]
                GetDatabaseNameListStart = 5,
                [StringValue("Завершено завершено получение списка баз данных на сервере {{ ServerName }}")]
                GetDatabaseNameListEnd = 6,
                [StringValue("Подключение к базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                ConnectionToDatabaseStart = 7,
                [StringValue("Завершено подключение к базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                ConnectionToDatabaseEnd = 8,
                [StringValue("Отключение от базы данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DisconnectFromDatabaseStart = 9,
                [StringValue("Завершено отключение от базы данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DisconnectFromDatabaseEnd = 10,
                [StringValue("Получение списка таблиц в базы данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GetTableNameListStart = 11,
                [StringValue("Завершено получение списка таблиц в базы данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GetTableNameListEnd = 12,
                [StringValue("Генерация триггеров для логирования изменений в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GenerateLogTriggersStart = 13,
                [StringValue("Завершена генерация триггеров для логирования изменений в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GenerateLogTriggersEnd = 14,
                [StringValue("Генерация триггера {{ TriggerName }} для таблицы {{ TableName }} в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GenerateLogTriggerStart = 15,
                [StringValue("Завершена генерация триггера {{ TriggerName }} для таблицы {{ TableName }} в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GenerateLogTriggerEnd = 16,
                [StringValue("Удаление триггеров для логирования изменений в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DeleteLogTriggersStart = 17,
                [StringValue("Завершено удаление триггеров для логирования изменений в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DeleteLogTriggersEnd = 18,
                [StringValue("Удаление триггера {{ TriggerName }} для таблицы {{ TableName }} в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DeleteLogTriggerStart = 19,
                [StringValue("Завершено удаление триггера {{ TriggerName }} для таблицы {{ TableName }} в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DeleteLogTriggerEnd = 20
            }
        }
    }
}
