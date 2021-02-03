using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Utilities.AdditionalAttributes;

namespace Utilities
{
    /// <summary>
    /// Дополнительные расширения
    /// </summary>
    public static class AdditionalExtensions
    {
        /// <summary>
        /// Получить строковое значение установленное атрибутом "StringValueAttribute"
        /// </summary>
        /// <param name="value">Перечисление</param>
        /// <returns>Строковое значение</returns>
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            StringValueAttribute[] attributes = (StringValueAttribute[])fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false);

            return attributes.Length > 0 ? attributes.FirstOrDefault().StringValue : null;
        }

        /// <summary>
        /// Форматирование строки с учетом указанных данных
        /// </summary>
        /// <param name="value">Строковое значение</param>
        /// <param name="data">Объект с данными</param>
        /// <returns>Строковое значение</returns>
        public static string Format(this string value, object data)
        {
            var valueTemplate = Template.Parse(value);

            return valueTemplate.Render(data, member => member.Name);
        }
    }
}
