namespace LogCreator
{
    partial class LogTriggerSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogTriggerSettingsForm));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ignoreColumnNamesLabel = new System.Windows.Forms.Label();
            this.ignoreColumnNamesListBox = new System.Windows.Forms.ListBox();
            this.removeColumnNameButton = new System.Windows.Forms.Button();
            this.addColumnNameButton = new System.Windows.Forms.Button();
            this.columnNameTextBox = new System.Windows.Forms.TextBox();
            this.columnNameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ignoreDataTypeNamesLabel = new System.Windows.Forms.Label();
            this.ignoreDataTypeNamesListBox = new System.Windows.Forms.ListBox();
            this.removeDataTypeNameButton = new System.Windows.Forms.Button();
            this.addDataTypeNameButton = new System.Windows.Forms.Button();
            this.dataTypeNameTextBox = new System.Windows.Forms.TextBox();
            this.dataTypeNameLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.postfixRandomNumberCountTextBox = new System.Windows.Forms.TextBox();
            this.postfixRandomNumberCountLabel = new System.Windows.Forms.Label();
            this.postfixTypeLabel = new System.Windows.Forms.Label();
            this.postfixTypeComboBox = new System.Windows.Forms.ComboBox();
            this.postfixTextTextBox = new System.Windows.Forms.TextBox();
            this.postfixTextLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.prefixRandomNumberCountTextBox = new System.Windows.Forms.TextBox();
            this.prefixRandomNumberCountLabel = new System.Windows.Forms.Label();
            this.prefixTypeLabel = new System.Windows.Forms.Label();
            this.prefixTypeComboBox = new System.Windows.Forms.ComboBox();
            this.prefixTextLabel = new System.Windows.Forms.Label();
            this.prefixTextTextBox = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rowDataDisableCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ignoreColumnNamesLabel);
            this.groupBox3.Controls.Add(this.ignoreColumnNamesListBox);
            this.groupBox3.Controls.Add(this.removeColumnNameButton);
            this.groupBox3.Controls.Add(this.addColumnNameButton);
            this.groupBox3.Controls.Add(this.columnNameTextBox);
            this.groupBox3.Controls.Add(this.columnNameLabel);
            this.groupBox3.Location = new System.Drawing.Point(6, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 201);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Игнорируемые столбцы";
            // 
            // ignoreColumnNamesLabel
            // 
            this.ignoreColumnNamesLabel.AutoSize = true;
            this.ignoreColumnNamesLabel.Location = new System.Drawing.Point(6, 84);
            this.ignoreColumnNamesLabel.Name = "ignoreColumnNamesLabel";
            this.ignoreColumnNamesLabel.Size = new System.Drawing.Size(173, 13);
            this.ignoreColumnNamesLabel.TabIndex = 5;
            this.ignoreColumnNamesLabel.Text = "Список игнорируемых столбцов:";
            // 
            // ignoreColumnNamesListBox
            // 
            this.ignoreColumnNamesListBox.FormattingEnabled = true;
            this.ignoreColumnNamesListBox.Location = new System.Drawing.Point(6, 100);
            this.ignoreColumnNamesListBox.Name = "ignoreColumnNamesListBox";
            this.ignoreColumnNamesListBox.Size = new System.Drawing.Size(326, 95);
            this.ignoreColumnNamesListBox.TabIndex = 6;
            // 
            // removeColumnNameButton
            // 
            this.removeColumnNameButton.Location = new System.Drawing.Point(87, 58);
            this.removeColumnNameButton.Name = "removeColumnNameButton";
            this.removeColumnNameButton.Size = new System.Drawing.Size(75, 23);
            this.removeColumnNameButton.TabIndex = 4;
            this.removeColumnNameButton.Text = "Удалить";
            this.removeColumnNameButton.UseVisualStyleBackColor = true;
            this.removeColumnNameButton.Click += new System.EventHandler(this.OnClickRemoveColumnNameButton);
            // 
            // addColumnNameButton
            // 
            this.addColumnNameButton.Location = new System.Drawing.Point(6, 58);
            this.addColumnNameButton.Name = "addColumnNameButton";
            this.addColumnNameButton.Size = new System.Drawing.Size(75, 23);
            this.addColumnNameButton.TabIndex = 3;
            this.addColumnNameButton.Text = "Добавить";
            this.addColumnNameButton.UseVisualStyleBackColor = true;
            this.addColumnNameButton.Click += new System.EventHandler(this.OnClickAddColumnNameButton);
            // 
            // columnNameTextBox
            // 
            this.columnNameTextBox.Location = new System.Drawing.Point(6, 32);
            this.columnNameTextBox.Name = "columnNameTextBox";
            this.columnNameTextBox.Size = new System.Drawing.Size(326, 20);
            this.columnNameTextBox.TabIndex = 2;
            // 
            // columnNameLabel
            // 
            this.columnNameLabel.AutoSize = true;
            this.columnNameLabel.Location = new System.Drawing.Point(6, 16);
            this.columnNameLabel.Name = "columnNameLabel";
            this.columnNameLabel.Size = new System.Drawing.Size(130, 13);
            this.columnNameLabel.TabIndex = 1;
            this.columnNameLabel.Text = "Наименование столбца:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(550, 437);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnClickCancelButton);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(631, 437);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnClickSaveButton);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ignoreDataTypeNamesLabel);
            this.groupBox4.Controls.Add(this.ignoreDataTypeNamesListBox);
            this.groupBox4.Controls.Add(this.removeDataTypeNameButton);
            this.groupBox4.Controls.Add(this.addDataTypeNameButton);
            this.groupBox4.Controls.Add(this.dataTypeNameTextBox);
            this.groupBox4.Controls.Add(this.dataTypeNameLabel);
            this.groupBox4.Location = new System.Drawing.Point(350, 43);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 201);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Игнорируемые типы данных";
            // 
            // ignoreDataTypeNamesLabel
            // 
            this.ignoreDataTypeNamesLabel.AutoSize = true;
            this.ignoreDataTypeNamesLabel.Location = new System.Drawing.Point(6, 84);
            this.ignoreDataTypeNamesLabel.Name = "ignoreDataTypeNamesLabel";
            this.ignoreDataTypeNamesLabel.Size = new System.Drawing.Size(195, 13);
            this.ignoreDataTypeNamesLabel.TabIndex = 12;
            this.ignoreDataTypeNamesLabel.Text = "Список игнорируемых типов данных:";
            // 
            // ignoreDataTypeNamesListBox
            // 
            this.ignoreDataTypeNamesListBox.FormattingEnabled = true;
            this.ignoreDataTypeNamesListBox.Location = new System.Drawing.Point(6, 100);
            this.ignoreDataTypeNamesListBox.Name = "ignoreDataTypeNamesListBox";
            this.ignoreDataTypeNamesListBox.Size = new System.Drawing.Size(326, 95);
            this.ignoreDataTypeNamesListBox.TabIndex = 13;
            // 
            // removeDataTypeNameButton
            // 
            this.removeDataTypeNameButton.Location = new System.Drawing.Point(87, 58);
            this.removeDataTypeNameButton.Name = "removeDataTypeNameButton";
            this.removeDataTypeNameButton.Size = new System.Drawing.Size(75, 23);
            this.removeDataTypeNameButton.TabIndex = 11;
            this.removeDataTypeNameButton.Text = "Удалить";
            this.removeDataTypeNameButton.UseVisualStyleBackColor = true;
            this.removeDataTypeNameButton.Click += new System.EventHandler(this.OnClickRemoveDataTypeNameButton);
            // 
            // addDataTypeNameButton
            // 
            this.addDataTypeNameButton.Location = new System.Drawing.Point(6, 58);
            this.addDataTypeNameButton.Name = "addDataTypeNameButton";
            this.addDataTypeNameButton.Size = new System.Drawing.Size(75, 23);
            this.addDataTypeNameButton.TabIndex = 10;
            this.addDataTypeNameButton.Text = "Добавить";
            this.addDataTypeNameButton.UseVisualStyleBackColor = true;
            this.addDataTypeNameButton.Click += new System.EventHandler(this.OnClickAddDataTypeNameButton);
            // 
            // dataTypeNameTextBox
            // 
            this.dataTypeNameTextBox.Location = new System.Drawing.Point(6, 32);
            this.dataTypeNameTextBox.Name = "dataTypeNameTextBox";
            this.dataTypeNameTextBox.Size = new System.Drawing.Size(326, 20);
            this.dataTypeNameTextBox.TabIndex = 9;
            // 
            // dataTypeNameLabel
            // 
            this.dataTypeNameLabel.AutoSize = true;
            this.dataTypeNameLabel.Location = new System.Drawing.Point(6, 16);
            this.dataTypeNameLabel.Name = "dataTypeNameLabel";
            this.dataTypeNameLabel.Size = new System.Drawing.Size(152, 13);
            this.dataTypeNameLabel.TabIndex = 8;
            this.dataTypeNameLabel.Text = "Наименование типа данных:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 163);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Наименование триггера";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.postfixRandomNumberCountTextBox);
            this.groupBox5.Controls.Add(this.postfixRandomNumberCountLabel);
            this.groupBox5.Controls.Add(this.postfixTypeLabel);
            this.groupBox5.Controls.Add(this.postfixTypeComboBox);
            this.groupBox5.Controls.Add(this.postfixTextTextBox);
            this.groupBox5.Controls.Add(this.postfixTextLabel);
            this.groupBox5.Location = new System.Drawing.Point(350, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(338, 138);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Постфикс";
            // 
            // postfixRandomNumberCountTextBox
            // 
            this.postfixRandomNumberCountTextBox.Location = new System.Drawing.Point(6, 111);
            this.postfixRandomNumberCountTextBox.Name = "postfixRandomNumberCountTextBox";
            this.postfixRandomNumberCountTextBox.Size = new System.Drawing.Size(326, 20);
            this.postfixRandomNumberCountTextBox.TabIndex = 6;
            // 
            // postfixRandomNumberCountLabel
            // 
            this.postfixRandomNumberCountLabel.AutoSize = true;
            this.postfixRandomNumberCountLabel.Location = new System.Drawing.Point(6, 95);
            this.postfixRandomNumberCountLabel.Name = "postfixRandomNumberCountLabel";
            this.postfixRandomNumberCountLabel.Size = new System.Drawing.Size(270, 13);
            this.postfixRandomNumberCountLabel.TabIndex = 8;
            this.postfixRandomNumberCountLabel.Text = "Количество чисел при генерации случайного числа:";
            // 
            // postfixTypeLabel
            // 
            this.postfixTypeLabel.AutoSize = true;
            this.postfixTypeLabel.Location = new System.Drawing.Point(6, 16);
            this.postfixTypeLabel.Name = "postfixTypeLabel";
            this.postfixTypeLabel.Size = new System.Drawing.Size(87, 13);
            this.postfixTypeLabel.TabIndex = 4;
            this.postfixTypeLabel.Text = "Тип постфикса:";
            // 
            // postfixTypeComboBox
            // 
            this.postfixTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.postfixTypeComboBox.FormattingEnabled = true;
            this.postfixTypeComboBox.Location = new System.Drawing.Point(6, 32);
            this.postfixTypeComboBox.Name = "postfixTypeComboBox";
            this.postfixTypeComboBox.Size = new System.Drawing.Size(326, 21);
            this.postfixTypeComboBox.TabIndex = 5;
            this.postfixTypeComboBox.SelectedValueChanged += new System.EventHandler(this.OnChangePostfixTypeComboBox);
            // 
            // postfixTextTextBox
            // 
            this.postfixTextTextBox.Enabled = false;
            this.postfixTextTextBox.Location = new System.Drawing.Point(6, 72);
            this.postfixTextTextBox.Name = "postfixTextTextBox";
            this.postfixTextTextBox.Size = new System.Drawing.Size(326, 20);
            this.postfixTextTextBox.TabIndex = 7;
            // 
            // postfixTextLabel
            // 
            this.postfixTextLabel.AutoSize = true;
            this.postfixTextLabel.Location = new System.Drawing.Point(6, 56);
            this.postfixTextLabel.Name = "postfixTextLabel";
            this.postfixTextLabel.Size = new System.Drawing.Size(98, 13);
            this.postfixTextLabel.TabIndex = 6;
            this.postfixTextLabel.Text = "Текст постфикса:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.prefixRandomNumberCountTextBox);
            this.groupBox2.Controls.Add(this.prefixRandomNumberCountLabel);
            this.groupBox2.Controls.Add(this.prefixTypeLabel);
            this.groupBox2.Controls.Add(this.prefixTypeComboBox);
            this.groupBox2.Controls.Add(this.prefixTextLabel);
            this.groupBox2.Controls.Add(this.prefixTextTextBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 138);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Префикс";
            // 
            // prefixRandomNumberCountTextBox
            // 
            this.prefixRandomNumberCountTextBox.Location = new System.Drawing.Point(6, 111);
            this.prefixRandomNumberCountTextBox.Name = "prefixRandomNumberCountTextBox";
            this.prefixRandomNumberCountTextBox.Size = new System.Drawing.Size(326, 20);
            this.prefixRandomNumberCountTextBox.TabIndex = 5;
            // 
            // prefixRandomNumberCountLabel
            // 
            this.prefixRandomNumberCountLabel.AutoSize = true;
            this.prefixRandomNumberCountLabel.Location = new System.Drawing.Point(6, 95);
            this.prefixRandomNumberCountLabel.Name = "prefixRandomNumberCountLabel";
            this.prefixRandomNumberCountLabel.Size = new System.Drawing.Size(270, 13);
            this.prefixRandomNumberCountLabel.TabIndex = 4;
            this.prefixRandomNumberCountLabel.Text = "Количество чисел при генерации случайного числа:";
            // 
            // prefixTypeLabel
            // 
            this.prefixTypeLabel.AutoSize = true;
            this.prefixTypeLabel.Location = new System.Drawing.Point(6, 16);
            this.prefixTypeLabel.Name = "prefixTypeLabel";
            this.prefixTypeLabel.Size = new System.Drawing.Size(82, 13);
            this.prefixTypeLabel.TabIndex = 2;
            this.prefixTypeLabel.Text = "Тип префикса:";
            // 
            // prefixTypeComboBox
            // 
            this.prefixTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prefixTypeComboBox.FormattingEnabled = true;
            this.prefixTypeComboBox.Location = new System.Drawing.Point(6, 32);
            this.prefixTypeComboBox.Name = "prefixTypeComboBox";
            this.prefixTypeComboBox.Size = new System.Drawing.Size(326, 21);
            this.prefixTypeComboBox.TabIndex = 3;
            this.prefixTypeComboBox.SelectedValueChanged += new System.EventHandler(this.OnChangePrefixTypeComboBox);
            // 
            // prefixTextLabel
            // 
            this.prefixTextLabel.AutoSize = true;
            this.prefixTextLabel.Location = new System.Drawing.Point(6, 56);
            this.prefixTextLabel.Name = "prefixTextLabel";
            this.prefixTextLabel.Size = new System.Drawing.Size(93, 13);
            this.prefixTextLabel.TabIndex = 0;
            this.prefixTextLabel.Text = "Текст префикса:";
            // 
            // prefixTextTextBox
            // 
            this.prefixTextTextBox.Enabled = false;
            this.prefixTextTextBox.Location = new System.Drawing.Point(6, 72);
            this.prefixTextTextBox.Name = "prefixTextTextBox";
            this.prefixTextTextBox.Size = new System.Drawing.Size(326, 20);
            this.prefixTextTextBox.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rowDataDisableCheckBox);
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Location = new System.Drawing.Point(12, 181);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(694, 250);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Логируемые данные";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // rowDataDisableCheckBox
            // 
            this.rowDataDisableCheckBox.AutoSize = true;
            this.rowDataDisableCheckBox.Location = new System.Drawing.Point(7, 20);
            this.rowDataDisableCheckBox.Name = "rowDataDisableCheckBox";
            this.rowDataDisableCheckBox.Size = new System.Drawing.Size(227, 17);
            this.rowDataDisableCheckBox.TabIndex = 8;
            this.rowDataDisableCheckBox.Text = "Отключить логирование данных строки";
            this.rowDataDisableCheckBox.UseVisualStyleBackColor = true;
            this.rowDataDisableCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChangedRowDataDisableCheckBox);
            // 
            // LogTriggerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 473);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogTriggerSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LogCreator - Настройка триггера для логирования изменений";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label ignoreColumnNamesLabel;
        private System.Windows.Forms.ListBox ignoreColumnNamesListBox;
        private System.Windows.Forms.Button removeColumnNameButton;
        private System.Windows.Forms.Button addColumnNameButton;
        private System.Windows.Forms.TextBox columnNameTextBox;
        private System.Windows.Forms.Label columnNameLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label ignoreDataTypeNamesLabel;
        private System.Windows.Forms.ListBox ignoreDataTypeNamesListBox;
        private System.Windows.Forms.Button removeDataTypeNameButton;
        private System.Windows.Forms.Button addDataTypeNameButton;
        private System.Windows.Forms.TextBox dataTypeNameTextBox;
        private System.Windows.Forms.Label dataTypeNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox prefixTypeComboBox;
        private System.Windows.Forms.Label prefixTypeLabel;
        private System.Windows.Forms.TextBox prefixTextTextBox;
        private System.Windows.Forms.Label prefixTextLabel;
        private System.Windows.Forms.TextBox postfixTextTextBox;
        private System.Windows.Forms.Label postfixTextLabel;
        private System.Windows.Forms.ComboBox postfixTypeComboBox;
        private System.Windows.Forms.Label postfixTypeLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label prefixRandomNumberCountLabel;
        private System.Windows.Forms.TextBox postfixRandomNumberCountTextBox;
        private System.Windows.Forms.Label postfixRandomNumberCountLabel;
        private System.Windows.Forms.TextBox prefixRandomNumberCountTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox rowDataDisableCheckBox;
    }
}