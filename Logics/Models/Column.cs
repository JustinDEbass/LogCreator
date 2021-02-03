using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    /// <summary>
    /// Столбец
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Наименование типа данных
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Является идентификатором
        /// </summary>
        public bool IsIdentity { get; set; }
    }
}
