using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using static Logics.Enums.Events;

namespace Logics.Models
{
    public class CustomEventArgs
    {
        static public class DatabaseLogCreatorArgs
        {
            public class ProgressNoticesEventArgs
            {
                public string ServerName { get; private set; }
                public string DatabaseName { get; private set; }
                public string TableName { get; private set; }
                public string TriggerName {get; private set; }
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
