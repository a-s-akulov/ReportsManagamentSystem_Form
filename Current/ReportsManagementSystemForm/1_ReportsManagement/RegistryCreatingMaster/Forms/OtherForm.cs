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
    public partial class OtherForm : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public bool resultNotifyDepartmentHead = false;

        public OtherForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            ActiveControl = NotifyDepartmentHead_CheckBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultNotifyDepartmentHead = NotifyDepartmentHead_CheckBox.Checked;
            DialogResult = DialogResult.Yes;
        }
    }
}
