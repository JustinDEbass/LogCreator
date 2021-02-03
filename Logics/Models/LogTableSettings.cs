using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logics.Enums.Errors;

namespace Logics.Models
{
    /// <summary>
    /// Настройки таблицы с логами
    /// </summary>
    public class LogTableSettings
    {
        /// <summary>
        /// Наименование таблицы с логами
        /// </summary>
        public string LogTableName { get; set; }
        /// <summary>
        /// Наименование столбца с типом события
        /// </summary>
        public string EventTypeColumnName { get; set; }
        /// <summary>
        /// Наименование столбца с наименованием таблицы, в которой произошло событие
        /// </summary>
        public string TableNameColumnName { get; set; }
        /// <summary>
        /// Наименование столбца с датой события
        /// </summary>
        public string EventDateColumnName { get; set; }
        /// <summary>
        /// Наименование столбца с наименованием пользователя, который осуществил событие
        /// </summary>
        public string UserNameColumnName { get; set; }
        /// <summary>
        /// Наименование столбца со значением первичного ключа
        /// </summary>
        public string PrimaryKeyColumnName { get; set; }
        /// <summary>
        /// Наименование столбца со значениями строки таблицы, в которой произошло событие
        /// </summary>
        public string RowDataColumnName { get; set; }

        /// <summary>
        /// Является валидным
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.Validate().Count == 0;
            }
        }

        /// <summary>
        /// Валидация
        /// </summary>
        /// <returns>Список свойств с ошибками валидации</returns>
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

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="propertyName">Свойство</param>
        /// <returns>Список ошибок валидации</returns>
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
