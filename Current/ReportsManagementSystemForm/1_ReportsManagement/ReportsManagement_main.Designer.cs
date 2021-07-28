namespace ReportsManagementSystemForm
{
    partial class ReportsManagement_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsManagement_main));
            this.Main_TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.INST_InstanceAdd_Button = new System.Windows.Forms.Button();
            this.INST_InstanceEdit_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.INST_DataGet_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.INST_department_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.INST_isNotActiveShown_CheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.INST_dateFrom_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.INST_dateTo_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.INST_Data_GridControl = new DevExpress.XtraGrid.GridControl();
            this.INST_Data_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.REG_RecordAdd_Button = new System.Windows.Forms.Button();
            this.REG_RecordEdit_Button = new System.Windows.Forms.Button();
            this.REG_UsersEdit_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.REG_DataGet_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.REG_department_ComboBox = new System.Windows.Forms.ComboBox();
            this.REG_isNotActiveShown_CheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.REG_DataDescription_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.REG_NotificationReceivers_ListBox = new System.Windows.Forms.ListBox();
            this.REG_Data_GridControl = new DevExpress.XtraGrid.GridControl();
            this.REG_Data_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Main_TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.INST_Data_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.INST_Data_GridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.REG_Data_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.REG_Data_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_TabControl
            // 
            this.Main_TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_TabControl.Controls.Add(this.tabPage1);
            this.Main_TabControl.Controls.Add(this.tabPage2);
            this.Main_TabControl.Location = new System.Drawing.Point(12, 12);
            this.Main_TabControl.Name = "Main_TabControl";
            this.Main_TabControl.SelectedIndex = 0;
            this.Main_TabControl.Size = new System.Drawing.Size(1519, 733);
            this.Main_TabControl.TabIndex = 0;
            this.Main_TabControl.SelectedIndexChanged += new System.EventHandler(this.Main_TabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1511, 707);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Управление экземплярами отчётов";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.INST_Data_GridControl, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1499, 695);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.INST_InstanceAdd_Button, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.INST_InstanceEdit_Button, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 666);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1499, 29);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // INST_InstanceAdd_Button
            // 
            this.INST_InstanceAdd_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.INST_InstanceAdd_Button.AutoSize = true;
            this.INST_InstanceAdd_Button.Location = new System.Drawing.Point(1333, 3);
            this.INST_InstanceAdd_Button.Name = "INST_InstanceAdd_Button";
            this.INST_InstanceAdd_Button.Size = new System.Drawing.Size(163, 23);
            this.INST_InstanceAdd_Button.TabIndex = 0;
            this.INST_InstanceAdd_Button.Text = "Загрузить новый экземпляр";
            this.INST_InstanceAdd_Button.UseVisualStyleBackColor = true;
            this.INST_InstanceAdd_Button.Click += new System.EventHandler(this.INST_InstanceAdd_Button_Click);
            // 
            // INST_InstanceEdit_Button
            // 
            this.INST_InstanceEdit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.INST_InstanceEdit_Button.AutoSize = true;
            this.INST_InstanceEdit_Button.Location = new System.Drawing.Point(987, 3);
            this.INST_InstanceEdit_Button.Name = "INST_InstanceEdit_Button";
            this.INST_InstanceEdit_Button.Size = new System.Drawing.Size(240, 23);
            this.INST_InstanceEdit_Button.TabIndex = 1;
            this.INST_InstanceEdit_Button.Text = "Просмотр или редактирование экземпляра";
            this.INST_InstanceEdit_Button.UseVisualStyleBackColor = true;
            this.INST_InstanceEdit_Button.Click += new System.EventHandler(this.INST_InstanceEdit_Button_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.INST_DataGet_Button, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.INST_department_ComboBox, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.INST_isNotActiveShown_CheckBox, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1499, 105);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // INST_DataGet_Button
            // 
            this.INST_DataGet_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.INST_DataGet_Button.AutoSize = true;
            this.INST_DataGet_Button.Location = new System.Drawing.Point(1322, 79);
            this.INST_DataGet_Button.Name = "INST_DataGet_Button";
            this.INST_DataGet_Button.Size = new System.Drawing.Size(174, 23);
            this.INST_DataGet_Button.TabIndex = 0;
            this.INST_DataGet_Button.Text = "Поиск по списку экземпляров";
            this.INST_DataGet_Button.UseVisualStyleBackColor = true;
            this.INST_DataGet_Button.Click += new System.EventHandler(this.INST_DataGet_Button_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Отдел:";
            // 
            // INST_department_ComboBox
            // 
            this.INST_department_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.INST_department_ComboBox.FormattingEnabled = true;
            this.INST_department_ComboBox.Location = new System.Drawing.Point(57, 3);
            this.INST_department_ComboBox.Name = "INST_department_ComboBox";
            this.INST_department_ComboBox.Size = new System.Drawing.Size(1439, 21);
            this.INST_department_ComboBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Период:";
            // 
            // INST_isNotActiveShown_CheckBox
            // 
            this.INST_isNotActiveShown_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.INST_isNotActiveShown_CheckBox.AutoSize = true;
            this.INST_isNotActiveShown_CheckBox.Location = new System.Drawing.Point(57, 56);
            this.INST_isNotActiveShown_CheckBox.Name = "INST_isNotActiveShown_CheckBox";
            this.INST_isNotActiveShown_CheckBox.Size = new System.Drawing.Size(192, 17);
            this.INST_isNotActiveShown_CheckBox.TabIndex = 3;
            this.INST_isNotActiveShown_CheckBox.Text = "Показывать неактивные записи";
            this.INST_isNotActiveShown_CheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.INST_dateFrom_DateTimePicker, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.INST_dateTo_DateTimePicker, 2, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(54, 27);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(286, 26);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "---";
            // 
            // INST_dateFrom_DateTimePicker
            // 
            this.INST_dateFrom_DateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.INST_dateFrom_DateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.INST_dateFrom_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.INST_dateFrom_DateTimePicker.Location = new System.Drawing.Point(3, 3);
            this.INST_dateFrom_DateTimePicker.Name = "INST_dateFrom_DateTimePicker";
            this.INST_dateFrom_DateTimePicker.Size = new System.Drawing.Size(126, 20);
            this.INST_dateFrom_DateTimePicker.TabIndex = 1;
            // 
            // INST_dateTo_DateTimePicker
            // 
            this.INST_dateTo_DateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.INST_dateTo_DateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
            this.INST_dateTo_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.INST_dateTo_DateTimePicker.Location = new System.Drawing.Point(157, 3);
            this.INST_dateTo_DateTimePicker.Name = "INST_dateTo_DateTimePicker";
            this.INST_dateTo_DateTimePicker.Size = new System.Drawing.Size(126, 20);
            this.INST_dateTo_DateTimePicker.TabIndex = 1;
            // 
            // INST_Data_GridControl
            // 
            this.INST_Data_GridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.INST_Data_GridControl.Location = new System.Drawing.Point(3, 108);
            this.INST_Data_GridControl.LookAndFeel.SkinName = "Office 2010 Blue";
            this.INST_Data_GridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.INST_Data_GridControl.MainView = this.INST_Data_GridView;
            this.INST_Data_GridControl.Name = "INST_Data_GridControl";
            this.INST_Data_GridControl.Size = new System.Drawing.Size(1493, 555);
            this.INST_Data_GridControl.TabIndex = 3;
            this.INST_Data_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.INST_Data_GridView});
            // 
            // INST_Data_GridView
            // 
            this.INST_Data_GridView.GridControl = this.INST_Data_GridControl;
            this.INST_Data_GridView.Name = "INST_Data_GridView";
            this.INST_Data_GridView.OptionsBehavior.Editable = false;
            this.INST_Data_GridView.DoubleClick += new System.EventHandler(this.INST_Data_GridView_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1511, 707);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Управление реестром отчётов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.REG_Data_GridControl, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1499, 695);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.REG_RecordAdd_Button, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.REG_RecordEdit_Button, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.REG_UsersEdit_Button, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 666);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1499, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // REG_RecordAdd_Button
            // 
            this.REG_RecordAdd_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.REG_RecordAdd_Button.AutoSize = true;
            this.REG_RecordAdd_Button.Location = new System.Drawing.Point(1346, 3);
            this.REG_RecordAdd_Button.Name = "REG_RecordAdd_Button";
            this.REG_RecordAdd_Button.Size = new System.Drawing.Size(150, 23);
            this.REG_RecordAdd_Button.TabIndex = 0;
            this.REG_RecordAdd_Button.Text = "Добавить запись";
            this.REG_RecordAdd_Button.UseVisualStyleBackColor = true;
            this.REG_RecordAdd_Button.Click += new System.EventHandler(this.REG_Add_Button_Click);
            // 
            // REG_RecordEdit_Button
            // 
            this.REG_RecordEdit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.REG_RecordEdit_Button.AutoSize = true;
            this.REG_RecordEdit_Button.Location = new System.Drawing.Point(1090, 3);
            this.REG_RecordEdit_Button.Name = "REG_RecordEdit_Button";
            this.REG_RecordEdit_Button.Size = new System.Drawing.Size(150, 23);
            this.REG_RecordEdit_Button.TabIndex = 1;
            this.REG_RecordEdit_Button.Text = "Редактировать запись";
            this.REG_RecordEdit_Button.UseVisualStyleBackColor = true;
            this.REG_RecordEdit_Button.Click += new System.EventHandler(this.REG_Edit_Button_Click);
            // 
            // REG_UsersEdit_Button
            // 
            this.REG_UsersEdit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.REG_UsersEdit_Button.AutoSize = true;
            this.REG_UsersEdit_Button.Location = new System.Drawing.Point(874, 3);
            this.REG_UsersEdit_Button.Name = "REG_UsersEdit_Button";
            this.REG_UsersEdit_Button.Size = new System.Drawing.Size(210, 23);
            this.REG_UsersEdit_Button.TabIndex = 2;
            this.REG_UsersEdit_Button.Text = "Редактировать пользователей";
            this.REG_UsersEdit_Button.UseVisualStyleBackColor = true;
            this.REG_UsersEdit_Button.Click += new System.EventHandler(this.REG_UsersEdit_Button_Click);
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
            this.tableLayoutPanel3.Controls.Add(this.REG_DataGet_Button, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.REG_department_ComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.REG_isNotActiveShown_CheckBox, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1499, 79);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // REG_DataGet_Button
            // 
            this.REG_DataGet_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.REG_DataGet_Button.AutoSize = true;
            this.REG_DataGet_Button.Location = new System.Drawing.Point(1351, 53);
            this.REG_DataGet_Button.Name = "REG_DataGet_Button";
            this.REG_DataGet_Button.Size = new System.Drawing.Size(145, 23);
            this.REG_DataGet_Button.TabIndex = 0;
            this.REG_DataGet_Button.Text = "Получить список отчётов";
            this.REG_DataGet_Button.UseVisualStyleBackColor = true;
            this.REG_DataGet_Button.Click += new System.EventHandler(this.REG_DataGet_Button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отдел:";
            // 
            // REG_department_ComboBox
            // 
            this.REG_department_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.REG_department_ComboBox.FormattingEnabled = true;
            this.REG_department_ComboBox.Location = new System.Drawing.Point(50, 3);
            this.REG_department_ComboBox.Name = "REG_department_ComboBox";
            this.REG_department_ComboBox.Size = new System.Drawing.Size(1446, 21);
            this.REG_department_ComboBox.TabIndex = 2;
            // 
            // REG_isNotActiveShown_CheckBox
            // 
            this.REG_isNotActiveShown_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.REG_isNotActiveShown_CheckBox.AutoSize = true;
            this.REG_isNotActiveShown_CheckBox.Location = new System.Drawing.Point(50, 30);
            this.REG_isNotActiveShown_CheckBox.Name = "REG_isNotActiveShown_CheckBox";
            this.REG_isNotActiveShown_CheckBox.Size = new System.Drawing.Size(192, 17);
            this.REG_isNotActiveShown_CheckBox.TabIndex = 3;
            this.REG_isNotActiveShown_CheckBox.Text = "Показывать неактивные записи";
            this.REG_isNotActiveShown_CheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.REG_DataDescription_RichTextBox, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.REG_NotificationReceivers_ListBox, 1, 1);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 503);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1499, 163);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Описание отчёта:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(754, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Получатели уведомлений отчёта:";
            // 
            // REG_DataDescription_RichTextBox
            // 
            this.REG_DataDescription_RichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.REG_DataDescription_RichTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.REG_DataDescription_RichTextBox.Location = new System.Drawing.Point(6, 22);
            this.REG_DataDescription_RichTextBox.Name = "REG_DataDescription_RichTextBox";
            this.REG_DataDescription_RichTextBox.ReadOnly = true;
            this.REG_DataDescription_RichTextBox.Size = new System.Drawing.Size(739, 135);
            this.REG_DataDescription_RichTextBox.TabIndex = 2;
            this.REG_DataDescription_RichTextBox.Text = "";
            // 
            // REG_NotificationReceivers_ListBox
            // 
            this.REG_NotificationReceivers_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.REG_NotificationReceivers_ListBox.BackColor = System.Drawing.SystemColors.Info;
            this.REG_NotificationReceivers_ListBox.FormattingEnabled = true;
            this.REG_NotificationReceivers_ListBox.Location = new System.Drawing.Point(754, 22);
            this.REG_NotificationReceivers_ListBox.Name = "REG_NotificationReceivers_ListBox";
            this.REG_NotificationReceivers_ListBox.Size = new System.Drawing.Size(739, 134);
            this.REG_NotificationReceivers_ListBox.TabIndex = 3;
            // 
            // REG_Data_GridControl
            // 
            this.REG_Data_GridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.REG_Data_GridControl.Location = new System.Drawing.Point(3, 82);
            this.REG_Data_GridControl.LookAndFeel.SkinName = "Office 2010 Blue";
            this.REG_Data_GridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.REG_Data_GridControl.MainView = this.REG_Data_GridView;
            this.REG_Data_GridControl.Name = "REG_Data_GridControl";
            this.REG_Data_GridControl.Size = new System.Drawing.Size(1493, 418);
            this.REG_Data_GridControl.TabIndex = 4;
            this.REG_Data_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.REG_Data_GridView});
            // 
            // REG_Data_GridView
            // 
            this.REG_Data_GridView.GridControl = this.REG_Data_GridControl;
            this.REG_Data_GridView.Name = "REG_Data_GridView";
            this.REG_Data_GridView.OptionsBehavior.Editable = false;
            this.REG_Data_GridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.REG_Data_GridView_FocusedRowChanged);
            this.REG_Data_GridView.DoubleClick += new System.EventHandler(this.REG_Data_GridView_DoubleClick);
            // 
            // ReportsManagement_main
            // 
            this.ClientSize = new System.Drawing.Size(1543, 757);
            this.Controls.Add(this.Main_TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(825, 475);
            this.Name = "ReportsManagement_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление отчётами";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UsersManagement_main_FormClosed);
            this.Main_TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.INST_Data_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.INST_Data_GridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.REG_Data_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.REG_Data_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl Main_TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button REG_RecordAdd_Button;
        private System.Windows.Forms.Button REG_RecordEdit_Button;
        private System.Windows.Forms.Button REG_DataGet_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox REG_isNotActiveShown_CheckBox;
        private System.Windows.Forms.Button REG_UsersEdit_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button INST_InstanceAdd_Button;
        private System.Windows.Forms.Button INST_InstanceEdit_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button INST_DataGet_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox INST_isNotActiveShown_CheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker INST_dateFrom_DateTimePicker;
        private System.Windows.Forms.DateTimePicker INST_dateTo_DateTimePicker;
        public System.Windows.Forms.ComboBox INST_department_ComboBox;
        public System.Windows.Forms.ComboBox REG_department_ComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.RichTextBox REG_DataDescription_RichTextBox;
        public System.Windows.Forms.ListBox REG_NotificationReceivers_ListBox;
        public DevExpress.XtraGrid.GridControl INST_Data_GridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView INST_Data_GridView;
        public DevExpress.XtraGrid.GridControl REG_Data_GridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView REG_Data_GridView;
    }
}