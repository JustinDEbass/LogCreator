using Logics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logics.Models.CustomEventArgs.DatabaseLogCreatorArgs;

namespace Logics.Interfaces
{
    public delegate void ProgressNoticesHandler(object sender, ProgressNoticesEventArgs e);

    public interface IDatabaseLogCreator
    {
        event ProgressNoticesHandler ProgressNotify;

        LogTableSettings LogTableSettings { get; set; }
        LogTriggerSettings LogTriggerSettings { get; set; }
        bool ReplaceExistTrigger { get; set; }

        void ConnectToServer(string serverName, string loginName, string loginPassword, bool isWindowsAuthentication);
        void DisconnectFromServer();
        Task<List<Database>> GetDatabaseNameListAsync();
        List<Database> GetDatabaseNameList();
        Task ConnectionToDatabaseAsync(string databaseName);
        void ConnectionToDatabase(string databaseName);
        void DisconnectFromDatabase();
        Task<List<Table>> GetTableNameListAsync();
        List<Table> GetTableNameList();
        Task GenerateLogTriggersAsync(List<string> tableNameList);
        void GenerateLogTriggers(List<string> tableNameList);
        Task DeleteLogTriggersAsync(List<string> tableNameList);
        void DeleteLogTriggers(List<string> tableNameList);
    }
}
