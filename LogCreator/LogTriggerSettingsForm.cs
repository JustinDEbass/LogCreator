using LogCreator.Helpers;
using LogCreator.Models;
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
using static Logics.Enums.Types;

namespace LogCreator
{
    public partial class LogTriggerSettingsForm : Form
    {
        private LogTriggerSettings _logTriggerSettings = new LogTriggerSettings(); 
        public LogTriggerSettings LogTriggerSettings
        {
            get
            {
                return this._logTriggerSettings;
            }
            set 
            {
                this._logTriggerSettings = value;

                prefixTypeComboBox.SelectItem(s => (int)s.Value == (int)this._logTriggerSettings.PrefixType);
                prefixTextTextBox.Text = this._logTriggerSettings.PrefixText;
                prefixRandomNumberCountTextBox.Text = Convert.ToString(this._logTriggerSettings.PrefixRandomNumberCount);

                postfixTypeComboBox.SelectItem(s => (int)s.Value == (int)this._logTriggerSettings.PostfixType);
                postfixTextTextBox.Text = this._logTriggerSettings.PostfixText;
                postfixRandomNumberCountTextBox.Text = Convert.ToString(this._logTriggerSettings.PostfixRandomNumberCount);

                rowDataDisableCheckBox.Checked = this._logTriggerSettings.RowDataDisable;

                ignoreColumnNamesListBox.Items.AddRange(this._logTriggerSettings.IgnoreColumnNames.ToArray());
                ignoreDataTypeNamesListBox.Items.AddRange(this._logTriggerSettings.IgnoreDataTypeNames.ToArray());
            }
        }

        public LogTriggerSettingsForm()
        {
            InitializeComponent();

            InitializePrefixTypeComboBox();

            InitializePostfixTypeComboBox();
        }

        private void OnChangePrefixTypeComboBox(object sender, EventArgs e)
        {
            switch ((PrefixTypes)((ComboBoxItem)prefixTypeComboBox.SelectedItem).Value)
            {
                case PrefixTypes.Text:
                    {
                        prefixTextTextBox.Enabled = true;

                        prefixRandomNumberCountTextBox.Text = string.Empty;
                        prefixRandomNumberCountTextBox.Enabled = false;

                        break;
                    }
                case PrefixTypes.RandomNumber:
                    {
                        prefixRandomNumberCountTextBox.Enabled = true;

                        prefixTextTextBox.Text = string.Empty;
                        prefixTextTextBox.Enabled = false;

                        break;
                    }
                default:
                    {
                        prefixTextTextBox.Text = string.Empty;
                        prefixTextTextBox.Enabled = false;

                        prefixRandomNumberCountTextBox.Text = string.Empty;
                        prefixRandomNumberCountTextBox.Enabled = false;

                        break;
                    }
            }
        }

        private void OnChangePostfixTypeComboBox(object sender, EventArgs e)
        {
            switch ((PostfixTypes)((ComboBoxItem)postfixTypeComboBox.SelectedItem).Value)
            {
                case PostfixTypes.Text:
                    {
                        postfixTextTextBox.Enabled = true;

                        postfixRandomNumberCountTextBox.Text = string.Empty;
                        postfixRandomNumberCountTextBox.Enabled = false;

                        break;
                    }
                case PostfixTypes.RandomNumber:
                    {
                        postfixRandomNumberCountTextBox.Enabled = true;

                        postfixTextTextBox.Text = string.Empty;
                        postfixTextTextBox.Enabled = false;

                        break;
                    }
                default:
                    {
                        postfixTextTextBox.Text = string.Empty;
                        postfixTextTextBox.Enabled = false;

                        postfixRandomNumberCountTextBox.Text = string.Empty;
                        postfixRandomNumberCountTextBox.Enabled = false;

                        break;
                    }
            }
        }

        private void OnCheckedChangedRowDataDisableCheckBox(object sender, EventArgs e)
        {
            if (rowDataDisableCheckBox.Checked)
            {
                columnNameTextBox.Enabled = false;
                addColumnNameButton.Enabled = false;
                removeColumnNameButton.Enabled = false;
                ignoreColumnNamesListBox.Enabled = false;
                dataTypeNameTextBox.Enabled = false;
                addDataTypeNameButton.Enabled = false;
                removeDataTypeNameButton.Enabled = false;
                ignoreDataTypeNamesListBox.Enabled = false;
            }
            else
            {
                columnNameTextBox.Enabled = true;
                addColumnNameButton.Enabled = true;
                removeColumnNameButton.Enabled = true;
                ignoreColumnNamesListBox.Enabled = true;
                dataTypeNameTextBox.Enabled = true;
                addDataTypeNameButton.Enabled = true;
                removeDataTypeNameButton.Enabled = true;
                ignoreDataTypeNamesListBox.Enabled = true;
            }
        }

