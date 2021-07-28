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
    public partial class StatusForm : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public int resultStatusId = -1;

        public StatusForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            Status_Active_RadioButton.Text = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryStatuses[PARENT.STATUS_ACTIVE]["name"];
            Status_NotActive_RadioButton.Text = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryStatuses[PARENT.STATUS_NOT_ACTIVE]["name"];

            ActiveControl = Status_Active_RadioButton;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Finish_Button_Click(object sender, EventArgs e)
        {
            resultStatusId = Status_Active_RadioButton.Checked ? PARENT.STATUS_ACTIVE : PARENT.STATUS_NOT_ACTIVE;
            DialogResult = DialogResult.Yes;
        }
    }
}
