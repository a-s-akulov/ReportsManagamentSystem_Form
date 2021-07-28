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
    public partial class NameForm : Form
    {
        public string resultName = "";

        public NameForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            ActiveControl = Name_TextBox;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultName = Name_TextBox.Text.Trim(' ', '\n', '\t');
            if (resultName == "")
            {
                MessageBox.Show("Имя отчёта не может быть пустым", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult = DialogResult.Yes;
        }       
    }
}
