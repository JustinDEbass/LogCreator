using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logics.Enums.Types;

namespace Logics.Models
{
    public class TriggerNameGenerator
    {
        public string TableName { get; set; }
        public LogTriggerSettings LogTriggerSettings { get; set; }
        public string Name 
        {
            get
            {
                var result = string.Empty;

                switch (this.LogTriggerSettings.PrefixType)
                {
                    case PrefixTypes.Text:
                        {
                            result += this.LogTriggerSettings.PrefixText;

                            break;
                        }
                    case PrefixTypes.RandomNumber:
                        {
                            result += new Random().Next(10000).ToString("D5");

                            break;
                        }
                }

                result += this.TableName;

                switch (this.LogTriggerSettings.PostfixType)
                {
                    case PostfixTypes.Text:
                        {
                            result += this.LogTriggerSettings.PostfixText;

                            break;
                        }
                    case PostfixTypes.RandomNumber:
                        {
                            result += new Random().Next(10000).ToString("D5");

                            break;
                        }
                }

                return result;
            }
        }
        public string NameSearchPattern
        { 
            get
            {
                var result = string.Empty;

                switch (this.LogTriggerSettings.PrefixType)
                {
                    case PrefixTypes.Text:
                        {
                            result += this.LogTriggerSettings.PrefixText;

                            break;
                        }
                    case PrefixTypes.RandomNumber:
                        {
                            result += "[0-9][0-9][0-9][0-9][0-9]";

                            break;
                        }
                }

                result += this.TableName;

                switch (this.LogTriggerSettings.PostfixType)
                {
                    case PostfixTypes.Text:
                        {
                            result += this.LogTriggerSettings.PostfixText;

                            break;
                        }
                    case PostfixTypes.RandomNumber:
                        {
                            result += "[0-9][0-9][0-9][0-9][0-9]";

                            break;
                        }
                }

                return result;
            } 
        }

        public TriggerNameGenerator(string tableName, LogTriggerSettings logTriggerSettings)
        {
            this.TableName = tableName;
            this.LogTriggerSettings = logTriggerSettings;
        }
    }
}
