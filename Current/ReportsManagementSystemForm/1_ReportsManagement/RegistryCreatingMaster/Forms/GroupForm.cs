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
    public partial class GroupForm : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public int resultGroupId = -1;

        public GroupForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            foreach (int groupId in PARENT.groupIds) Group_ListBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportGroups[groupId]["name"]);
            Group_ListBox.SelectedIndex = 0;

            ActiveControl = Group_ListBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultGroupId = PARENT.groupIds[Group_ListBox.SelectedIndex];
            DialogResult = DialogResult.Yes;
        }
    }
}
