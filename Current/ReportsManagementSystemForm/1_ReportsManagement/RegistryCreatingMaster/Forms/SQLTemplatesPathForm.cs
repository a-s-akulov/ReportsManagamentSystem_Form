using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportsManagementSystemForm.ReportsManagement_registry_creatingMaster_forms
{
    public partial class SQLTemplatesPathForm : Form
    {
        public string resultSQLTemplatesPath = "";

        public SQLTemplatesPathForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            ActiveControl = SQLTemplatesPath_RichTextBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultSQLTemplatesPath = SQLTemplatesPath_RichTextBox.Text.Trim(' ', '\n', '\t');
            DialogResult = DialogResult.Yes;
        }
    }
}
