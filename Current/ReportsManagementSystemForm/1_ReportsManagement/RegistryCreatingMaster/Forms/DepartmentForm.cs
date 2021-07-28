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
    public partial class DepartmentForm : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public int resultDepartmentId = -1;

        public DepartmentForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            foreach (int departmentId in PARENT.departmentIds) Department_ListBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments[departmentId]["name"]);
            Department_ListBox.SelectedIndex = Array.IndexOf(PARENT.departmentIds, PARENT.MANAGEMENT_FORM.PROG_REG.departmentIdCurrent);

            ActiveControl = Department_ListBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultDepartmentId = PARENT.departmentIds[Department_ListBox.SelectedIndex];
            if (resultDepartmentId != (int)PARENT.MANAGEMENT_FORM.MAIN.PROG.currentUserInfo.Rows[0]["departmentId"])
            {
                if (DialogResult.Yes != MessageBox.Show($"Для отчёта вы указали не свой отдел, продолжить?",
                    "Создание отчёта для другого отдела", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)) return;
            }

            DialogResult = DialogResult.Yes;
        }
    }
}
