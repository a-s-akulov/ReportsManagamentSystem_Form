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
    public partial class ToDateForm : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public int resultToDateId = -1;

        public ToDateForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            foreach (int toDateId in PARENT.toDateIds) ToDate_ListBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportToDates[toDateId]["name"]);
            ToDate_ListBox.SelectedIndex = 0;

            ActiveControl = ToDate_ListBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultToDateId = PARENT.toDateIds[ToDate_ListBox.SelectedIndex];
            DialogResult = DialogResult.Yes;
        }
    }
}
