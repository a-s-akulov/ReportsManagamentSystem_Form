using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ReportsManagementSystemForm
{
    public partial class ReportsManagement_instance_editor : Form
    {
        public readonly ReportsManagement_main MANAGEMENT_FORM;
        public readonly MyProgram PROG;
        public string Mode;

        /// <summary>
        /// Доступны режимы: "ADD", "EDIT" и "READ"
        /// </summary>
        /// <param name="managementForm"></param>
        /// <param name="modeOfWork"></param>
        public ReportsManagement_instance_editor(ReportsManagement_main managementForm, string modeOfWork)
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

        private void Files_add_Button_Click(object sender, EventArgs e)
        {
            PROG.FilesAdd();
        }

        private void Files_delete_Button_Click(object sender, EventArgs e)
        {
            PROG.FilesDelete();
        }

        private void Files_get_Button_Click(object sender, EventArgs e)
        {
            PROG.FilesGet();
        }

        private void Message_fullEditor_open_Button_Click(object sender, EventArgs e)
        {
            PROG.MessageEditInFullEditor();
        }

        private void Message_fullEditor_open_Button_Paint(object sender, PaintEventArgs e)
        {
            MANAGEMENT_FORM.MAIN.PROG.ControlCustomBorderPainter((Control)sender, e: e);
        }

        private void Department_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(PROG is null)) PROG.DepartmentChanged();
        }
    }
}
