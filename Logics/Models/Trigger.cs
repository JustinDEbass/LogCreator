using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    public class Trigger
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsInsert { get; set; }
        public bool IsAfter { get; set; }
        public bool IsInsteadOf { get; set; }
        public bool IsDisabled { get; set; }
    }
}
