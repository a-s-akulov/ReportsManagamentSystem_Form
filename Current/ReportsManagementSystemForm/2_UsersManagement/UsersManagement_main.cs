using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace ReportsManagementSystemForm
{
    public partial class UsersManagement_main : Form
    {
        public readonly MainMenu MAIN;
        public readonly MyProgram PROG;

        public UsersManagement_main(MainMenu parent)
        {
            InitializeComponent();

            MAIN = parent;
            PROG = new MyProgram(this);

            // Обновление информации о текущем пользователе
            if (!MAIN.PROG.CurrentUserInfoGet(this)) return;

            // Обновление справочника
            if (!MAIN.PROG.DirectoryUpdate(this, new string[] { "statuses", "departments", "permissions" })) return;

            // Инициализация элементов управления
            PROG.ControlsInit();
        }

        private void UsersManagement_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MAIN.Show();
        }

        private void SearchCriteria_userIds_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("userIds");
        }

        private void SearchCriteria_name_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("name");
        }

        private void SearchCriteria_nameDomain_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("nameDomain");
        }

        private void SearchCriteria_email_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("email");
        }

        private void SearchCriteria_department_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("department");
        }

        private void SearchCriteria_status_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("status");
        }

        private void SearchCriteria_generalPermissions_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("generalPermissions");
        }

        private void SearchCriteria_dateCreated_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("dateCreated");
        }

        private void SearchCriteria_dateChanged_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("dateChanged");
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            PROG.Search();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            PROG.DataAdd();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            PROG.DataEdit();
        }

        private void Show_GridView_DoubleClick(object sender, EventArgs e)
        {
            if (((GridView)sender).CalcHitInfo(((DXMouseEventArgs)e).Location).InRow) PROG.DataEdit();
        }
    }
}
