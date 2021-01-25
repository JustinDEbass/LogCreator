using LogCreator.Models;
using Logics;
using Logics.Interfaces;
using Logics.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Logics.Models.CustomEventArgs;

namespace LogCreator
{
    public partial class MainForm : Form
    {
        private readonly IDatabaseLogCreator _databaseLogCreator = new DatabaseLogCreator();

        public MainForm()
        {
            InitializeComponent();

            _databaseLogCreator.ProgressNotify += SetProgressStatus;
        }

        private void OnCheckedChangedUseWindowsAuthenticationCheckBox(object sender, EventArgs e)
        {
            if (useWindowsAuthenticationCheckBox.Checked == true)
            {
                loginNameTextBox.Enabled = false;
                loginPasswordTextBox.Enabled = false;
            }
            else
            {
                loginNameTextBox.Enabled = true;
                loginPasswordTextBox.Enabled = true;
            }
        }

        private void OnClickConnectToDataBaseButton(object sender, EventArgs e)
        {
            ClearDatabaseNameComboBox();

            _databaseLogCreator.ConnectToServer(
                serverAddressTextBox.Text,
                loginNameTextBox.Text,
                loginPasswordTextBox.Text,
                useWindowsAuthenticationCheckBox.Checked
            );

            InitializeDatabaseNameComboBox();
        }

        private void OnChangeDatabaseNameComboBox(object sender, EventArgs e)
        {
            ClearTableNamesCheckedListBox();

            InitializeTableNamesCheckedListBox();
        }

        private void OnItemCheckTableNamesCheckedListBox(object sender, ItemCheckEventArgs e)
        {
            if (tableNamesCheckedListBox.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
            {
                logTableSettingsFormButton.Enabled = false;
                rowDataSettingsFormButton.Enabled = false;
                replaceExistTriggerCheckBox.Enabled = false;
                configureLoggingButton.Enabled = false;
                disableLoggingButton.Enabled = false;
            }
            else
            {
                logTableSettingsFormButton.Enabled = true;
                rowDataSettingsFormButton.Enabled = true;
                replaceExistTriggerCheckBox.Enabled = true;
                configureLoggingButton.Enabled = true;
                disableLoggingButton.Enabled = true;
            }
        }

        private void OnClickRowDataSettingsFormButton(object sender, EventArgs e)
        {
            using (LogTriggerSettingsForm rowDataSettingsForm = new LogTriggerSettingsForm())
            {
                rowDataSettingsForm.LogTriggerSettings = _databaseLogCreator.LogTriggerSettings;

                rowDataSettingsForm.ShowDialog();

                _databaseLogCreator.LogTriggerSettings = rowDataSettingsForm.LogTriggerSettings;
            }
        }

        private void OnClickLogTableSettingsFormButton(object sender, EventArgs e)
        {
            using (LogTableSettingsForm logTableSettingsForm = new LogTableSettingsForm())
            {
                logTableSettingsForm.LogTableSettings = _databaseLogCreator.LogTableSettings;

                logTableSettingsForm.ShowDialog();

                _databaseLogCreator.LogTableSettings = logTableSettingsForm.LogTableSettings;
            }
        }

        private void OnCheckedChangedReplaceExistTriggerCheckBox(object sender, EventArgs e)
        {
            _databaseLogCreator.ReplaceExistTrigger = replaceExistTriggerCheckBox.Checked;
        }

        private async void OnClickConfigureLoggingButton(object sender, EventArgs e)
        {
            BlockAllFormElements();

            var tableNameList = tableNamesCheckedListBox.CheckedItems.Cast<ComboBoxItem>().Select(s => s.Text).ToList();

            await _databaseLogCreator.GenerateLogTriggersAsync(tableNameList);

            UnblockAllFormElements();
        }

        private async void OnClickDisableLoggingButton(object sender, EventArgs e)
        {
            BlockAllFormElements();

            var tableNameList = tableNamesCheckedListBox.CheckedItems.Cast<ComboBoxItem>().Select(s => s.Text).ToList();

            await _databaseLogCreator.DeleteLogTriggersAsync(tableNameList);

            UnblockAllFormElements();
        }

        public void ClearDatabaseNameComboBox()
        {
            _databaseLogCreator.DisconnectFromDatabase();

            databaseNameComboBox.Items.Clear();
        }

        public async void InitializeDatabaseNameComboBox()
        {
            connectToDataBaseButton.Enabled = false;

            try
            {
                var databaseNameList = await _databaseLogCreator.GetDatabaseNameListAsync();

                foreach (Database databaseName in databaseNameList)
                {
                    databaseNameComboBox.Items.Add(new ComboBoxItem { Value = databaseName.ID, Text = databaseName.Name });
                }

                databaseNameComboBox.Enabled = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                connectToDataBaseButton.Enabled = true;
            }
        }

        public void ClearTableNamesCheckedListBox()
        {
            _databaseLogCreator.DisconnectFromDatabase();

            tableNamesCheckedListBox.Items.Clear();
        }

        public async void InitializeTableNamesCheckedListBox()
        {
            connectToDataBaseButton.Enabled = false;
            databaseNameComboBox.Enabled = false;

            try
            {
                var databaseName = ((ComboBoxItem)databaseNameComboBox.SelectedItem).Text;

                await _databaseLogCreator.ConnectionToDatabaseAsync(databaseName);

                var tableNameList = await _databaseLogCreator.GetTableNameListAsync();

                foreach (Table tableName in tableNameList)
                {
                    tableNamesCheckedListBox.Items.Add(new ComboBoxItem { Value = tableName.ID, Text = tableName.Name });
                }

                tableNamesCheckedListBox.Enabled = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                connectToDataBaseButton.Enabled = true;
                databaseNameComboBox.Enabled = true;
            }
        }

        public void SetProgressStatus(object sender, DatabaseLogCreatorArgs.ProgressNoticesEventArgs e)
        {
            if (IsHandleCreated)
            {
                mainFormStatusStrip.BeginInvoke((MethodInvoker)(() => progressStatusLabel.Text = e.Message));
            }
        }

        private void BlockAllFormElements()
        {
            connectToDataBaseButton.Enabled = false;
            databaseNameComboBox.Enabled = false;
            tableNamesCheckedListBox.Enabled = false;
            logTableSettingsFormButton.Enabled = false;
            rowDataSettingsFormButton.Enabled = false;
            replaceExistTriggerCheckBox.Enabled = false;
            configureLoggingButton.Enabled = false;
            disableLoggingButton.Enabled = false;
        }

        private void UnblockAllFormElements()
        {
            connectToDataBaseButton.Enabled = true;
            databaseNameComboBox.Enabled = true;
            tableNamesCheckedListBox.Enabled = true;
            logTableSettingsFormButton.Enabled = true;
            rowDataSettingsFormButton.Enabled = true;
            replaceExistTriggerCheckBox.Enabled = true;
            configureLoggingButton.Enabled = true;
            disableLoggingButton.Enabled = true;
        }
    }
}
