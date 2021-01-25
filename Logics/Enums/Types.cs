using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.AdditionalAttributes;

namespace Logics.Enums
{
    public static class Types
    {
        public enum PrefixTypes : int
        {
            [StringValue("Отсутствует")]
            Missing = 1,
            [StringValue("Текст")]
            Text = 2,
            [StringValue("Случайное число")]
            RandomNumber = 3
        }

        public enum PostfixTypes : int
        {
            [StringValue("Отсутствует")]
            Missing = 1,
            [StringValue("Текст")]
            Text = 2,
            [StringValue("Случайное число")]
            RandomNumber = 3
        }
    }
}
