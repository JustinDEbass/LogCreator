using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    /// <summary>
    /// Переменные триггера для логирования
    /// </summary>
    public class LogTriggerVariables
    {
        /// <summary>
        /// Наименование триггера
        /// </summary>
        public string TriggerName { get; set; }
        /// <summary>
        /// Наименование таблицы, в которой произошло событие
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Наименование таблицы с логами
        /// </summary>
        public string LogTableName { get; set; }
        /// <summary>
        /// Наименование столбца со значением первичного ключа
        /// </summary>
        public string PrimaryKeyColumnName { get; set; }
        /// <summary>
        /// Запрос для получения значений строки
        /// </summary>
        public string RowDataQuery { get; set; }

        /// <summary>
        /// Является валидным
        /// </summary>
        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(this.TriggerName) == false && string.IsNullOrEmpty(this.TableName) == false &&
                    string.IsNullOrEmpty(this.LogTableName) == false && string.IsNullOrEmpty(this.PrimaryKeyColumnName) == false &&
                    string.IsNullOrEmpty(this.RowDataQuery) == false;
            }
        }
    }
}
