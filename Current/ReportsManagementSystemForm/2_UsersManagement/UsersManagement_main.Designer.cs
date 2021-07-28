namespace ReportsManagementSystemForm
{
    partial class UsersManagement_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersManagement_main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Add_Button = new System.Windows.Forms.Button();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchCriteria_userIds_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_name_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_nameDomain_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_email_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_department_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_status_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_generalPermissions_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_dateCreated_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_dateChanged_CheckBox = new System.Windows.Forms.CheckBox();
            this.Search_Button = new System.Windows.Forms.Button();
            this.SearchCriteria_userIds_TextBox = new System.Windows.Forms.TextBox();
            this.SearchCriteria_name_TextBox = new System.Windows.Forms.TextBox();
            this.SearchCriteria_nameDomain_TextBox = new System.Windows.Forms.TextBox();
            this.SearchCriteria_email_TextBox = new System.Windows.Forms.TextBox();
            this.SearchCriteria_department_ComboBox = new System.Windows.Forms.ComboBox();
            this.SearchCriteria_status_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SearchCriteria_status_notActive_RadioButton = new System.Windows.Forms.RadioButton();
            this.SearchCriteria_status_active_RadioButton = new System.Windows.Forms.RadioButton();
            this.SearchCriteria_generalPermissions_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox = new System.Windows.Forms.CheckBox();
            this.SearchCriteria_dateCreated_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchCriteria_dateCreated_from_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SearchCriteria_dateCreated_to_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SearchCriteria_dateChanged_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchCriteria_dateChanged_from_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SearchCriteria_dateChanged_to_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Show_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Show_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SearchCriteria_status_TableLayoutPanel.SuspendLayout();
            this.SearchCriteria_generalPermissions_TableLayoutPanel.SuspendLayout();
            this.SearchCriteria_dateCreated_TableLayoutPanel.SuspendLayout();
            this.SearchCriteria_dateChanged_TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Show_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Show_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Show_GridControl, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 687);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.Add_Button, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Edit_Button, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(644, 655);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(359, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Add_Button
            // 
            this.Add_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Button.AutoSize = true;
            this.Add_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Add_Button.Location = new System.Drawing.Point(215, 3);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(141, 23);
            this.Add_Button.TabIndex = 0;
            this.Add_Button.Text = "Добавить пользователя";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_Button.AutoSize = true;
            this.Edit_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Edit_Button.Location = new System.Drawing.Point(3, 3);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(206, 23);
            this.Edit_Button.TabIndex = 1;
            this.Edit_Button.Text = "Изменить выбранного пользователя";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_userIds_CheckBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_name_CheckBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_nameDomain_CheckBox, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_email_CheckBox, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_department_CheckBox, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_status_CheckBox, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_generalPermissions_CheckBox, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_dateCreated_CheckBox, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_dateChanged_CheckBox, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.Search_Button, 1, 10);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_userIds_TextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_name_TextBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_nameDomain_TextBox, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_email_TextBox, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_department_ComboBox, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_status_TableLayoutPanel, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_generalPermissions_TableLayoutPanel, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_dateCreated_TableLayoutPanel, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.SearchCriteria_dateChanged_TableLayoutPanel, 1, 9);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 11;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1003, 295);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Критерии поиска:";
            // 
            // SearchCriteria_userIds_CheckBox
            // 
            this.SearchCriteria_userIds_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_userIds_CheckBox.AutoSize = true;
            this.SearchCriteria_userIds_CheckBox.Location = new System.Drawing.Point(3, 17);
            this.SearchCriteria_userIds_CheckBox.Name = "SearchCriteria_userIds_CheckBox";
            this.SearchCriteria_userIds_CheckBox.Size = new System.Drawing.Size(202, 17);
            this.SearchCriteria_userIds_CheckBox.TabIndex = 1;
            this.SearchCriteria_userIds_CheckBox.Text = "ID Пользователей (через запятую)";
            this.SearchCriteria_userIds_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_userIds_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_userIds_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_name_CheckBox
            // 
            this.SearchCriteria_name_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_name_CheckBox.AutoSize = true;
            this.SearchCriteria_name_CheckBox.Checked = true;
            this.SearchCriteria_name_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SearchCriteria_name_CheckBox.Location = new System.Drawing.Point(3, 43);
            this.SearchCriteria_name_CheckBox.Name = "SearchCriteria_name_CheckBox";
            this.SearchCriteria_name_CheckBox.Size = new System.Drawing.Size(80, 17);
            this.SearchCriteria_name_CheckBox.TabIndex = 1;
            this.SearchCriteria_name_CheckBox.Text = "Имя (LIKE)";
            this.SearchCriteria_name_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_name_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_name_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_nameDomain_CheckBox
            // 
            this.SearchCriteria_nameDomain_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_nameDomain_CheckBox.AutoSize = true;
            this.SearchCriteria_nameDomain_CheckBox.Location = new System.Drawing.Point(3, 69);
            this.SearchCriteria_nameDomain_CheckBox.Name = "SearchCriteria_nameDomain_CheckBox";
            this.SearchCriteria_nameDomain_CheckBox.Size = new System.Drawing.Size(134, 17);
            this.SearchCriteria_nameDomain_CheckBox.TabIndex = 1;
            this.SearchCriteria_nameDomain_CheckBox.Text = "Доменное имя (LIKE)";
            this.SearchCriteria_nameDomain_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_nameDomain_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_nameDomain_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_email_CheckBox
            // 
            this.SearchCriteria_email_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_email_CheckBox.AutoSize = true;
            this.SearchCriteria_email_CheckBox.Location = new System.Drawing.Point(3, 95);
            this.SearchCriteria_email_CheckBox.Name = "SearchCriteria_email_CheckBox";
            this.SearchCriteria_email_CheckBox.Size = new System.Drawing.Size(87, 17);
            this.SearchCriteria_email_CheckBox.TabIndex = 1;
            this.SearchCriteria_email_CheckBox.Text = "E-Mail (LIKE)";
            this.SearchCriteria_email_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_email_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_email_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_department_CheckBox
            // 
            this.SearchCriteria_department_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_department_CheckBox.AutoSize = true;
            this.SearchCriteria_department_CheckBox.Location = new System.Drawing.Point(3, 122);
            this.SearchCriteria_department_CheckBox.Name = "SearchCriteria_department_CheckBox";
            this.SearchCriteria_department_CheckBox.Size = new System.Drawing.Size(57, 17);
            this.SearchCriteria_department_CheckBox.TabIndex = 1;
            this.SearchCriteria_department_CheckBox.Text = "Отдел";
            this.SearchCriteria_department_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_department_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_department_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_status_CheckBox
            // 
            this.SearchCriteria_status_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_status_CheckBox.AutoSize = true;
            this.SearchCriteria_status_CheckBox.Checked = true;
            this.SearchCriteria_status_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SearchCriteria_status_CheckBox.Location = new System.Drawing.Point(3, 150);
            this.SearchCriteria_status_CheckBox.Name = "SearchCriteria_status_CheckBox";
            this.SearchCriteria_status_CheckBox.Size = new System.Drawing.Size(60, 17);
            this.SearchCriteria_status_CheckBox.TabIndex = 1;
            this.SearchCriteria_status_CheckBox.Text = "Статус";
            this.SearchCriteria_status_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_status_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_status_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_generalPermissions_CheckBox
            // 
            this.SearchCriteria_generalPermissions_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_generalPermissions_CheckBox.AutoSize = true;
            this.SearchCriteria_generalPermissions_CheckBox.Location = new System.Drawing.Point(3, 179);
            this.SearchCriteria_generalPermissions_CheckBox.Name = "SearchCriteria_generalPermissions_CheckBox";
            this.SearchCriteria_generalPermissions_CheckBox.Size = new System.Drawing.Size(126, 17);
            this.SearchCriteria_generalPermissions_CheckBox.TabIndex = 1;
            this.SearchCriteria_generalPermissions_CheckBox.Text = "Общие разрешения";
            this.SearchCriteria_generalPermissions_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_generalPermissions_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_generalPermissions_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_dateCreated_CheckBox
            // 
            this.SearchCriteria_dateCreated_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_dateCreated_CheckBox.AutoSize = true;
            this.SearchCriteria_dateCreated_CheckBox.Location = new System.Drawing.Point(3, 209);
            this.SearchCriteria_dateCreated_CheckBox.Name = "SearchCriteria_dateCreated_CheckBox";
            this.SearchCriteria_dateCreated_CheckBox.Size = new System.Drawing.Size(103, 17);
            this.SearchCriteria_dateCreated_CheckBox.TabIndex = 1;
            this.SearchCriteria_dateCreated_CheckBox.Text = "Дата создания";
            this.SearchCriteria_dateCreated_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_dateCreated_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_dateCreated_CheckBox_CheckedChanged);
            // 
            // SearchCriteria_dateChanged_CheckBox
            // 
            this.SearchCriteria_dateChanged_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_dateChanged_CheckBox.AutoSize = true;
            this.SearchCriteria_dateChanged_CheckBox.Location = new System.Drawing.Point(3, 241);
            this.SearchCriteria_dateChanged_CheckBox.Name = "SearchCriteria_dateChanged_CheckBox";
            this.SearchCriteria_dateChanged_CheckBox.Size = new System.Drawing.Size(111, 17);
            this.SearchCriteria_dateChanged_CheckBox.TabIndex = 1;
            this.SearchCriteria_dateChanged_CheckBox.Text = "Дата изменения";
            this.SearchCriteria_dateChanged_CheckBox.UseVisualStyleBackColor = true;
            this.SearchCriteria_dateChanged_CheckBox.CheckedChanged += new System.EventHandler(this.SearchCriteria_dateChanged_CheckBox_CheckedChanged);
            // 
            // Search_Button
            // 
            this.Search_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Search_Button.Location = new System.Drawing.Point(859, 269);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(141, 23);
            this.Search_Button.TabIndex = 2;
            this.Search_Button.Text = "Поиск";
            this.Search_Button.UseVisualStyleBackColor = true;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // SearchCriteria_userIds_TextBox
            // 
            this.SearchCriteria_userIds_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteria_userIds_TextBox.Enabled = false;
            this.SearchCriteria_userIds_TextBox.Location = new System.Drawing.Point(211, 16);
            this.SearchCriteria_userIds_TextBox.Name = "SearchCriteria_userIds_TextBox";
            this.SearchCriteria_userIds_TextBox.Size = new System.Drawing.Size(789, 20);
            this.SearchCriteria_userIds_TextBox.TabIndex = 3;
            // 
            // SearchCriteria_name_TextBox
            // 
            this.SearchCriteria_name_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteria_name_TextBox.Location = new System.Drawing.Point(211, 42);
            this.SearchCriteria_name_TextBox.Name = "SearchCriteria_name_TextBox";
            this.SearchCriteria_name_TextBox.Size = new System.Drawing.Size(789, 20);
            this.SearchCriteria_name_TextBox.TabIndex = 3;
            this.SearchCriteria_name_TextBox.Text = "%";
            // 
            // SearchCriteria_nameDomain_TextBox
            // 
            this.SearchCriteria_nameDomain_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteria_nameDomain_TextBox.Enabled = false;
            this.SearchCriteria_nameDomain_TextBox.Location = new System.Drawing.Point(211, 68);
            this.SearchCriteria_nameDomain_TextBox.Name = "SearchCriteria_nameDomain_TextBox";
            this.SearchCriteria_nameDomain_TextBox.Size = new System.Drawing.Size(789, 20);
            this.SearchCriteria_nameDomain_TextBox.TabIndex = 3;
            this.SearchCriteria_nameDomain_TextBox.Text = "BOOKCENTRE\\%";
            // 
            // SearchCriteria_email_TextBox
            // 
            this.SearchCriteria_email_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteria_email_TextBox.Enabled = false;
            this.SearchCriteria_email_TextBox.Location = new System.Drawing.Point(211, 94);
            this.SearchCriteria_email_TextBox.Name = "SearchCriteria_email_TextBox";
            this.SearchCriteria_email_TextBox.Size = new System.Drawing.Size(789, 20);
            this.SearchCriteria_email_TextBox.TabIndex = 3;
            this.SearchCriteria_email_TextBox.Text = "%@bookcentre.ru";
            // 
            // SearchCriteria_department_ComboBox
            // 
            this.SearchCriteria_department_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteria_department_ComboBox.Enabled = false;
            this.SearchCriteria_department_ComboBox.FormattingEnabled = true;
            this.SearchCriteria_department_ComboBox.Location = new System.Drawing.Point(211, 120);
            this.SearchCriteria_department_ComboBox.Name = "SearchCriteria_department_ComboBox";
            this.SearchCriteria_department_ComboBox.Size = new System.Drawing.Size(789, 21);
            this.SearchCriteria_department_ComboBox.TabIndex = 4;
            // 
            // SearchCriteria_status_TableLayoutPanel
            // 
            this.SearchCriteria_status_TableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_status_TableLayoutPanel.AutoSize = true;
            this.SearchCriteria_status_TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchCriteria_status_TableLayoutPanel.ColumnCount = 2;
            this.SearchCriteria_status_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchCriteria_status_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchCriteria_status_TableLayoutPanel.Controls.Add(this.SearchCriteria_status_notActive_RadioButton, 0, 0);
            this.SearchCriteria_status_TableLayoutPanel.Controls.Add(this.SearchCriteria_status_active_RadioButton, 1, 0);
            this.SearchCriteria_status_TableLayoutPanel.Location = new System.Drawing.Point(211, 147);
            this.SearchCriteria_status_TableLayoutPanel.Name = "SearchCriteria_status_TableLayoutPanel";
            this.SearchCriteria_status_TableLayoutPanel.RowCount = 1;
            this.SearchCriteria_status_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchCriteria_status_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.SearchCriteria_status_TableLayoutPanel.Size = new System.Drawing.Size(294, 23);
            this.SearchCriteria_status_TableLayoutPanel.TabIndex = 5;
            // 
            // SearchCriteria_status_notActive_RadioButton
            // 
            this.SearchCriteria_status_notActive_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_status_notActive_RadioButton.AutoSize = true;
            this.SearchCriteria_status_notActive_RadioButton.Location = new System.Drawing.Point(3, 3);
            this.SearchCriteria_status_notActive_RadioButton.Name = "SearchCriteria_status_notActive_RadioButton";
            this.SearchCriteria_status_notActive_RadioButton.Size = new System.Drawing.Size(141, 17);
            this.SearchCriteria_status_notActive_RadioButton.TabIndex = 0;
            this.SearchCriteria_status_notActive_RadioButton.TabStop = true;
            this.SearchCriteria_status_notActive_RadioButton.Text = "STATUS_NOT_ACTIVE";
            this.SearchCriteria_status_notActive_RadioButton.UseVisualStyleBackColor = true;
            // 
            // SearchCriteria_status_active_RadioButton
            // 
            this.SearchCriteria_status_active_RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_status_active_RadioButton.AutoSize = true;
            this.SearchCriteria_status_active_RadioButton.Checked = true;
            this.SearchCriteria_status_active_RadioButton.Location = new System.Drawing.Point(150, 3);
            this.SearchCriteria_status_active_RadioButton.Name = "SearchCriteria_status_active_RadioButton";
            this.SearchCriteria_status_active_RadioButton.Size = new System.Drawing.Size(112, 17);
            this.SearchCriteria_status_active_RadioButton.TabIndex = 1;
            this.SearchCriteria_status_active_RadioButton.TabStop = true;
            this.SearchCriteria_status_active_RadioButton.Text = "STATUS_ACTIVE";
            this.SearchCriteria_status_active_RadioButton.UseVisualStyleBackColor = true;
            // 
            // SearchCriteria_generalPermissions_TableLayoutPanel
            // 
            this.SearchCriteria_generalPermissions_TableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_generalPermissions_TableLayoutPanel.AutoSize = true;
            this.SearchCriteria_generalPermissions_TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchCriteria_generalPermissions_TableLayoutPanel.ColumnCount = 3;
            this.SearchCriteria_generalPermissions_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.SearchCriteria_generalPermissions_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.SearchCriteria_generalPermissions_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.SearchCriteria_generalPermissions_TableLayoutPanel.Controls.Add(this.SearchCriteria_generalPermissions_directoryManagement_CheckBox, 0, 0);
            this.SearchCriteria_generalPermissions_TableLayoutPanel.Controls.Add(this.SearchCriteria_generalPermissions_usersManagement_CheckBox, 1, 0);
            this.SearchCriteria_generalPermissions_TableLayoutPanel.Controls.Add(this.SearchCriteria_generalPermissions_reportsManagement_CheckBox, 2, 0);
            this.SearchCriteria_generalPermissions_TableLayoutPanel.Enabled = false;
            this.SearchCriteria_generalPermissions_TableLayoutPanel.Location = new System.Drawing.Point(211, 176);
            this.SearchCriteria_generalPermissions_TableLayoutPanel.Name = "SearchCriteria_generalPermissions_TableLayoutPanel";
            this.SearchCriteria_generalPermissions_TableLayoutPanel.RowCount = 1;
            this.SearchCriteria_generalPermissions_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SearchCriteria_generalPermissions_TableLayoutPanel.Size = new System.Drawing.Size(496, 23);
            this.SearchCriteria_generalPermissions_TableLayoutPanel.TabIndex = 6;
            // 
            // SearchCriteria_generalPermissions_directoryManagement_CheckBox
            // 
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox.AutoSize = true;
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox.Location = new System.Drawing.Point(3, 3);
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox.Name = "SearchCriteria_generalPermissions_directoryManagement_CheckBox";
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox.Size = new System.Drawing.Size(164, 17);
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox.TabIndex = 0;
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox.Text = "Управление справочником";
            this.SearchCriteria_generalPermissions_directoryManagement_CheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchCriteria_generalPermissions_usersManagement_CheckBox
            // 
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox.AutoSize = true;
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox.Location = new System.Drawing.Point(173, 3);
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox.Name = "SearchCriteria_generalPermissions_usersManagement_CheckBox";
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox.Size = new System.Drawing.Size(176, 17);
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox.TabIndex = 1;
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox.Text = "Управление пользователями";
            this.SearchCriteria_generalPermissions_usersManagement_CheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchCriteria_generalPermissions_reportsManagement_CheckBox
            // 
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox.AutoSize = true;
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox.Location = new System.Drawing.Point(355, 3);
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox.Name = "SearchCriteria_generalPermissions_reportsManagement_CheckBox";
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox.Size = new System.Drawing.Size(138, 17);
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox.TabIndex = 2;
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox.Text = "Управление отчётами";
            this.SearchCriteria_generalPermissions_reportsManagement_CheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchCriteria_dateCreated_TableLayoutPanel
            // 
            this.SearchCriteria_dateCreated_TableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_dateCreated_TableLayoutPanel.AutoSize = true;
            this.SearchCriteria_dateCreated_TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchCriteria_dateCreated_TableLayoutPanel.ColumnCount = 3;
            this.SearchCriteria_dateCreated_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchCriteria_dateCreated_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SearchCriteria_dateCreated_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchCriteria_dateCreated_TableLayoutPanel.Controls.Add(this.label2, 1, 0);
            this.SearchCriteria_dateCreated_TableLayoutPanel.Controls.Add(this.SearchCriteria_dateCreated_from_DateTimePicker, 0, 0);
            this.SearchCriteria_dateCreated_TableLayoutPanel.Controls.Add(this.SearchCriteria_dateCreated_to_DateTimePicker, 2, 0);
            this.SearchCriteria_dateCreated_TableLayoutPanel.Enabled = false;
            this.SearchCriteria_dateCreated_TableLayoutPanel.Location = new System.Drawing.Point(211, 205);
            this.SearchCriteria_dateCreated_TableLayoutPanel.Name = "SearchCriteria_dateCreated_TableLayoutPanel";
            this.SearchCriteria_dateCreated_TableLayoutPanel.RowCount = 1;
            this.SearchCriteria_dateCreated_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchCriteria_dateCreated_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.SearchCriteria_dateCreated_TableLayoutPanel.Size = new System.Drawing.Size(302, 26);
            this.SearchCriteria_dateCreated_TableLayoutPanel.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(141, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "---";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchCriteria_dateCreated_from_DateTimePicker
            // 
            this.SearchCriteria_dateCreated_from_DateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_dateCreated_from_DateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.SearchCriteria_dateCreated_from_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SearchCriteria_dateCreated_from_DateTimePicker.Location = new System.Drawing.Point(3, 3);
            this.SearchCriteria_dateCreated_from_DateTimePicker.MinDate = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            this.SearchCriteria_dateCreated_from_DateTimePicker.Name = "SearchCriteria_dateCreated_from_DateTimePicker";
            this.SearchCriteria_dateCreated_from_DateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.SearchCriteria_dateCreated_from_DateTimePicker.TabIndex = 1;
            this.SearchCriteria_dateCreated_from_DateTimePicker.Value = new System.DateTime(2020, 12, 1, 16, 24, 7, 0);
            // 
            // SearchCriteria_dateCreated_to_DateTimePicker
            // 
            this.SearchCriteria_dateCreated_to_DateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_dateCreated_to_DateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.SearchCriteria_dateCreated_to_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SearchCriteria_dateCreated_to_DateTimePicker.Location = new System.Drawing.Point(174, 3);
            this.SearchCriteria_dateCreated_to_DateTimePicker.MinDate = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            this.SearchCriteria_dateCreated_to_DateTimePicker.Name = "SearchCriteria_dateCreated_to_DateTimePicker";
            this.SearchCriteria_dateCreated_to_DateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.SearchCriteria_dateCreated_to_DateTimePicker.TabIndex = 1;
            this.SearchCriteria_dateCreated_to_DateTimePicker.Value = new System.DateTime(2020, 12, 1, 16, 24, 11, 0);
            // 
            // SearchCriteria_dateChanged_TableLayoutPanel
            // 
            this.SearchCriteria_dateChanged_TableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_dateChanged_TableLayoutPanel.AutoSize = true;
            this.SearchCriteria_dateChanged_TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchCriteria_dateChanged_TableLayoutPanel.ColumnCount = 3;
            this.SearchCriteria_dateChanged_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchCriteria_dateChanged_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.SearchCriteria_dateChanged_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchCriteria_dateChanged_TableLayoutPanel.Controls.Add(this.label3, 1, 0);
            this.SearchCriteria_dateChanged_TableLayoutPanel.Controls.Add(this.SearchCriteria_dateChanged_from_DateTimePicker, 0, 0);
            this.SearchCriteria_dateChanged_TableLayoutPanel.Controls.Add(this.SearchCriteria_dateChanged_to_DateTimePicker, 2, 0);
            this.SearchCriteria_dateChanged_TableLayoutPanel.Enabled = false;
            this.SearchCriteria_dateChanged_TableLayoutPanel.Location = new System.Drawing.Point(211, 237);
            this.SearchCriteria_dateChanged_TableLayoutPanel.Name = "SearchCriteria_dateChanged_TableLayoutPanel";
            this.SearchCriteria_dateChanged_TableLayoutPanel.RowCount = 1;
            this.SearchCriteria_dateChanged_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchCriteria_dateChanged_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.SearchCriteria_dateChanged_TableLayoutPanel.Size = new System.Drawing.Size(302, 26);
            this.SearchCriteria_dateChanged_TableLayoutPanel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(141, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "---";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchCriteria_dateChanged_from_DateTimePicker
            // 
            this.SearchCriteria_dateChanged_from_DateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_dateChanged_from_DateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.SearchCriteria_dateChanged_from_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SearchCriteria_dateChanged_from_DateTimePicker.Location = new System.Drawing.Point(3, 3);
            this.SearchCriteria_dateChanged_from_DateTimePicker.MinDate = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            this.SearchCriteria_dateChanged_from_DateTimePicker.Name = "SearchCriteria_dateChanged_from_DateTimePicker";
            this.SearchCriteria_dateChanged_from_DateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.SearchCriteria_dateChanged_from_DateTimePicker.TabIndex = 1;
            this.SearchCriteria_dateChanged_from_DateTimePicker.Value = new System.DateTime(2020, 12, 1, 16, 24, 3, 0);
            // 
            // SearchCriteria_dateChanged_to_DateTimePicker
            // 
            this.SearchCriteria_dateChanged_to_DateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchCriteria_dateChanged_to_DateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.SearchCriteria_dateChanged_to_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.SearchCriteria_dateChanged_to_DateTimePicker.Location = new System.Drawing.Point(174, 3);
            this.SearchCriteria_dateChanged_to_DateTimePicker.MinDate = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            this.SearchCriteria_dateChanged_to_DateTimePicker.Name = "SearchCriteria_dateChanged_to_DateTimePicker";
            this.SearchCriteria_dateChanged_to_DateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.SearchCriteria_dateChanged_to_DateTimePicker.TabIndex = 1;
            this.SearchCriteria_dateChanged_to_DateTimePicker.Value = new System.DateTime(2020, 12, 1, 16, 24, 17, 0);
            // 
            // Show_GridControl
            // 
            this.Show_GridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Show_GridControl.Location = new System.Drawing.Point(3, 304);
            this.Show_GridControl.LookAndFeel.SkinName = "Office 2010 Blue";
            this.Show_GridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Show_GridControl.MainView = this.Show_GridView;
            this.Show_GridControl.Name = "Show_GridControl";
            this.Show_GridControl.Size = new System.Drawing.Size(997, 345);
            this.Show_GridControl.TabIndex = 3;
            this.Show_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Show_GridView});
            // 
            // Show_GridView
            // 
            this.Show_GridView.GridControl = this.Show_GridControl;
            this.Show_GridView.Name = "Show_GridView";
            this.Show_GridView.OptionsBehavior.Editable = false;
            this.Show_GridView.DoubleClick += new System.EventHandler(this.Show_GridView_DoubleClick);
            // 
            // UsersManagement_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 711);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(690, 750);
            this.Name = "UsersManagement_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление пользователями";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UsersManagement_main_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.SearchCriteria_status_TableLayoutPanel.ResumeLayout(false);
            this.SearchCriteria_status_TableLayoutPanel.PerformLayout();
            this.SearchCriteria_generalPermissions_TableLayoutPanel.ResumeLayout(false);
            this.SearchCriteria_generalPermissions_TableLayoutPanel.PerformLayout();
            this.SearchCriteria_dateCreated_TableLayoutPanel.ResumeLayout(false);
            this.SearchCriteria_dateCreated_TableLayoutPanel.PerformLayout();
            this.SearchCriteria_dateChanged_TableLayoutPanel.ResumeLayout(false);
            this.SearchCriteria_dateChanged_TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Show_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Show_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.TextBox SearchCriteria_name_TextBox;
        private System.Windows.Forms.TextBox SearchCriteria_nameDomain_TextBox;
        private System.Windows.Forms.TextBox SearchCriteria_email_TextBox;
        private System.Windows.Forms.ComboBox SearchCriteria_department_ComboBox;
        private System.Windows.Forms.TableLayoutPanel SearchCriteria_status_TableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel SearchCriteria_generalPermissions_TableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel SearchCriteria_dateCreated_TableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel SearchCriteria_dateChanged_TableLayoutPanel;
        private System.Windows.Forms.RadioButton SearchCriteria_status_notActive_RadioButton;
        private System.Windows.Forms.RadioButton SearchCriteria_status_active_RadioButton;
        private System.Windows.Forms.CheckBox SearchCriteria_generalPermissions_directoryManagement_CheckBox;
        private System.Windows.Forms.CheckBox SearchCriteria_generalPermissions_usersManagement_CheckBox;
        private System.Windows.Forms.CheckBox SearchCriteria_generalPermissions_reportsManagement_CheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker SearchCriteria_dateCreated_from_DateTimePicker;
        private System.Windows.Forms.DateTimePicker SearchCriteria_dateCreated_to_DateTimePicker;
        private System.Windows.Forms.DateTimePicker SearchCriteria_dateChanged_from_DateTimePicker;
        private System.Windows.Forms.DateTimePicker SearchCriteria_dateChanged_to_DateTimePicker;
        public System.Windows.Forms.CheckBox SearchCriteria_name_CheckBox;
        public System.Windows.Forms.CheckBox SearchCriteria_nameDomain_CheckBox;
        public System.Windows.Forms.CheckBox SearchCriteria_email_CheckBox;
        public System.Windows.Forms.CheckBox SearchCriteria_department_CheckBox;
        public System.Windows.Forms.CheckBox SearchCriteria_status_CheckBox;
        public System.Windows.Forms.CheckBox SearchCriteria_generalPermissions_CheckBox;
        public System.Windows.Forms.CheckBox SearchCriteria_dateCreated_CheckBox;
        public System.Windows.Forms.CheckBox SearchCriteria_dateChanged_CheckBox;
        public System.Windows.Forms.TextBox SearchCriteria_userIds_TextBox;
        public System.Windows.Forms.CheckBox SearchCriteria_userIds_CheckBox;
        public DevExpress.XtraGrid.GridControl Show_GridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView Show_GridView;
    }
}