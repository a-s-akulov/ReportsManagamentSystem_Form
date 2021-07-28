namespace ReportsManagementSystemForm
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ReportsManagement_Button = new System.Windows.Forms.Button();
            this.UsersManagement_Button = new System.Windows.Forms.Button();
            this.DirectoryManagement_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ReportsManagement_Button, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UsersManagement_Button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DirectoryManagement_Button, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(30);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 256);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ReportsManagement_Button
            // 
            this.ReportsManagement_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportsManagement_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportsManagement_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ReportsManagement_Button.Location = new System.Drawing.Point(33, 33);
            this.ReportsManagement_Button.Name = "ReportsManagement_Button";
            this.ReportsManagement_Button.Size = new System.Drawing.Size(418, 40);
            this.ReportsManagement_Button.TabIndex = 0;
            this.ReportsManagement_Button.Text = "Управление отчётами и их загрузка";
            this.ReportsManagement_Button.UseVisualStyleBackColor = true;
            this.ReportsManagement_Button.Click += new System.EventHandler(this.ReportsManagement_Button_Click);
            // 
            // UsersManagement_Button
            // 
            this.UsersManagement_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersManagement_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersManagement_Button.Location = new System.Drawing.Point(33, 106);
            this.UsersManagement_Button.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.UsersManagement_Button.Name = "UsersManagement_Button";
            this.UsersManagement_Button.Size = new System.Drawing.Size(418, 40);
            this.UsersManagement_Button.TabIndex = 1;
            this.UsersManagement_Button.Text = "Управление пользователями";
            this.UsersManagement_Button.UseVisualStyleBackColor = true;
            this.UsersManagement_Button.Click += new System.EventHandler(this.UsersManagement_Button_Click);
            // 
            // DirectoryManagement_Button
            // 
            this.DirectoryManagement_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryManagement_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DirectoryManagement_Button.Location = new System.Drawing.Point(33, 179);
            this.DirectoryManagement_Button.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.DirectoryManagement_Button.Name = "DirectoryManagement_Button";
            this.DirectoryManagement_Button.Size = new System.Drawing.Size(418, 40);
            this.DirectoryManagement_Button.TabIndex = 2;
            this.DirectoryManagement_Button.Text = "Управление справочником";
            this.DirectoryManagement_Button.UseVisualStyleBackColor = true;
            this.DirectoryManagement_Button.Click += new System.EventHandler(this.DirectoryManagement_Button_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 271);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню системы управления отчетами";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainMenu_HelpButtonClicked);
            this.VisibleChanged += new System.EventHandler(this.MainMenu_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ReportsManagement_Button;
        private System.Windows.Forms.Button UsersManagement_Button;
        private System.Windows.Forms.Button DirectoryManagement_Button;
    }
}

