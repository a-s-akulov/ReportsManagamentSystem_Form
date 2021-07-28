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
    public partial class ReportsManagement_registry_users_editor : Form
    {
        public readonly ReportsManagement_main MANAGEMENT_FORM;
        public readonly MyProgram PROG;
        private TableLayoutPanel tableLayoutPanel1;
        public readonly string Mode;


        /// <summary>
        /// dataResult должна поступать уже с готовой схемой
        /// </summary>
        /// <param name="main"></param>
        /// <param name="dataResult"></param>
        public ReportsManagement_registry_users_editor(ReportsManagement_main managementForm, int reportId)
        {
            InitializeComponent();

            MANAGEMENT_FORM = managementForm;

            PROG = new MyProgram(this, reportId);
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

        private void Receivers_add_Button_Click(object sender, EventArgs e)
        {
            PROG.UsersAdd("receivers");
        }

        private void Creators_add_Button_Click(object sender, EventArgs e)
        {
            PROG.UsersAdd("creators");
        }

        private void Editors_add_Button_Click(object sender, EventArgs e)
        {
            PROG.UsersAdd("editors");
        }

        private void Readers_add_Button_Click(object sender, EventArgs e)
        {
            PROG.UsersAdd("readers");
        }

        private void Receivers_delete_Button_Click(object sender, EventArgs e)
        {
            PROG.UsersDelete("receivers");
        }

        private void Creators_delete_Button_Click(object sender, EventArgs e)
        {
            PROG.UsersDelete("creators");
        }

        private void Editors_delete_Button_Click(object sender, EventArgs e)
        {
            PROG.UsersDelete("editors");
        }

        private void Readers_delete_Button_Click(object sender, EventArgs e)
        {
            PROG.UsersDelete("readers");
        }
    }
}
