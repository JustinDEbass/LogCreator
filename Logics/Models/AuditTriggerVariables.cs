using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    public class LogTriggerVariables
    {
        public string TriggerName { get; set; }
        public string TableName { get; set; }
        public string LogTableName { get; set; }
        public string PrimaryKeyColumnName { get; set; }
        public string RowData { get; set; }

        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(this.TriggerName) == false && string.IsNullOrEmpty(this.TableName) == false &&
                    string.IsNullOrEmpty(this.LogTableName) == false && string.IsNullOrEmpty(this.PrimaryKeyColumnName) == false &&
                    string.IsNullOrEmpty(this.RowData) == false;
            }
        }
    }
}
