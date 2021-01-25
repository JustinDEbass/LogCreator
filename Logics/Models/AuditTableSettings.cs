using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logics.Enums.Errors;

namespace Logics.Models
{
    public class LogTableSettings
    {
        public string LogTableName { get; set; }
        public string EventTypeColumnName { get; set; }
        public string TableNameColumnName { get; set; }
        public string EventDateColumnName { get; set; }
        public string UserNameColumnName { get; set; }
        public string PrimaryKeyColumnName { get; set; }
        public string RowDataColumnName { get; set; }

        public bool IsValid
        {
            get
            {
                return this.Validate().Count == 0;
            }
        }

        public Dictionary<string, List<LogTableSettingsValidateErrors>> Validate()
        {
            Dictionary<string, List<LogTableSettingsValidateErrors>> result = new Dictionary<string, List<LogTableSettingsValidateErrors>>() { };

            List<string> requiredProperties = new List<string>()
            {
                nameof(LogTableName),
                nameof(EventTypeColumnName),
                nameof(TableNameColumnName),
                nameof(EventDateColumnName),
                nameof(UserNameColumnName),
                nameof(PrimaryKeyColumnName),
                nameof(RowDataColumnName)
            };

            foreach (var requiredProperty in requiredProperties)
            {
                var validateErrors = this.Validate(requiredProperty);

                if (validateErrors.Count > 0)
                {
                    result.Add(requiredProperty, validateErrors);
                }
            }

            return result;
        }

        public List<LogTableSettingsValidateErrors> Validate(string propertyName)
        {
            List<LogTableSettingsValidateErrors> result = new List<LogTableSettingsValidateErrors>() { };

            switch (propertyName)
            {
                case nameof(this.LogTableName):
                case nameof(this.EventTypeColumnName):
                case nameof(this.TableNameColumnName):
                case nameof(this.EventDateColumnName):
                case nameof(this.UserNameColumnName):
                case nameof(this.PrimaryKeyColumnName):
                case nameof(this.RowDataColumnName):
                    {
                        var value = Convert.ToString(this.GetType().GetProperty(propertyName)?.GetValue(this));

                        if (string.IsNullOrEmpty(value))
                        {
                            result.Add(LogTableSettingsValidateErrors.IsEmpty);
                        }

                        break;
                    }
            }

            return result;
        }
    }
}
