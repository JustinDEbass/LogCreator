using Logics.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace LogCreator
{
    public partial class LogTableSettingsForm : Form
    {
        private LogTableSettings _logTableSettings = new LogTableSettings();
        public LogTableSettings LogTableSettings
        {
            get
            {
                return this._logTableSettings;
            }
            set
            {
                this._logTableSettings = value;

                logTableNameTextBox.Text = this._logTableSettings.LogTableName;
                eventTypeColumnNameTextBox.Text = this._logTableSettings.EventTypeColumnName;
                tableNameColumnNameTextBox.Text = this._logTableSettings.TableNameColumnName;
                eventDateColumnNameTextBox.Text = this._logTableSettings.EventDateColumnName;
                userNameColumnNameTextBox.Text = this._logTableSettings.UserNameColumnName;
                primaryKeyColumnNameTextBox.Text = this._logTableSettings.PrimaryKeyColumnName;
                rowDataColumnNameTextBox.Text = this._logTableSettings.RowDataColumnName;
            }
        }

        public LogTableSettingsForm()
        {
            InitializeComponent();
        }

        private void OnClickSaveButton(object sender, EventArgs e)
        {
            var logTableSettings = new LogTableSettings
            {
                LogTableName = logTableNameTextBox.Text,
                EventTypeColumnName = eventTypeColumnNameTextBox.Text,
                TableNameColumnName = tableNameColumnNameTextBox.Text,
                EventDateColumnName = eventDateColumnNameTextBox.Text,
                UserNameColumnName = userNameColumnNameTextBox.Text,
                PrimaryKeyColumnName = primaryKeyColumnNameTextBox.Text,
                RowDataColumnName = rowDataColumnNameTextBox.Text
            };

            if (ValidateForm(logTableSettings))
            {
                this._logTableSettings = logTableSettings;

                this.Close();
            }
        }

        private void OnClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ValidateForm(LogTableSettings logTableSettings)
        {
            var result = true;

            Dictionary<string, Control> logTableSettingsFormFields = new Dictionary<string, Control>()
            {
                { nameof(logTableSettings.LogTableName), logTableNameTextBox },
                { nameof(logTableSettings.EventTypeColumnName), eventTypeColumnNameTextBox },
                { nameof(logTableSettings.TableNameColumnName), tableNameColumnNameTextBox },
                { nameof(logTableSettings.EventDateColumnName), eventDateColumnNameTextBox },
                { nameof(logTableSettings.UserNameColumnName), userNameColumnNameTextBox },
                { nameof(logTableSettings.PrimaryKeyColumnName), primaryKeyColumnNameTextBox },
                { nameof(logTableSettings.RowDataColumnName), rowDataColumnNameTextBox }
            };

            foreach (var logTableSettingsFormField in logTableSettingsFormFields)
            {
                var validateErrors = logTableSettings.Validate(logTableSettingsFormField.Key);

                if (validateErrors.Count() > 0)
                {
                    errorProvider1.SetIconAlignment(logTableSettingsFormField.Value, ErrorIconAlignment.MiddleRight);
                    errorProvider1.SetIconPadding(logTableSettingsFormField.Value, -20);
                    errorProvider1.SetError(logTableSettingsFormField.Value, string.Join("\n", validateErrors.Select(s => s.GetStringValue()).ToArray()));

                    result = false;
                }
            }

            return result;
        }
    }
}
