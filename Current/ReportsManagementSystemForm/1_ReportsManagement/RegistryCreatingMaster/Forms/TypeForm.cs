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
    public partial class TypeForm : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public int resultTypeId = -1;

        public TypeForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            foreach (int typeId in PARENT.typeIds) Type_ListBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportTypes[typeId]["name"]);
            Type_ListBox.SelectedIndex = 0;

            ActiveControl = Type_ListBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultTypeId = PARENT.typeIds[Type_ListBox.SelectedIndex];
            DialogResult = DialogResult.Yes;
        }
    }
}
