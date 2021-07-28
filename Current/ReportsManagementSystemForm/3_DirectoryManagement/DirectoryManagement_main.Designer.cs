namespace ReportsManagementSystemForm
{
    partial class DirectoryManagement_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryManagement_main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SectionSelection_ComboBox = new System.Windows.Forms.ComboBox();
            this.IrrelevantRecordsShow_CheckBox = new System.Windows.Forms.CheckBox();
            this.DataGet_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.RecordChangeActuality_Button = new System.Windows.Forms.Button();
            this.RecordEdit_Button = new System.Windows.Forms.Button();
            this.RecordAdd_Button = new System.Windows.Forms.Button();
            this.DataShow_GridControl = new DevExpress.XtraGrid.GridControl();
            this.DataShow_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataShow_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataShow_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 486);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SectionSelection_ComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.IrrelevantRecordsShow_CheckBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.DataGet_Button, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 79);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Раздел:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SectionSelection_ComboBox
            // 
            this.SectionSelection_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SectionSelection_ComboBox.FormattingEnabled = true;
            this.SectionSelection_ComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SectionSelection_ComboBox.Items.AddRange(new object[] {
            "Брэнды",
            "Отделы",
            "Группы отчетов",
            "Типы отчетов",
            "Частоты подготовки отчетов",
            "Даты подготовки отчетов"});
            this.SectionSelection_ComboBox.Location = new System.Drawing.Point(56, 3);
            this.SectionSelection_ComboBox.Name = "SectionSelection_ComboBox";
            this.SectionSelection_ComboBox.Size = new System.Drawing.Size(235, 21);
            this.SectionSelection_ComboBox.TabIndex = 1;
            // 
            // IrrelevantRecordsShow_CheckBox
            // 
            this.IrrelevantRecordsShow_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.IrrelevantRecordsShow_CheckBox.AutoSize = true;
            this.IrrelevantRecordsShow_CheckBox.Location = new System.Drawing.Point(56, 30);
            this.IrrelevantRecordsShow_CheckBox.Name = "IrrelevantRecordsShow_CheckBox";
            this.IrrelevantRecordsShow_CheckBox.Size = new System.Drawing.Size(235, 17);
            this.IrrelevantRecordsShow_CheckBox.TabIndex = 2;
            this.IrrelevantRecordsShow_CheckBox.Text = "Отображать неактуальные записи";
            this.IrrelevantRecordsShow_CheckBox.UseVisualStyleBackColor = true;
            // 
            // DataGet_Button
            // 
            this.DataGet_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGet_Button.AutoSize = true;
            this.DataGet_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataGet_Button.Location = new System.Drawing.Point(186, 53);
            this.DataGet_Button.Name = "DataGet_Button";
            this.DataGet_Button.Size = new System.Drawing.Size(105, 23);
            this.DataGet_Button.TabIndex = 3;
            this.DataGet_Button.Text = "Получить данные";
            this.DataGet_Button.UseVisualStyleBackColor = true;
            this.DataGet_Button.Click += new System.EventHandler(this.DataGet_Button_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.DataShow_GridControl, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(303, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(876, 480);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.RecordChangeActuality_Button, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.RecordEdit_Button, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.RecordAdd_Button, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 451);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(876, 29);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // RecordChangeActuality_Button
            // 
            this.RecordChangeActuality_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordChangeActuality_Button.AutoSize = true;
            this.RecordChangeActuality_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecordChangeActuality_Button.Location = new System.Drawing.Point(733, 3);
            this.RecordChangeActuality_Button.Name = "RecordChangeActuality_Button";
            this.RecordChangeActuality_Button.Size = new System.Drawing.Size(140, 23);
            this.RecordChangeActuality_Button.TabIndex = 2;
            this.RecordChangeActuality_Button.Text = "Изменить актуальность";
            this.RecordChangeActuality_Button.UseVisualStyleBackColor = true;
            this.RecordChangeActuality_Button.Click += new System.EventHandler(this.RecordChangeActuality_Button_Click);
            // 
            // RecordEdit_Button
            // 
            this.RecordEdit_Button.AutoSize = true;
            this.RecordEdit_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecordEdit_Button.Location = new System.Drawing.Point(76, 3);
            this.RecordEdit_Button.Name = "RecordEdit_Button";
            this.RecordEdit_Button.Size = new System.Drawing.Size(68, 23);
            this.RecordEdit_Button.TabIndex = 1;
            this.RecordEdit_Button.Text = "Изменить";
            this.RecordEdit_Button.UseVisualStyleBackColor = true;
            this.RecordEdit_Button.Click += new System.EventHandler(this.RecordEdit_Button_Click);
            // 
            // RecordAdd_Button
            // 
            this.RecordAdd_Button.AutoSize = true;
            this.RecordAdd_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecordAdd_Button.Location = new System.Drawing.Point(3, 3);
            this.RecordAdd_Button.Name = "RecordAdd_Button";
            this.RecordAdd_Button.Size = new System.Drawing.Size(67, 23);
            this.RecordAdd_Button.TabIndex = 0;
            this.RecordAdd_Button.Text = "Добавить";
            this.RecordAdd_Button.UseVisualStyleBackColor = true;
            this.RecordAdd_Button.Click += new System.EventHandler(this.RecordAdd_Button_Click);
            // 
            // DataShow_GridControl
            // 
            this.DataShow_GridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataShow_GridControl.Location = new System.Drawing.Point(3, 3);
            this.DataShow_GridControl.LookAndFeel.SkinName = "Office 2010 Blue";
            this.DataShow_GridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DataShow_GridControl.MainView = this.DataShow_GridView;
            this.DataShow_GridControl.Name = "DataShow_GridControl";
            this.DataShow_GridControl.Size = new System.Drawing.Size(870, 445);
            this.DataShow_GridControl.TabIndex = 1;
            this.DataShow_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DataShow_GridView});
            // 
            // DataShow_GridView
            // 
            this.DataShow_GridView.GridControl = this.DataShow_GridControl;
            this.DataShow_GridView.Name = "DataShow_GridView";
            this.DataShow_GridView.OptionsBehavior.Editable = false;
            this.DataShow_GridView.PaintStyleName = "Skin";
            this.DataShow_GridView.DoubleClick += new System.EventHandler(this.DataShow_GridView_DoubleClick);
            // 
            // DirectoryManagement_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 510);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(568, 147);
            this.Name = "DirectoryManagement_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление справочником";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DirectoryManagement_main_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataShow_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataShow_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox IrrelevantRecordsShow_CheckBox;
        private System.Windows.Forms.Button DataGet_Button;
        public System.Windows.Forms.ComboBox SectionSelection_ComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button RecordChangeActuality_Button;
        private System.Windows.Forms.Button RecordEdit_Button;
        private System.Windows.Forms.Button RecordAdd_Button;
        public DevExpress.XtraGrid.GridControl DataShow_GridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView DataShow_GridView;
    }
}