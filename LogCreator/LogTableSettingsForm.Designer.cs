namespace LogCreator
{
    partial class LogTableSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogTableSettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rowDataColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.rowDataColumnNameLabel = new System.Windows.Forms.Label();
            this.primaryKeyColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.primaryKeyColumnNameLabel = new System.Windows.Forms.Label();
            this.userNameColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameColumnNameLabel = new System.Windows.Forms.Label();
            this.eventDateColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.eventDateColumnNameLabel = new System.Windows.Forms.Label();
            this.tableNameColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.tableNameColumnNameLabel = new System.Windows.Forms.Label();
            this.eventTypeColumnNameTextBox = new System.Windows.Forms.TextBox();
            this.eventTypeColumnNameLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logTableNameLabel = new System.Windows.Forms.Label();
            this.logTableNameTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rowDataColumnNameTextBox);
            this.groupBox1.Controls.Add(this.rowDataColumnNameLabel);
            this.groupBox1.Controls.Add(this.primaryKeyColumnNameTextBox);
            this.groupBox1.Controls.Add(this.primaryKeyColumnNameLabel);
            this.groupBox1.Controls.Add(this.userNameColumnNameTextBox);
            this.groupBox1.Controls.Add(this.userNameColumnNameLabel);
            this.groupBox1.Controls.Add(this.eventDateColumnNameTextBox);
            this.groupBox1.Controls.Add(this.eventDateColumnNameLabel);
            this.groupBox1.Controls.Add(this.tableNameColumnNameTextBox);
            this.groupBox1.Controls.Add(this.tableNameColumnNameLabel);
            this.groupBox1.Controls.Add(this.eventTypeColumnNameTextBox);
            this.groupBox1.Controls.Add(this.eventTypeColumnNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 256);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Наименование столбцов";
            // 
            // rowDataColumnNameTextBox
            // 
            this.rowDataColumnNameTextBox.Location = new System.Drawing.Point(6, 227);
            this.rowDataColumnNameTextBox.Name = "rowDataColumnNameTextBox";
            this.rowDataColumnNameTextBox.Size = new System.Drawing.Size(338, 20);
            this.rowDataColumnNameTextBox.TabIndex = 15;
            // 
            // rowDataColumnNameLabel
            // 
            this.rowDataColumnNameLabel.AutoSize = true;
            this.rowDataColumnNameLabel.Location = new System.Drawing.Point(6, 211);
            this.rowDataColumnNameLabel.Name = "rowDataColumnNameLabel";
            this.rowDataColumnNameLabel.Size = new System.Drawing.Size(89, 13);
            this.rowDataColumnNameLabel.TabIndex = 14;
            this.rowDataColumnNameLabel.Text = "Данные строки:";
            // 
            // primaryKeyColumnNameTextBox
            // 
            this.primaryKeyColumnNameTextBox.Location = new System.Drawing.Point(6, 188);
            this.primaryKeyColumnNameTextBox.Name = "primaryKeyColumnNameTextBox";
            this.primaryKeyColumnNameTextBox.Size = new System.Drawing.Size(338, 20);
            this.primaryKeyColumnNameTextBox.TabIndex = 13;
            // 
            // primaryKeyColumnNameLabel
            // 
            this.primaryKeyColumnNameLabel.AutoSize = true;
            this.primaryKeyColumnNameLabel.Location = new System.Drawing.Point(6, 172);
            this.primaryKeyColumnNameLabel.Name = "primaryKeyColumnNameLabel";
            this.primaryKeyColumnNameLabel.Size = new System.Drawing.Size(153, 13);
            this.primaryKeyColumnNameLabel.TabIndex = 12;
            this.primaryKeyColumnNameLabel.Text = "Значение первичного ключа:";
            // 
            // userNameColumnNameTextBox
            // 
            this.userNameColumnNameTextBox.Location = new System.Drawing.Point(6, 149);
            this.userNameColumnNameTextBox.Name = "userNameColumnNameTextBox";
            this.userNameColumnNameTextBox.Size = new System.Drawing.Size(338, 20);
            this.userNameColumnNameTextBox.TabIndex = 11;
            // 
            // userNameColumnNameLabel
            // 
            this.userNameColumnNameLabel.AutoSize = true;
            this.userNameColumnNameLabel.Location = new System.Drawing.Point(6, 133);
            this.userNameColumnNameLabel.Name = "userNameColumnNameLabel";
            this.userNameColumnNameLabel.Size = new System.Drawing.Size(106, 13);
            this.userNameColumnNameLabel.TabIndex = 10;
            this.userNameColumnNameLabel.Text = "Имя пользователя:";
            // 
            // eventDateColumnNameTextBox
            // 
            this.eventDateColumnNameTextBox.Location = new System.Drawing.Point(6, 110);
            this.eventDateColumnNameTextBox.Name = "eventDateColumnNameTextBox";
            this.eventDateColumnNameTextBox.Size = new System.Drawing.Size(338, 20);
            this.eventDateColumnNameTextBox.TabIndex = 9;
            // 
            // eventDateColumnNameLabel
            // 
            this.eventDateColumnNameLabel.AutoSize = true;
            this.eventDateColumnNameLabel.Location = new System.Drawing.Point(6, 94);
            this.eventDateColumnNameLabel.Name = "eventDateColumnNameLabel";
            this.eventDateColumnNameLabel.Size = new System.Drawing.Size(82, 13);
            this.eventDateColumnNameLabel.TabIndex = 8;
            this.eventDateColumnNameLabel.Text = "Дата события:";
            // 
            // tableNameColumnNameTextBox
            // 
            this.tableNameColumnNameTextBox.Location = new System.Drawing.Point(6, 71);
            this.tableNameColumnNameTextBox.Name = "tableNameColumnNameTextBox";
            this.tableNameColumnNameTextBox.Size = new System.Drawing.Size(338, 20);
            this.tableNameColumnNameTextBox.TabIndex = 7;
            // 
            // tableNameColumnNameLabel
            // 
            this.tableNameColumnNameLabel.AutoSize = true;
            this.tableNameColumnNameLabel.Location = new System.Drawing.Point(6, 55);
            this.tableNameColumnNameLabel.Name = "tableNameColumnNameLabel";
            this.tableNameColumnNameLabel.Size = new System.Drawing.Size(106, 13);
            this.tableNameColumnNameLabel.TabIndex = 6;
            this.tableNameColumnNameLabel.Text = "Название таблицы:";
            // 
            // eventTypeColumnNameTextBox
            // 
            this.eventTypeColumnNameTextBox.Location = new System.Drawing.Point(6, 32);
            this.eventTypeColumnNameTextBox.Name = "eventTypeColumnNameTextBox";
            this.eventTypeColumnNameTextBox.Size = new System.Drawing.Size(338, 20);
            this.eventTypeColumnNameTextBox.TabIndex = 5;
            // 
            // eventTypeColumnNameLabel
            // 
            this.eventTypeColumnNameLabel.AutoSize = true;
            this.eventTypeColumnNameLabel.Location = new System.Drawing.Point(6, 16);
            this.eventTypeColumnNameLabel.Name = "eventTypeColumnNameLabel";
            this.eventTypeColumnNameLabel.Size = new System.Drawing.Size(75, 13);
            this.eventTypeColumnNameLabel.TabIndex = 4;
            this.eventTypeColumnNameLabel.Text = "Тип события:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(287, 342);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnClickSaveButton);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(206, 342);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnClickCancelButton);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.logTableNameLabel);
            this.groupBox2.Controls.Add(this.logTableNameTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 61);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Наименование таблицы";
            // 
            // logTableNameLabel
            // 
            this.logTableNameLabel.AutoSize = true;
            this.logTableNameLabel.Location = new System.Drawing.Point(6, 16);
            this.logTableNameLabel.Name = "logTableNameLabel";
            this.logTableNameLabel.Size = new System.Drawing.Size(132, 13);
            this.logTableNameLabel.TabIndex = 1;
            this.logTableNameLabel.Text = "Наименование таблицы:";
            // 
            // logTableNameTextBox
            // 
            this.logTableNameTextBox.Location = new System.Drawing.Point(6, 32);
            this.logTableNameTextBox.Name = "logTableNameTextBox";
            this.logTableNameTextBox.Size = new System.Drawing.Size(338, 20);
            this.logTableNameTextBox.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // LogTableSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 379);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogTableSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LogCreator - Настройка таблицы с логами";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox eventTypeColumnNameTextBox;
        private System.Windows.Forms.Label eventTypeColumnNameLabel;
        private System.Windows.Forms.TextBox tableNameColumnNameTextBox;
        private System.Windows.Forms.Label tableNameColumnNameLabel;
        private System.Windows.Forms.TextBox eventDateColumnNameTextBox;
        private System.Windows.Forms.Label eventDateColumnNameLabel;
        private System.Windows.Forms.TextBox userNameColumnNameTextBox;
        private System.Windows.Forms.Label userNameColumnNameLabel;
        private System.Windows.Forms.TextBox primaryKeyColumnNameTextBox;
        private System.Windows.Forms.Label primaryKeyColumnNameLabel;
        private System.Windows.Forms.TextBox rowDataColumnNameTextBox;
        private System.Windows.Forms.Label rowDataColumnNameLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label logTableNameLabel;
        private System.Windows.Forms.TextBox logTableNameTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}