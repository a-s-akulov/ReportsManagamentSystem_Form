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
    public partial class BrandForm : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public int resultBrandId = -1;

        public BrandForm(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            foreach (int brandId in PARENT.brandIds) Brand_ListBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryBrands[brandId]["name"]);
            Brand_ListBox.SelectedIndex = 0;

            ActiveControl = Brand_ListBox;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            resultBrandId = PARENT.brandIds[Brand_ListBox.SelectedIndex];
            DialogResult = DialogResult.Yes;
        }
    }
}
