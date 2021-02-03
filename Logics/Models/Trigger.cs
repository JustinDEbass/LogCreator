using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    /// <summary>
    /// Триггер
    /// </summary>
    public class Trigger
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
        /// Наименование владельца
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// Наименование схемы
        /// </summary>
        public string SchemaName { get; set; }
        /// <summary>
        /// Наименование таблицы
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Является триггером, который срабатывает при обновлении
        /// </summary>
        public bool IsUpdate { get; set; }
        /// <summary>
        /// Является триггером, который срабатывает при удалении
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// Является триггером, который срабатывает при вставке
        /// </summary>
        public bool IsInsert { get; set; }
        /// <summary>
        /// Является триггером "после"
        /// </summary>
        public bool IsAfter { get; set; }
        /// <summary>
        /// Является триггером "вместо"
        /// </summary>
        public bool IsInsteadOf { get; set; }
        /// <summary>
        /// Является отключенным
        /// </summary>
        public bool IsDisabled { get; set; }
    }
}
