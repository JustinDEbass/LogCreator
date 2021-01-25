using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logics.Enums.Errors;
using static Logics.Enums.Types;

namespace Logics.Models
{
    public class LogTriggerSettings
    {
        public PrefixTypes PrefixType { get; set; }
        public string PrefixText { get; set; }
        public int? PrefixRandomNumberCount { get; set; }
        public PostfixTypes PostfixType { get; set; }
        public string PostfixText { get; set; }
        public int? PostfixRandomNumberCount { get; set; }
        public bool RowDataDisable { get; set; }
        public List<string> IgnoreColumnNames { get; set; }
        public List<string> IgnoreDataTypeNames { get; set; }

        public bool IsValid
        {
            get
            {
                return this.Validate().Count == 0;
            }
        }

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
