namespace LogCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectToDataBaseButton = new System.Windows.Forms.Button();
            this.loginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.loginNameTextBox = new System.Windows.Forms.TextBox();
            this.loginNameLabel = new System.Windows.Forms.Label();
            this.useWindowsAuthenticationCheckBox = new System.Windows.Forms.CheckBox();
            this.serverAddressTextBox = new System.Windows.Forms.TextBox();
            this.serverAddressLabel = new System.Windows.Forms.Label();
            this.databaseNameComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rowDataSettingsFormButton = new System.Windows.Forms.Button();
            this.logTableSettingsFormButton = new System.Windows.Forms.Button();
            this.tableNamesLabel = new System.Windows.Forms.Label();
            this.tableNamesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.configureLoggingButton = new System.Windows.Forms.Button();
            this.disableLoggingButton = new System.Windows.Forms.Button();
            this.mainFormStatusStrip = new System.Windows.Forms.StatusStrip();
            this.progressStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.replaceExistTriggerCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mainFormStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectToDataBaseButton);
            this.groupBox1.Controls.Add(this.loginPasswordTextBox);
            this.groupBox1.Controls.Add(this.loginPasswordLabel);
            this.groupBox1.Controls.Add(this.loginNameTextBox);
            this.groupBox1.Controls.Add(this.loginNameLabel);
            this.groupBox1.Controls.Add(this.useWindowsAuthenticationCheckBox);
            this.groupBox1.Controls.Add(this.serverAddressTextBox);
            this.groupBox1.Controls.Add(this.serverAddressLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение к СУБД";
            // 
            // connectToDataBaseButton
            // 
            this.connectToDataBaseButton.Location = new System.Drawing.Point(269, 159);
            this.connectToDataBaseButton.Name = "connectToDataBaseButton";
            this.connectToDataBaseButton.Size = new System.Drawing.Size(75, 23);
            this.connectToDataBaseButton.TabIndex = 8;
            this.connectToDataBaseButton.Text = "Соединить";
            this.connectToDataBaseButton.UseVisualStyleBackColor = true;
            this.connectToDataBaseButton.Click += new System.EventHandler(this.OnClickConnectToDataBaseButton);
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.Location = new System.Drawing.Point(6, 133);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.Size = new System.Drawing.Size(338, 20);
            this.loginPasswordTextBox.TabIndex = 7;
            this.loginPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Location = new System.Drawing.Point(6, 117);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(48, 13);
            this.loginPasswordLabel.TabIndex = 6;
            this.loginPasswordLabel.Text = "Пароль:";
            // 
            // loginNameTextBox
            // 
            this.loginNameTextBox.Location = new System.Drawing.Point(6, 94);
            this.loginNameTextBox.Name = "loginNameTextBox";
            this.loginNameTextBox.Size = new System.Drawing.Size(338, 20);
            this.loginNameTextBox.TabIndex = 5;
            // 
            // loginNameLabel
            // 
            this.loginNameLabel.AutoSize = true;
            this.loginNameLabel.Location = new System.Drawing.Point(6, 78);
            this.loginNameLabel.Name = "loginNameLabel";
            this.loginNameLabel.Size = new System.Drawing.Size(85, 13);
            this.loginNameLabel.TabIndex = 4;
            this.loginNameLabel.Text = "Имя для входа:";
            // 
            // useWindowsAuthenticationCheckBox
            // 
            this.useWindowsAuthenticationCheckBox.AutoSize = true;
            this.useWindowsAuthenticationCheckBox.Location = new System.Drawing.Point(6, 58);
            this.useWindowsAuthenticationCheckBox.Name = "useWindowsAuthenticationCheckBox";
            this.useWindowsAuthenticationCheckBox.Size = new System.Drawing.Size(191, 17);
            this.useWindowsAuthenticationCheckBox.TabIndex = 3;
            this.useWindowsAuthenticationCheckBox.Text = "Проверка подлинности Windows";
            this.useWindowsAuthenticationCheckBox.UseVisualStyleBackColor = true;
            this.useWindowsAuthenticationCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChangedUseWindowsAuthenticationCheckBox);
            // 
            // serverAddressTextBox
            // 
            this.serverAddressTextBox.Location = new System.Drawing.Point(6, 32);
            this.serverAddressTextBox.Name = "serverAddressTextBox";
            this.serverAddressTextBox.Size = new System.Drawing.Size(338, 20);
            this.serverAddressTextBox.TabIndex = 2;
            // 
            // serverAddressLabel
            // 
            this.serverAddressLabel.AutoSize = true;
            this.serverAddressLabel.Location = new System.Drawing.Point(6, 16);
            this.serverAddressLabel.Name = "serverAddressLabel";
            this.serverAddressLabel.Size = new System.Drawing.Size(81, 13);
            this.serverAddressLabel.TabIndex = 1;
            this.serverAddressLabel.Text = "Сервер СУБД:";
            // 
            // databaseNameComboBox
            // 
            this.databaseNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseNameComboBox.Enabled = false;
            this.databaseNameComboBox.FormattingEnabled = true;
            this.databaseNameComboBox.Location = new System.Drawing.Point(6, 32);
            this.databaseNameComboBox.Name = "databaseNameComboBox";
            this.databaseNameComboBox.Size = new System.Drawing.Size(338, 21);
            this.databaseNameComboBox.TabIndex = 11;
            this.databaseNameComboBox.SelectedValueChanged += new System.EventHandler(this.OnChangeDatabaseNameComboBox);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rowDataSettingsFormButton);
            this.groupBox2.Controls.Add(this.logTableSettingsFormButton);
            this.groupBox2.Controls.Add(this.tableNamesLabel);
            this.groupBox2.Controls.Add(this.tableNamesCheckedListBox);
            this.groupBox2.Controls.Add(this.databaseNameLabel);
            this.groupBox2.Controls.Add(this.databaseNameComboBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 276);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки логирования в БД";
            // 
            // rowDataSettingsFormButton
            // 
            this.rowDataSettingsFormButton.Enabled = false;
            this.rowDataSettingsFormButton.Location = new System.Drawing.Point(6, 246);
            this.rowDataSettingsFormButton.Name = "rowDataSettingsFormButton";
            this.rowDataSettingsFormButton.Size = new System.Drawing.Size(338, 23);
            this.rowDataSettingsFormButton.TabIndex = 15;
            this.rowDataSettingsFormButton.Text = "Настройка триггера для логирования изменений";
            this.rowDataSettingsFormButton.UseVisualStyleBackColor = true;
            this.rowDataSettingsFormButton.Click += new System.EventHandler(this.OnClickRowDataSettingsFormButton);
            // 
            // logTableSettingsFormButton
            // 
            this.logTableSettingsFormButton.Enabled = false;
            this.logTableSettingsFormButton.Location = new System.Drawing.Point(6, 217);
            this.logTableSettingsFormButton.Name = "logTableSettingsFormButton";
            this.logTableSettingsFormButton.Size = new System.Drawing.Size(338, 23);
            this.logTableSettingsFormButton.TabIndex = 14;
            this.logTableSettingsFormButton.Text = "Настройка таблицы с логами";
            this.logTableSettingsFormButton.UseVisualStyleBackColor = true;
            this.logTableSettingsFormButton.Click += new System.EventHandler(this.OnClickLogTableSettingsFormButton);
            // 
            // tableNamesLabel
            // 
            this.tableNamesLabel.AutoSize = true;
            this.tableNamesLabel.Location = new System.Drawing.Point(6, 56);
            this.tableNamesLabel.Name = "tableNamesLabel";
            this.tableNamesLabel.Size = new System.Drawing.Size(286, 13);
            this.tableNamesLabel.TabIndex = 12;
            this.tableNamesLabel.Text = "Таблицы, изменения в которых требуется логировать:";
            // 
            // tableNamesCheckedListBox
            // 
            this.tableNamesCheckedListBox.Enabled = false;
            this.tableNamesCheckedListBox.FormattingEnabled = true;
            this.tableNamesCheckedListBox.Location = new System.Drawing.Point(6, 72);
            this.tableNamesCheckedListBox.Name = "tableNamesCheckedListBox";
            this.tableNamesCheckedListBox.Size = new System.Drawing.Size(338, 139);
            this.tableNamesCheckedListBox.TabIndex = 13;
            this.tableNamesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnItemCheckTableNamesCheckedListBox);
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.AutoSize = true;
            this.databaseNameLabel.Location = new System.Drawing.Point(6, 16);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(75, 13);
            this.databaseNameLabel.TabIndex = 10;
            this.databaseNameLabel.Text = "База данных:";
            // 
            // configureLoggingButton
            // 
            this.configureLoggingButton.Enabled = false;
            this.configureLoggingButton.Location = new System.Drawing.Point(12, 512);
            this.configureLoggingButton.Name = "configureLoggingButton";
            this.configureLoggingButton.Size = new System.Drawing.Size(350, 23);
            this.configureLoggingButton.TabIndex = 17;
            this.configureLoggingButton.Text = "Настроить логирование";
            this.configureLoggingButton.UseVisualStyleBackColor = true;
            this.configureLoggingButton.Click += new System.EventHandler(this.OnClickConfigureLoggingButton);
            // 
            // disableLoggingButton
            // 
            this.disableLoggingButton.Enabled = false;
            this.disableLoggingButton.Location = new System.Drawing.Point(12, 541);
            this.disableLoggingButton.Name = "disableLoggingButton";
            this.disableLoggingButton.Size = new System.Drawing.Size(350, 23);
            this.disableLoggingButton.TabIndex = 18;
            this.disableLoggingButton.Text = "Отключить логирование";
            this.disableLoggingButton.UseVisualStyleBackColor = true;
            this.disableLoggingButton.Click += new System.EventHandler(this.OnClickDisableLoggingButton);
            // 
            // mainFormStatusStrip
            // 
            this.mainFormStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressStatusLabel});
            this.mainFormStatusStrip.Location = new System.Drawing.Point(0, 579);
            this.mainFormStatusStrip.Name = "mainFormStatusStrip";
            this.mainFormStatusStrip.Size = new System.Drawing.Size(375, 22);
            this.mainFormStatusStrip.SizingGrip = false;
            this.mainFormStatusStrip.TabIndex = 19;
            this.mainFormStatusStrip.Text = "statusStrip1";
            // 
            // progressStatusLabel
            // 
            this.progressStatusLabel.Name = "progressStatusLabel";
            this.progressStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.progressStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // replaceExistTriggerCheckBox
            // 
            this.replaceExistTriggerCheckBox.AutoSize = true;
            this.replaceExistTriggerCheckBox.Enabled = false;
            this.replaceExistTriggerCheckBox.Location = new System.Drawing.Point(12, 489);
            this.replaceExistTriggerCheckBox.Name = "replaceExistTriggerCheckBox";
            this.replaceExistTriggerCheckBox.Size = new System.Drawing.Size(206, 17);
            this.replaceExistTriggerCheckBox.TabIndex = 16;
            this.replaceExistTriggerCheckBox.Text = "Заменить существующие триггеры";
            this.replaceExistTriggerCheckBox.UseVisualStyleBackColor = true;
            this.replaceExistTriggerCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChangedReplaceExistTriggerCheckBox);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 601);
            this.Controls.Add(this.replaceExistTriggerCheckBox);
            this.Controls.Add(this.mainFormStatusStrip);
            this.Controls.Add(this.disableLoggingButton);
            this.Controls.Add(this.configureLoggingButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogCreator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.mainFormStatusStrip.ResumeLayout(false);
            this.mainFormStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label serverAddressLabel;
        private System.Windows.Forms.Button connectToDataBaseButton;
        private System.Windows.Forms.TextBox loginPasswordTextBox;
        private System.Windows.Forms.Label loginPasswordLabel;
        private System.Windows.Forms.TextBox loginNameTextBox;
        private System.Windows.Forms.Label loginNameLabel;
        private System.Windows.Forms.CheckBox useWindowsAuthenticationCheckBox;
        private System.Windows.Forms.TextBox serverAddressTextBox;
        private System.Windows.Forms.ComboBox databaseNameComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label tableNamesLabel;
        private System.Windows.Forms.CheckedListBox tableNamesCheckedListBox;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.Button configureLoggingButton;
        private System.Windows.Forms.Button logTableSettingsFormButton;
        private System.Windows.Forms.Button rowDataSettingsFormButton;
        private System.Windows.Forms.Button disableLoggingButton;
        private System.Windows.Forms.StatusStrip mainFormStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel progressStatusLabel;
        private System.Windows.Forms.CheckBox replaceExistTriggerCheckBox;
    }
}

