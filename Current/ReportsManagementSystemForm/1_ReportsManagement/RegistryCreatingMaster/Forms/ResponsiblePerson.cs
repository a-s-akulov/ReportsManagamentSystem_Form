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
    public partial class ResponsiblePerson : Form
    {
        private ReportsManagement_registry_creatingMaster PARENT;
        public int resultResponsiblePersonId = -1;

        public ResponsiblePerson(ReportsManagement_registry_creatingMaster parent)
        {
            InitializeComponent();

            PARENT = parent;
            Init();
        }

        private void Init()
        {
            ActiveControl = ResponsiblePerson_edit_Button;
        }

        private void ResponsiblePerson_edit_Button_Click(object sender, EventArgs e)
        {
            DataTable responsiblePersonTable = new DataTable();
            new ModuleUserSelect(PARENT.MANAGEMENT_FORM.MAIN, responsiblePersonTable).ShowDialog();

            if (responsiblePersonTable.Rows.Count == 0) return;

            resultResponsiblePersonId = (int)responsiblePersonTable.Rows[0]["userId"];

            ResponsiblePerson_TextBox.Text = $"[{responsiblePersonTable.Rows[0]["userId"]}] {responsiblePersonTable.Rows[0]["name"]} ({responsiblePersonTable.Rows[0]["nameDomain"]})";
            ActiveControl = Next_Button;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void Next_Button_Click(object sender, EventArgs e)
        {
            if (resultResponsiblePersonId == -1)
            {
                MessageBox.Show("Должно быть указано ответственное лицо",
                    "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult = DialogResult.Yes;
        }
    }
}
