using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    /// <summary>
    /// Дополнительные атрибуты
    /// </summary>
    public static class AdditionalAttributes
    {
        /// <summary>
        /// Атрибут со строковым значением
        /// </summary>
        public class StringValueAttribute : Attribute
        {
            /// <summary>
            /// Строкое значение
            /// </summary>
            public string StringValue { get; protected set; }

            public StringValueAttribute(string value)
            {
                StringValue = value;
            }
        }
    }
}
