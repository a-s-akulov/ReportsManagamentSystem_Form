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
    public partial class ReportsManagement_main : Form
    {
        public readonly MainMenu MAIN;
        public readonly MyProgramInstances PROG_INST;
        public readonly MyProgramRegistry PROG_REG;

        public ReportsManagement_main(MainMenu parent)
        {
            InitializeComponent();

            MAIN = parent;
            PROG_INST = new MyProgramInstances(this);
            PROG_REG = new MyProgramRegistry(this);

            // Обновление информации о текущем пользователе
            if (!MAIN.PROG.CurrentUserInfoGet(this)) return;
            if (!MAIN.PROG.CurrentUserReportsPermissionsGet(this)) return;

            // Обновление справочника
            if (!MAIN.PROG.DirectoryUpdate(this, new string[] {
                "statuses",
                "brands",
                "departments",
                "permissions",
                "reportFrequencies",
                "reportGroups",
                "reportToDates",
                "reportTypes"
            })) return;

            // Инициализация элементов управления
            PROG_INST.ControlsInit();
            if (MAIN.PROG.permissionReportsManagementGranted) PROG_REG.ControlsInit();
        }

        private void UsersManagement_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MAIN.Show();
        }

        private void Main_TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Main_TabControl.SelectedTab == tabPage2 && !MAIN.PROG.permissionReportsManagementGranted)
            {
                Main_TabControl.SelectedTab = tabPage1;
                MessageBox.Show("В доступе отказано", "Управление реестром отчётов", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        // REG
        private void REG_DataGet_Button_Click(object sender, EventArgs e)
        {
            PROG_REG.DataGet();
        }

        private void REG_Add_Button_Click(object sender, EventArgs e)
        {
            PROG_REG.DataAdd();
        }

        private void REG_Edit_Button_Click(object sender, EventArgs e)
        {
            PROG_REG.DataEdit();
        }

        private void REG_UsersEdit_Button_Click(object sender, EventArgs e)
        {
            PROG_REG.UsersEdit();
        }

        private void REG_Data_GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            PROG_REG.TableRowEnter();
        }

        private void REG_Data_GridView_DoubleClick(object sender, EventArgs e)
        {
            if (((GridView)sender).CalcHitInfo(((DXMouseEventArgs)e).Location).InRow) PROG_REG.DataEdit();
        }


        // INST
        private void INST_DataGet_Button_Click(object sender, EventArgs e)
        {
            PROG_INST.DataGet();
        }

        private void INST_InstanceAdd_Button_Click(object sender, EventArgs e)
        {
            PROG_INST.DataAdd();
        }

        private void INST_InstanceEdit_Button_Click(object sender, EventArgs e)
        {
            PROG_INST.DataEdit();
        }

        private void INST_Data_GridView_DoubleClick(object sender, EventArgs e)
        {
            if (((GridView)sender).CalcHitInfo(((DXMouseEventArgs)e).Location).InRow) PROG_INST.DataEdit();
        }
    }
}
