using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.AdditionalAttributes;

namespace Logics.Enums
{
    /// <summary>
    /// Типы
    /// </summary>
    public static class Types
    {
        /// <summary>
        /// Типы префиксов
        /// </summary>
        public enum PrefixTypes : int
        {
            /// <summary>
            /// Отсутствует
            /// </summary>
            [StringValue("Отсутствует")]
            Missing = 1,
            /// <summary>
            /// Текст
            /// </summary>
            [StringValue("Текст")]
            Text = 2,
            /// <summary>
            /// Случайное число
            /// </summary>
            [StringValue("Случайное число")]
            RandomNumber = 3
        }

        /// <summary>
        /// Типы постфиксов
        /// </summary>
        public enum PostfixTypes : int
        {
            /// <summary>
            /// Отсутствует
            /// </summary>
            [StringValue("Отсутствует")]
            Missing = 1,
            /// <summary>
            /// Текст
            /// </summary>
            [StringValue("Текст")]
            Text = 2,
            /// <summary>
            /// Случайное число
            /// </summary>
            [StringValue("Случайное число")]
            RandomNumber = 3
        }
    }
}
