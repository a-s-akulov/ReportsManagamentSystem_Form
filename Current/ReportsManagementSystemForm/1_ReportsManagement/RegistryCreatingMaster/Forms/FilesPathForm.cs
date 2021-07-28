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
    public partial class FilesPathForm : Form
    {
        public string resultFilesPath = "";

        public FilesPathForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            ActiveControl = FilesPath_RichTextBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultFilesPath = FilesPath_RichTextBox.Text.Trim(' ', '\n', '\t');
            DialogResult = DialogResult.Yes;
        }
    }
}
