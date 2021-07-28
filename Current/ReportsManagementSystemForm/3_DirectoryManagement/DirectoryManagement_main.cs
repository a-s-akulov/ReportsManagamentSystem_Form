using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;


namespace ReportsManagementSystemForm
{
    public partial class DirectoryManagement_main : Form
    {
        public readonly MainMenu MAIN;
        public readonly MyProgram PROG;

        public DirectoryManagement_main(MainMenu parent)
        {
            InitializeComponent();

            MAIN = parent;
            PROG = new MyProgram(this);

            SectionSelection_ComboBox.SelectedIndex = 0;
            SectionSelection_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // Обновление информации о текущем пользователе
            if (!MAIN.PROG.CurrentUserInfoGet(this)) return;

            // Обновление справочника
            if (!MAIN.PROG.DirectoryUpdate(this, new string[] { "statuses", "departments" })) return;
        }

        private void DirectoryManagement_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MAIN.Show();
        }

        private void DataGet_Button_Click(object sender, EventArgs e)
        {
            PROG.DataGet();
        }

        private void RecordAdd_Button_Click(object sender, EventArgs e)
        {
            PROG.DataAdd();
        }

        private void RecordEdit_Button_Click(object sender, EventArgs e)
        {
            PROG.DataEdit();
        }

        private void RecordChangeActuality_Button_Click(object sender, EventArgs e)
        {
            PROG.ActualityChange();
        }

        private void DataShow_GridView_DoubleClick(object sender, EventArgs e)
        {
            if ( ((GridView)sender).CalcHitInfo(((DXMouseEventArgs)e).Location).InRow ) PROG.DataEdit();
        }
    }
}
