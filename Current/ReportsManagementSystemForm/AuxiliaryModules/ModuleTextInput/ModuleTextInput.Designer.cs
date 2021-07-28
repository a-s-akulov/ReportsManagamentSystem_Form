namespace ReportsManagementSystemForm
{
    partial class ModuleTextInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleTextInput));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ChangesAccept_Button = new System.Windows.Forms.Button();
            this.ChangesCancel_Button = new System.Windows.Forms.Button();
            this.Text_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Text_RichTextBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(660, 287);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ChangesAccept_Button, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChangesCancel_Button, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 258);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(660, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ChangesAccept_Button
            // 
            this.ChangesAccept_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangesAccept_Button.Location = new System.Drawing.Point(582, 3);
            this.ChangesAccept_Button.Name = "ChangesAccept_Button";
            this.ChangesAccept_Button.Size = new System.Drawing.Size(75, 23);
            this.ChangesAccept_Button.TabIndex = 0;
            this.ChangesAccept_Button.Text = "Применить";
            this.ChangesAccept_Button.UseVisualStyleBackColor = true;
            this.ChangesAccept_Button.Click += new System.EventHandler(this.ChangesAccept_Button_Click);
            // 
            // ChangesCancel_Button
            // 
            this.ChangesCancel_Button.Location = new System.Drawing.Point(3, 3);
            this.ChangesCancel_Button.Name = "ChangesCancel_Button";
            this.ChangesCancel_Button.Size = new System.Drawing.Size(75, 23);
            this.ChangesCancel_Button.TabIndex = 1;
            this.ChangesCancel_Button.Text = "Отмена";
            this.ChangesCancel_Button.UseVisualStyleBackColor = true;
            this.ChangesCancel_Button.Click += new System.EventHandler(this.ChangesCancel_Button_Click);
            // 
            // Text_RichTextBox
            // 
            this.Text_RichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Text_RichTextBox.Location = new System.Drawing.Point(3, 3);
            this.Text_RichTextBox.Name = "Text_RichTextBox";
            this.Text_RichTextBox.Size = new System.Drawing.Size(654, 252);
            this.Text_RichTextBox.TabIndex = 1;
            this.Text_RichTextBox.Text = "";
            // 
            // ModuleTextInput
            // 
            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(270, 150);
            this.Name = "ModuleTextInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Текстовый редактор";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ChangesAccept_Button;
        private System.Windows.Forms.Button ChangesCancel_Button;
        private System.Windows.Forms.RichTextBox Text_RichTextBox;
    }
}