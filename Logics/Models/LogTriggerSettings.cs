using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logics.Enums.Errors;
using static Logics.Enums.Types;

namespace Logics.Models
{
    /// <summary>
    /// Настройки триггера для логирования
    /// </summary>
    public class LogTriggerSettings
    {
        /// <summary>
        /// Тип префикса наименования триггера
        /// </summary>
        public PrefixTypes PrefixType { get; set; }
        /// <summary>
        /// Текст префикса наименования триггера
        /// </summary>
        public string PrefixText { get; set; }
        /// <summary>
        /// Количество случайных чисел в префиксе наименования триггера
        /// </summary>
        public int? PrefixRandomNumberCount { get; set; }
        /// <summary>
        /// Тип постфикса наименования триггера
        /// </summary>
        public PostfixTypes PostfixType { get; set; }
        /// <summary>
        /// Текст постфикса наименования триггера
        /// </summary>
        public string PostfixText { get; set; }
        /// <summary>
        /// Количество случайных чисел в постфиксе наименования триггера
        /// </summary>
        public int? PostfixRandomNumberCount { get; set; }
        /// <summary>
        /// Отключено формирование значений строки
        /// </summary>
        public bool RowDataDisable { get; set; }
        /// <summary>
        /// Список наименования столбцов для игнорирования при формировании значений строки
        /// </summary>
        public List<string> IgnoreColumnNames { get; set; }
        /// <summary>
        /// Список наименования типов данных для игнорирования при формировании значений строки
        /// </summary>
        public List<string> IgnoreDataTypeNames { get; set; }

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
        public Dictionary<string, List<LogTriggerSettingsValidateErrors>> Validate()
        {
            Dictionary<string, List<LogTriggerSettingsValidateErrors>> result = new Dictionary<string, List<LogTriggerSettingsValidateErrors>>() { };

            List<string> requiredProperties = new List<string>()
            {
                nameof(PrefixText),
                nameof(PrefixRandomNumberCount),
                nameof(PostfixText),
                nameof(PostfixRandomNumberCount)
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
        public List<LogTriggerSettingsValidateErrors> Validate(string propertyName)
        {
            List<LogTriggerSettingsValidateErrors> result = new List<LogTriggerSettingsValidateErrors>() { };

            switch (propertyName)
            {
                case nameof(this.PrefixText):
                    {
                        if (this.PrefixType == PrefixTypes.Text)
                        {
                            var value = Convert.ToString(this.GetType().GetProperty(propertyName)?.GetValue(this));

                            if (string.IsNullOrEmpty(value))
                            {
                                result.Add(LogTriggerSettingsValidateErrors.IsEmpty);
                            }
                        }

                        break;
                    }
                case nameof(this.PrefixRandomNumberCount):
                    {
                        if (this.PrefixType == PrefixTypes.RandomNumber)
                        { 
                            var value = Convert.ToString(this.GetType().GetProperty(propertyName)?.GetValue(this));

                            if (string.IsNullOrEmpty(value))
                            {
                                result.Add(LogTriggerSettingsValidateErrors.IsEmpty);
                            }

                            if (string.IsNullOrEmpty(value) == false && Convert.ToInt32(value) == 0)
                            {
                                result.Add(LogTriggerSettingsValidateErrors.IsZero);
                            }

                            if (string.IsNullOrEmpty(value) == false && Convert.ToInt32(value) < 0)
                            {
                                result.Add(LogTriggerSettingsValidateErrors.IsNegative);
                            }
                        }

                        break;
                    }
                case nameof(this.PostfixText):
                    {
                        if (this.PostfixType == PostfixTypes.Text)
                        {
                            var value = Convert.ToString(this.GetType().GetProperty(propertyName)?.GetValue(this));

                            if (string.IsNullOrEmpty(value))
                            {
                                result.Add(LogTriggerSettingsValidateErrors.IsEmpty);
                            }
                        }

                        break;
                    }
                case nameof(this.PostfixRandomNumberCount):
                    {
                        if (this.PostfixType == PostfixTypes.RandomNumber)
                        {
                            var value = Convert.ToString(this.GetType().GetProperty(propertyName)?.GetValue(this));

                            if (string.IsNullOrEmpty(value))
                            {
                                result.Add(LogTriggerSettingsValidateErrors.IsEmpty);
                            }

                            if (string.IsNullOrEmpty(value) == false && Convert.ToInt32(value) == 0)
                            {
                                result.Add(LogTriggerSettingsValidateErrors.IsZero);
                            }

                            if (string.IsNullOrEmpty(value) == false && Convert.ToInt32(value) < 0)
                            {
                                result.Add(LogTriggerSettingsValidateErrors.IsNegative);
                            }
                        }

                        break;
                    }
            }

            return result;
        }
    }
}