        private void OnClickAddColumnNameButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(columnNameTextBox.Text) == false)
            {
                ignoreColumnNamesListBox.Items.Add(columnNameTextBox.Text);
            }

            columnNameTextBox.Text = string.Empty;
        }

        private void OnClickRemoveColumnNameButton(object sender, EventArgs e)
        {
            var selectedDataTypeNameIndex = ignoreColumnNamesListBox.SelectedIndex;

            if (selectedDataTypeNameIndex > -1)
            {
                ignoreColumnNamesListBox.Items.RemoveAt(selectedDataTypeNameIndex);
            }
        }

        private void OnClickAddDataTypeNameButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dataTypeNameTextBox.Text) == false)
            {
                ignoreDataTypeNamesListBox.Items.Add(dataTypeNameTextBox.Text);
            }

            dataTypeNameTextBox.Text = string.Empty;
        }

        private void OnClickRemoveDataTypeNameButton(object sender, EventArgs e)
        {
            var selectedDataTypeNameIndex = ignoreDataTypeNamesListBox.SelectedIndex;

            if (selectedDataTypeNameIndex > -1)
            {
                ignoreDataTypeNamesListBox.Items.RemoveAt(selectedDataTypeNameIndex);
            }
        }

        private void OnClickSaveButton(object sender, EventArgs e)
        {
            var logTriggerSettings = new LogTriggerSettings
            {
                PrefixType = (PrefixTypes)((ComboBoxItem)prefixTypeComboBox.SelectedItem).Value,
                PrefixText = prefixTextTextBox.Text,
                PrefixRandomNumberCount = int.TryParse(Convert.ToString(prefixRandomNumberCountTextBox.Text), out var prefixRandomNumber) ? prefixRandomNumber : (int?)null,
                PostfixType = (PostfixTypes)((ComboBoxItem)postfixTypeComboBox.SelectedItem).Value,
                PostfixText = postfixTextTextBox.Text,
                PostfixRandomNumberCount = int.TryParse(Convert.ToString(postfixRandomNumberCountTextBox.Text), out var postfixRandomNumber) ? postfixRandomNumber : (int?)null,
                RowDataDisable = rowDataDisableCheckBox.Checked,
                IgnoreColumnNames = ignoreColumnNamesListBox.Items.Cast<string>().ToList(),
                IgnoreDataTypeNames = ignoreDataTypeNamesListBox.Items.Cast<string>().ToList()
            };

            if (ValidateForm(logTriggerSettings))
            {
                this._logTriggerSettings = logTriggerSettings;

                this.Close();
            }
        }

        private void OnClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }

        public void InitializePrefixTypeComboBox()
        {
            foreach (PrefixTypes prefixType in (PrefixTypes[])Enum.GetValues(typeof(PrefixTypes)))
            {
                prefixTypeComboBox.Items.Add(new ComboBoxItem { Value = (int)prefixType, Text = prefixType.GetStringValue() });
            }
        }

        public void InitializePostfixTypeComboBox()
        {
            foreach (PostfixTypes postfixTypes in (PostfixTypes[])Enum.GetValues(typeof(PostfixTypes)))
            {
                postfixTypeComboBox.Items.Add(new ComboBoxItem { Value = (int)postfixTypes, Text = postfixTypes.GetStringValue() });
            }
        }

        public bool ValidateForm(LogTriggerSettings logTriggerSettings)
        {
            var result = true;

            Dictionary<string, Control> logTriggerSettingsFormFields = new Dictionary<string, Control>()
            {
                { nameof(logTriggerSettings.PrefixText), prefixTextTextBox },
                { nameof(logTriggerSettings.PrefixRandomNumberCount), prefixRandomNumberCountTextBox },
                { nameof(logTriggerSettings.PostfixText), postfixTextTextBox },
                { nameof(logTriggerSettings.PostfixRandomNumberCount), postfixRandomNumberCountTextBox }
            };

            foreach (var logTableSettingsFormField in logTriggerSettingsFormFields)
            {
                var validateErrors = logTriggerSettings.Validate(logTableSettingsFormField.Key);

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
