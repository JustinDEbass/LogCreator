using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogCreator.Models
{
    /// <summary>
    /// Элемент списка
    /// </summary>
    public class ComboBoxItem
    {
        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
