using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.AdditionalAttributes;

namespace Logics.Enums
{
    /// <summary>
    /// События
    /// </summary>
    public static class Events
    {
        /// <summary>
        /// События для класса "DatabaseLogCreator"
        /// </summary>
        static public class DatabaseLogCreatorEvents
        {
            /// <summary>
            /// Уведомления о прогрессе выполнения
            /// </summary>
            public enum ProgressNotices : int
            {
                /// <summary>
                /// Подключение к серверу
                /// </summary>
                [StringValue("Подключение к серверу {{ ServerName }}")]
                ConnectToServerStart = 1,
                /// <summary>
                /// Завершено подключение к серверу
                /// </summary>
                [StringValue("Завершено подключение к серверу {{ ServerName }}")]
                ConnectToServerEnd = 2,
                /// <summary>
                /// Отключение от сервера
                /// </summary>
                [StringValue("Отключение от сервера {{ ServerName }}")]
                DisconnectFromServerStart = 3,
                /// <summary>
                /// Завершено отключение от сервера
                /// </summary>
                [StringValue("Завершено отключение от сервера {{ ServerName }}")]
                DisconnectFromServerEnd = 4,
                /// <summary>
                /// Получение списка баз данных на сервере
                /// </summary>
                [StringValue("Получение списка баз данных на сервере {{ ServerName }}")]
                GetDatabaseNameListStart = 5,
                /// <summary>
                /// Завершено получение списка баз данных на сервере
                /// </summary>
                [StringValue("Завершено получение списка баз данных на сервере {{ ServerName }}")]
                GetDatabaseNameListEnd = 6,
                /// <summary>
                /// Подключение к базе данных на сервере
                /// </summary>
                [StringValue("Подключение к базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                ConnectionToDatabaseStart = 7,
                /// <summary>
                /// Завершено подключение к базе данных на сервере
                /// </summary>
                [StringValue("Завершено подключение к базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                ConnectionToDatabaseEnd = 8,
                /// <summary>
                /// Отключение от базы данных на сервере
                /// </summary>
                [StringValue("Отключение от базы данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DisconnectFromDatabaseStart = 9,
                /// <summary>
                /// Завершено отключение от базы данных на сервере
                /// </summary>
                [StringValue("Завершено отключение от базы данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DisconnectFromDatabaseEnd = 10,
                /// <summary>
                /// Получение списка таблиц в базы данных на сервере
                /// </summary>
                [StringValue("Получение списка таблиц в базы данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GetTableNameListStart = 11,
                /// <summary>
                /// Завершено получение списка таблиц в базы данных на сервере
                /// </summary>
                [StringValue("Завершено получение списка таблиц в базы данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GetTableNameListEnd = 12,
                /// <summary>
                /// Генерация триггеров для логирования изменений в базе данных на сервере
                /// </summary>
                [StringValue("Генерация триггеров для логирования изменений в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GenerateLogTriggersStart = 13,
                /// <summary>
                /// Завершена генерация триггеров для логирования изменений в базе данных на сервере
                /// </summary>
                [StringValue("Завершена генерация триггеров для логирования изменений в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GenerateLogTriggersEnd = 14,
                /// <summary>
                /// Генерация триггера для таблицы в базе данных на сервере
                /// </summary>
                [StringValue("Генерация триггера {{ TriggerName }} для таблицы {{ TableName }} в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GenerateLogTriggerStart = 15,
                /// <summary>
                /// Завершена генерация триггера для таблицы в базе данных на сервере
                /// </summary>
                [StringValue("Завершена генерация триггера {{ TriggerName }} для таблицы {{ TableName }} в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                GenerateLogTriggerEnd = 16,
                /// <summary>
                /// Удаление триггеров для логирования изменений в базе данных на сервере
                /// </summary>
                [StringValue("Удаление триггеров для логирования изменений в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DeleteLogTriggersStart = 17,
                /// <summary>
                /// Завершено удаление триггеров для логирования изменений в базе данных на сервере
                /// </summary>
                [StringValue("Завершено удаление триггеров для логирования изменений в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DeleteLogTriggersEnd = 18,
                /// <summary>
                /// Удаление триггера для таблицы в базе данных на сервере
                /// </summary>
                [StringValue("Удаление триггера {{ TriggerName }} для таблицы {{ TableName }} в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DeleteLogTriggerStart = 19,
                /// <summary>
                /// Завершено удаление триггера для таблицы в базе данных на сервере
                /// </summary>
                [StringValue("Завершено удаление триггера {{ TriggerName }} для таблицы {{ TableName }} в базе данных {{ DatabaseName }} на сервере {{ ServerName }}")]
                DeleteLogTriggerEnd = 20
            }
        }
    }
}
