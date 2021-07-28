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
    public partial class ModuleUserSelect : Form
    {
        public readonly MainMenu MAIN;
        public readonly MyProgram PROG;

        public ModuleUserSelect(MainMenu mainMenu, DataTable dataResult, bool isMultipleChoiceAllowed = false)
        {
            InitializeComponent();

            MAIN = mainMenu;
            PROG = new MyProgram(this, dataResult, isMultipleChoiceAllowed);

            // Инициализация элементов управления
            PROG.ControlsInit();
        }

        private void SearchCriteria_department_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("department");
        }

        private void SearchCriteria_name_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("name");
        }

        private void SearchCriteria_nameDomain_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PROG.SearchCriteria_CheckBox_CheckedChanged("nameDomain");
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            PROG.Search();
        }

        private void Accept_Button_Click(object sender, EventArgs e)
        {
            PROG.SelectionAccept();
        }

        private void Сancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult resultDialog = MessageBox.Show($"Уверены, что хотите отменить выбор пользователя(ей)?",
                        "Закрыть окно?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == resultDialog) Close();
            else DialogResult = DialogResult.None;
        }

        private void Users_GridView_DoubleClick(object sender, EventArgs e)
        {
            if (!PROG.isMultipleChoiceAllowed) PROG.SelectionAccept();
        }

        private void Users_GridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Users_GridView.SelectedRowsCount > 0) PROG.SelectionAccept();
        }
    }
}
