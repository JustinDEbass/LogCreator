using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using static Logics.Enums.Events;

namespace Logics.Models
{
    /// <summary>
    /// Аргументы пользовательских событий
    /// </summary>
    public static class CustomEventArgs
    {
        /// <summary>
        /// Аргументы пользовательских событий для класса "DatabaseLogCreator"
        /// </summary>
        static public class DatabaseLogCreatorArgs
        {
            /// <summary>
            /// Аргументы событий уведомляющие о прогрессе выполнения
            /// </summary>
            public class ProgressNoticesEventArgs
            {
                /// <summary>
                /// Наименование сервера
                /// </summary>
                public string ServerName { get; private set; }
                /// <summary>
                /// Наименование базы данных
                /// </summary>
                public string DatabaseName { get; private set; }
                /// <summary>
                /// Наименование таблицы
                /// </summary>
                public string TableName { get; private set; }
                /// <summary>
                /// Наименование триггера
                /// </summary>
                public string TriggerName {get; private set; }
                /// <summary>
                /// Сообщение
                /// </summary>
                public string Message { get; }

                public ProgressNoticesEventArgs(string message)
                {
                    this.Message = message;
                }

                public ProgressNoticesEventArgs(DatabaseLogCreatorEvents.ProgressNotices progressNotice)
                {
                    this.Message = progressNotice.GetStringValue();
                }

                public ProgressNoticesEventArgs(DatabaseLogCreatorEvents.ProgressNotices progressNotice, string serverName, string databaseName, string tableName, string triggerName)
                {
                    this.ServerName = serverName;
                    this.DatabaseName = databaseName;
                    this.TableName = tableName;
                    this.TriggerName = triggerName;

                    this.Message = progressNotice.GetStringValue().Format(new
                    {
                        ProgressNotice = progressNotice,
                        ServerName = this.ServerName,
                        DatabaseName = this.DatabaseName,
                        TableName = this.TableName,
                        TriggerName = this.TriggerName
                    });
                }

                public ProgressNoticesEventArgs(DatabaseLogCreatorEvents.ProgressNotices progressNotice, string serverName) : this(progressNotice, serverName, null, null, null)
                {

                }

                public ProgressNoticesEventArgs(DatabaseLogCreatorEvents.ProgressNotices progressNotice, string serverName, string databaseName) : this(progressNotice, serverName, databaseName, null, null)
                {

                }
            }
        }
    }
}
