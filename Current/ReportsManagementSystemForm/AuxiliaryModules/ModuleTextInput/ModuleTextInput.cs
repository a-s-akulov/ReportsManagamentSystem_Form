using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportsManagementSystemForm
{
    public partial class ModuleTextInput : Form
    {
        public readonly MyProgram PROG;

        public string resultString = "";

        public ModuleTextInput(int maxResultLength = 250, string startValue = "")
        {
            InitializeComponent();

            PROG = new MyProgram(this, maxResultLength, startValue);
        }

        private void ChangesCancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult resultDialog = MessageBox.Show($"Уверены, что хотите отменить редактирование текста?",
                        "Закрыть окно?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDialog == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void ChangesAccept_Button_Click(object sender, EventArgs e)
        {
            PROG.ChangesAccept();
        }
    }
}
