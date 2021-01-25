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
    public static class AdditionalExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            StringValueAttribute[] attributes = (StringValueAttribute[])fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false);

            return attributes.Length > 0 ? attributes.FirstOrDefault().StringValue : null;
        }

        public static string Format(this string value, object data)
        {
            var valueTemplate = Template.Parse(value);

            return valueTemplate.Render(data, member => member.Name);
        }
    }
}
