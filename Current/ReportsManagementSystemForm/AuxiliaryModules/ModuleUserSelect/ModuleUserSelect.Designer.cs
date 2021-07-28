namespace ReportsManagementSystemForm
{
    partial class ModuleUserSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleUserSelect));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Accept_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Search_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SearchCriteria_department_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_name_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_nameDomain_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_nameDomain_TextBox = new System.Windows.Forms.TextBox();
            this.SearchCriteria_name_TextBox = new System.Windows.Forms.TextBox();
            this.SearchCriteria_department_ComboBox = new System.Windows.Forms.ComboBox();
            this.Users_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Users_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Users_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Users_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Search_Button, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Users_GridControl, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 337);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Accept_Button, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Cancel_Button, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 307);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(960, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Accept_Button
            // 
            this.Accept_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Accept_Button.AutoSize = true;
            this.Accept_Button.Location = new System.Drawing.Point(839, 3);
            this.Accept_Button.Name = "Accept_Button";
            this.Accept_Button.Size = new System.Drawing.Size(118, 23);
            this.Accept_Button.TabIndex = 0;
            this.Accept_Button.Text = "Подтвердить выбор";
            this.Accept_Button.UseVisualStyleBackColor = true;
            this.Accept_Button.Click += new System.EventHandler(this.Accept_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(3, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Отмена";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Сancel_Button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Критерии поиска:";
            // 
            // Search_Button
            // 
            this.Search_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_Button.AutoSize = true;
            this.Search_Button.Location = new System.Drawing.Point(882, 123);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(75, 23);
            this.Search_Button.TabIndex = 3;
            this.Search_Button.Text = "Поиск";
            this.Search_Button.UseVisualStyleBackColor = true;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_department_CheckBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_name_CheckBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_nameDomain_CheckBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_nameDomain_TextBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_name_TextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_department_ComboBox, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(960, 90);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // SearchCriteria_department_CheckBox
            // 
            this.SearchCriteria_department_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_department_CheckBox.AutoSize = true;
            this.SearchCriteria_department_CheckBox.Checked = true;
            this.SearchCriteria_department_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SearchCriteria_department_CheckBox.Location = new System.Drawing.Point(3, 6);
            this.SearchCriteria_department_CheckBox.Name = "SearchCriteria_department_CheckBox";
            this.SearchCriteria_department_CheckBox.Size = new System.Drawing.Size(57, 17);
            this.SearchCriteria_department_CheckBox.TabIndex = 0;
            this.SearchCriteria_department_CheckBox.Text = "Отдел";
            this.SearchCriteria_department_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_department_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_department_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_name_CheckBox
            // 
            this.SearchCriteria_name_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_name_CheckBox.AutoSize = true;
            this.SearchCriteria_name_CheckBox.Checked = true;
            this.SearchCriteria_name_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SearchCriteria_name_CheckBox.Location = new System.Drawing.Point(3, 35);
            this.SearchCriteria_name_CheckBox.Name = "SearchCriteria_name_CheckBox";
            this.SearchCriteria_name_CheckBox.Size = new System.Drawing.Size(80, 17);
            this.SearchCriteria_name_CheckBox.TabIndex = 0;
            this.SearchCriteria_name_CheckBox.Text = "Имя (LIKE)";
            this.SearchCriteria_name_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_name_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_name_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_nameDomain_CheckBox
            // 
            this.SearchCriteria_nameDomain_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_nameDomain_CheckBox.AutoSize = true;
            this.SearchCriteria_nameDomain_CheckBox.Location = new System.Drawing.Point(3, 65);
            this.SearchCriteria_nameDomain_CheckBox.Name = "SearchCriteria_nameDomain_CheckBox";
            this.SearchCriteria_nameDomain_CheckBox.Size = new System.Drawing.Size(134, 17);
            this.SearchCriteria_nameDomain_CheckBox.TabIndex = 0;
            this.SearchCriteria_nameDomain_CheckBox.Text = "Доменное имя (LIKE)";
            this.SearchCriteria_nameDomain_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_nameDomain_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_nameDomain_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_nameDomain_TextBox
            // 
            this.SearchCriteria_nameDomain_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteria_nameDomain_TextBox.Enabled = false;
            this.SearchCriteria_nameDomain_TextBox.Location = new System.Drawing.Point(143, 64);
            this.SearchCriteria_nameDomain_TextBox.Name = "SearchCriteria_nameDomain_TextBox";
            this.SearchCriteria_nameDomain_TextBox.Size = new System.Drawing.Size(814, 20);
            this.SearchCriteria_nameDomain_TextBox.TabIndex = 1;
            this.SearchCriteria_nameDomain_TextBox.Text = "BOOKCENTRE\\%";
            // 
            // SearchCriteria_name_TextBox
            // 
            this.SearchCriteria_name_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteria_name_TextBox.Location = new System.Drawing.Point(143, 33);
            this.SearchCriteria_name_TextBox.Name = "SearchCriteria_name_TextBox";
            this.SearchCriteria_name_TextBox.Size = new System.Drawing.Size(814, 20);
            this.SearchCriteria_name_TextBox.TabIndex = 1;
            this.SearchCriteria_name_TextBox.Text = "%";
            // 
            // SearchCriteria_department_ComboBox
            // 
            this.SearchCriteria_department_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteria_department_ComboBox.FormattingEnabled = true;
            this.SearchCriteria_department_ComboBox.Location = new System.Drawing.Point(143, 4);
            this.SearchCriteria_department_ComboBox.Name = "SearchCriteria_department_ComboBox";
            this.SearchCriteria_department_ComboBox.Size = new System.Drawing.Size(814, 21);
            this.SearchCriteria_department_ComboBox.TabIndex = 2;
            // 
            // Users_GridControl
            // 
            this.Users_GridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Users_GridControl.Location = new System.Drawing.Point(3, 153);
            this.Users_GridControl.LookAndFeel.SkinName = "Office 2010 Blue";
            this.Users_GridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Users_GridControl.MainView = this.Users_GridView;
            this.Users_GridControl.Name = "Users_GridControl";
            this.Users_GridControl.Size = new System.Drawing.Size(954, 151);
            this.Users_GridControl.TabIndex = 5;
            this.Users_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Users_GridView});
            // 
            // Users_GridView
            // 
            this.Users_GridView.GridControl = this.Users_GridControl;
            this.Users_GridView.Name = "Users_GridView";
            this.Users_GridView.OptionsBehavior.Editable = false;
            this.Users_GridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Users_GridView_KeyDown);
            this.Users_GridView.DoubleClick += new System.EventHandler(this.Users_GridView_DoubleClick);
            // 
            // ModuleUserSelect
            // 
            this.AcceptButton = this.Accept_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(984, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 400);
            this.Name = "ModuleUserSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбрать пользователя(ей)";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Users_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Users_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Accept_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox SearchCriteria_department_CheckBox;
        private System.Windows.Forms.CheckBox SearchCriteria_name_CheckBox;
        private System.Windows.Forms.CheckBox SearchCriteria_nameDomain_CheckBox;
        private System.Windows.Forms.TextBox SearchCriteria_nameDomain_TextBox;
        private System.Windows.Forms.TextBox SearchCriteria_name_TextBox;
        private System.Windows.Forms.ComboBox SearchCriteria_department_ComboBox;
        public DevExpress.XtraGrid.GridControl Users_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Users_GridView;
        private System.Windows.Forms.Button Cancel_Button;
    }
}