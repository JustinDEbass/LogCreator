using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    public class Column
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public bool IsIdentity { get; set; }
    }
}
