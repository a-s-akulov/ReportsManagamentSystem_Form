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
    public partial class UsersManagement_editor : Form
    {
        public readonly UsersManagement_main MANAGEMENT_FORM;
        public readonly MyProgram PROG;
        public readonly string Mode;

        /// <summary>
        /// Доступны режимы: "ADD" и "EDIT"
        /// </summary>
        /// <param name="managementForm"></param>
        /// <param name="modeOfWork"></param>
        public UsersManagement_editor(UsersManagement_main managementForm, string modeOfWork)
        {
            InitializeComponent();

            MANAGEMENT_FORM = managementForm;
            Mode = modeOfWork;

            PROG = new MyProgram(this);
        }

        private void ChangesCancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult resultDialog = MessageBox.Show($"Уверены, что хотите отменить операцию?\n\nНесохраненные изменения будут потеряны",
                        "Закрыть окно?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDialog == DialogResult.Yes) Close();
        }

        private void ChangesAccept_Button_Click(object sender, EventArgs e)
        {
            PROG.ChangesAccept();
        }
    }
}
