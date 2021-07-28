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
    public partial class FrequencyForm : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public int resultFrequencyId = -1;

        public FrequencyForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            foreach (int frequencyId in PARENT.frequencyIds) Frequency_ListBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportFrequencies[frequencyId]["name"]);
            Frequency_ListBox.SelectedIndex = 0;

            ActiveControl = Frequency_ListBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultFrequencyId = PARENT.frequencyIds[Frequency_ListBox.SelectedIndex];
            DialogResult = DialogResult.Yes;
        }
    }
}
