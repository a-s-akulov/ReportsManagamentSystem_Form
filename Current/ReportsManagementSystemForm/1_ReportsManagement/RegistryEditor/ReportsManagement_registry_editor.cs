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
    public partial class ReportsManagement_registry_editor : Form
    {
        public readonly ReportsManagement_main MANAGEMENT_FORM;
        public readonly MyProgram PROG;
        public readonly string Mode;

        /// <summary>
        /// Доступны режимы: "ADD" и "EDIT"
        /// </summary>
        /// <param name="managementForm"></param>
        /// <param name="modeOfWork"></param>
        public ReportsManagement_registry_editor(ReportsManagement_main managementForm, string modeOfWork)
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

        private void ResponsiblePerson_edit_Button_Click(object sender, EventArgs e)
        {
            PROG.ResponsoblePersonEdit();
        }

        private void ContentDescription_edit_Button_Click(object sender, EventArgs e)
        {
            PROG.RichTextEdit("contentDescription");
        }

        private void Remark_edit_Button_Click(object sender, EventArgs e)
        {
            PROG.RichTextEdit("remark");
        }

        private void FilesPath_edit_Button_Click(object sender, EventArgs e)
        {
            PROG.RichTextEdit("filesPath");
        }

        private void SqlTemplatesPath_edit_Button_Click(object sender, EventArgs e)
        {
            PROG.RichTextEdit("sqlTemplatesPath");
        }

        private void ResponsiblePerson_edit_Button_Paint(object sender, PaintEventArgs e)
        {
            MANAGEMENT_FORM.MAIN.PROG.ControlCustomBorderPainter((Control)sender, e: e);
        }

        private void ContentDescription_edit_Button_Paint(object sender, PaintEventArgs e)
        {
            MANAGEMENT_FORM.MAIN.PROG.ControlCustomBorderPainter((Control)sender, e: e);
        }

        private void Remark_edit_Button_Paint(object sender, PaintEventArgs e)
        {
            MANAGEMENT_FORM.MAIN.PROG.ControlCustomBorderPainter((Control)sender, e: e);
        }

        private void FilesPath_edit_Button_Paint(object sender, PaintEventArgs e)
        {
            MANAGEMENT_FORM.MAIN.PROG.ControlCustomBorderPainter((Control)sender, e: e);
        }

        private void SqlTemplatesPath_edit_Button_Paint(object sender, PaintEventArgs e)
        {
            MANAGEMENT_FORM.MAIN.PROG.ControlCustomBorderPainter((Control)sender, e: e);
        }
    }
}
