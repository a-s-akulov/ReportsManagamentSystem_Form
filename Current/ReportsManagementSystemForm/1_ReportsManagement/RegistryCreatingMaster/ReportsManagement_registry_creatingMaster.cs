using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ReportsManagementSystemForm
{
    public partial class Pass { }

    public partial class ReportsManagement_registry_creatingMaster
    {

        public readonly ReportsManagement_main MANAGEMENT_FORM;
        public readonly int STATUS_ACTIVE;
        public readonly int STATUS_NOT_ACTIVE;

        public int[] groupIds;
        public int[] brandIds;
        public int[] typeIds;
        public int[] frequencyIds;
        public int[] toDateIds;
        public int[] departmentIds;

        private string nameNew = "";
        private int groupIdNew = -1;
        private int brandIdNew = -1;
        private int typeIdNew = -1;
        private int frequencyIdNew = -1;
        private int toDateIdNew = -1;
        private int departmentIdNew = -1;

        private int responsiblePersonIdNew = -1;

        private string contentDescriptionNew = "";
        private string remarkNew = "";
        private string filesPathNew = "";
        private string sqlTemplatesPathNew = "";

        private bool notifyDepartmentHeadNew = false;
        private int statusIdNew = -1;

        public ReportsManagement_registry_creatingMaster(ReportsManagement_main managementForm)
        {
            MANAGEMENT_FORM = managementForm;
            STATUS_ACTIVE = Constances.STATUS_ACTIVE;
            STATUS_NOT_ACTIVE = Constances.STATUS_NOT_ACTIVE;

            Init();
            MasterController();
        }


        private void Init()
        {
            // Заполнение переменных справочника
            foreach (Tuple<string, Dictionary<int, Dictionary<string, string>>> items in
                new Tuple<string, Dictionary<int, Dictionary<string, string>>>[] {

                    new Tuple<string, Dictionary<int, Dictionary<string, string>>>
                        ("groupId", MANAGEMENT_FORM.MAIN.PROG.directoryReportGroups),

                    new Tuple<string, Dictionary<int, Dictionary<string, string>>>
                        ("brandId", MANAGEMENT_FORM.MAIN.PROG.directoryBrands),

                    new Tuple<string, Dictionary<int, Dictionary<string, string>>>
                        ("typeId", MANAGEMENT_FORM.MAIN.PROG.directoryReportTypes),

                    new Tuple<string, Dictionary<int, Dictionary<string, string>>>
                        ("frequencyId", MANAGEMENT_FORM.MAIN.PROG.directoryReportFrequencies),

                    new Tuple<string, Dictionary<int, Dictionary<string, string>>>
                        ("toDateId", MANAGEMENT_FORM.MAIN.PROG.directoryReportToDates),

                    new Tuple<string, Dictionary<int, Dictionary<string, string>>>
                        ("departmentId", MANAGEMENT_FORM.MAIN.PROG.directoryDepartments)
            })
            {
                string columnName = items.Item1;
                var directory = items.Item2;

                int[] ids = directory.Values
                    .Where(v => v["statusId"] == STATUS_ACTIVE.ToString())
                    .Select(v => int.Parse(v[columnName]))
                    .ToArray();

                if (columnName == "groupId") groupIds = ids;
                else if (columnName == "brandId") brandIds = ids;
                else if (columnName == "typeId") typeIds = ids;
                else if (columnName == "frequencyId") frequencyIds = ids;
                else if (columnName == "toDateId") toDateIds = ids;
                else if (columnName == "departmentId") departmentIds = ids;
            }
        }


        private void MasterController(string startSector = "name")
        {
            var nameForm = new ReportsManagement_registry_creatingMaster_forms.NameForm();
            var groupForm = new ReportsManagement_registry_creatingMaster_forms.GroupForm(this);
            var brandForm = new ReportsManagement_registry_creatingMaster_forms.BrandForm(this);
            var typeForm = new ReportsManagement_registry_creatingMaster_forms.TypeForm(this);
            var frequencyForm = new ReportsManagement_registry_creatingMaster_forms.FrequencyForm(this);
            var toDateForm = new ReportsManagement_registry_creatingMaster_forms.ToDateForm(this);
            var responsiblePersonForm = new ReportsManagement_registry_creatingMaster_forms.ResponsiblePerson(this);
            var departmentForm = new ReportsManagement_registry_creatingMaster_forms.DepartmentForm(this);
            var contentDescriptionForm = new ReportsManagement_registry_creatingMaster_forms.ContentDescriptionForm(this);
            var remarkForm = new ReportsManagement_registry_creatingMaster_forms.RemarkForm(this);
            var filesPathForm = new ReportsManagement_registry_creatingMaster_forms.FilesPathForm(this);
            var sqlTemplatesPathForm = new ReportsManagement_registry_creatingMaster_forms.SQLTemplatesPathForm(this);
            var otherForm = new ReportsManagement_registry_creatingMaster_forms.OtherForm(this);
            var statusForm = new ReportsManagement_registry_creatingMaster_forms.StatusForm(this);

            bool isCanceled = false;
            string currentSectorName = startSector;
            while (true)
            {
                // NAME
                if (currentSectorName == "name")
                {
                    if (DialogResult.Yes == nameForm.ShowDialog())
                    {
                        nameNew = nameForm.resultName;
                        currentSectorName = "group";
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show($"Уверены, что хотите отменить операцию?\n\nНесохраненные данные будут потеряны",
                        "Отменить создание отчёта?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        {
                            isCanceled = true;
                            break;
                        }
                    }
                }

                // GROUP
                if (currentSectorName == "group")
                {
                    if (DialogResult.Yes == groupForm.ShowDialog())
                    {
                        groupIdNew = groupForm.resultGroupId;
                        currentSectorName = "brand";
                    }
                    else
                    {
                        currentSectorName = "name";
                        continue;
                    }
                }

                // BRAND
                if (currentSectorName == "brand")
                {
                    if (DialogResult.Yes == brandForm.ShowDialog())
                    {
                        brandIdNew = brandForm.resultBrandId;
                        currentSectorName = "type";
                    }
                    else
                    {
                        currentSectorName = "group";
                        continue;
                    }
                }

                // TYPE
                if (currentSectorName == "type")
                {
                    if (DialogResult.Yes == typeForm.ShowDialog())
                    {
                        typeIdNew = typeForm.resultTypeId;
                        currentSectorName = "frequency";
                    }
                    else
                    {
                        currentSectorName = "brand";
                        continue;
                    }
                }

                // FREQUENCY
                if (currentSectorName == "frequency")
                {
                    if (DialogResult.Yes == frequencyForm.ShowDialog())
                    {
                        frequencyIdNew = frequencyForm.resultFrequencyId;
                        currentSectorName = "toDate";
                    }
                    else
                    {
                        currentSectorName = "type";
                        continue;
                    }
                }

                // TO DATE
                if (currentSectorName == "toDate")
                {
                    if (DialogResult.Yes == toDateForm.ShowDialog())
                    {
                        toDateIdNew = toDateForm.resultToDateId;
                        currentSectorName = "responsiblePerson";
                    }
                    else
                    {
                        currentSectorName = "frequency";
                        continue;
                    }
                }

                // RESPONSIBLE PERSON
                if (currentSectorName == "responsiblePerson")
                {
                    if (DialogResult.Yes == responsiblePersonForm.ShowDialog())
                    {
                        responsiblePersonIdNew = responsiblePersonForm.resultResponsiblePersonId;
                        currentSectorName = "department";
                    }
                    else
                    {
                        currentSectorName = "toDate";
                        continue;
                    }
                }

                // DEPARTMENT
                if (currentSectorName == "department")
                {
                    if (DialogResult.Yes == departmentForm.ShowDialog())
                    {
                        departmentIdNew = departmentForm.resultDepartmentId;
                        currentSectorName = "contentDescription";
                    }
                    else
                    {
                        currentSectorName = "responsiblePerson";
                        continue;
                    }
                }

                // CONTENT DESCRIPTION
                if (currentSectorName == "contentDescription")
                {
                    if (DialogResult.Yes == contentDescriptionForm.ShowDialog())
                    {
                        contentDescriptionNew = contentDescriptionForm.resultContentDescription;
                        currentSectorName = "remark";
                    }
                    else
                    {
                        currentSectorName = "department";
                        continue;
                    }
                }

                // REMARK
                if (currentSectorName == "remark")
                {
                    if (DialogResult.Yes == remarkForm.ShowDialog())
                    {
                        remarkNew = remarkForm.resultRemark;
                        currentSectorName = "filesPath";
                    }
                    else
                    {
                        currentSectorName = "contentDescription";
                        continue;
                    }
                }

                // FILES PATH
                if (currentSectorName == "filesPath")
                {
                    if (DialogResult.Yes == filesPathForm.ShowDialog())
                    {
                        filesPathNew = filesPathForm.resultFilesPath;
                        currentSectorName = "sqlTemplatesPath";
                    }
                    else
                    {
                        currentSectorName = "remark";
                        continue;
                    }
                }

                // SQL TEMPLATES PATH
                if (currentSectorName == "sqlTemplatesPath")
                {
                    if (DialogResult.Yes == sqlTemplatesPathForm.ShowDialog())
                    {
                        sqlTemplatesPathNew = sqlTemplatesPathForm.resultSQLTemplatesPath;
                        currentSectorName = "other";
                    }
                    else
                    {
                        currentSectorName = "filesPath";
                        continue;
                    }
                }

                // OTHER
                if (currentSectorName == "other")
                {
                    if (DialogResult.Yes == otherForm.ShowDialog())
                    {
                        notifyDepartmentHeadNew = otherForm.resultNotifyDepartmentHead;
                        currentSectorName = "status";
                    }
                    else
                    {
                        currentSectorName = "sqlTemplatesPath";
                        continue;
                    }
                }

                // STATUS
                if (currentSectorName == "status")
                {
                    if (DialogResult.Yes == statusForm.ShowDialog())
                    {
                        statusIdNew = statusForm.resultStatusId;

                        if (DialogResult.Yes == MessageBox.Show($"Ввод данных завершен, сохранить их на сервере?",
                        "Отправить введенные данные?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) break;
                    }
                    else
                    {
                        currentSectorName = "other";
                        continue;
                    }
                }
            }

            nameForm.Dispose();
            groupForm.Dispose();
            brandForm.Dispose();
            typeForm.Dispose();
            frequencyForm.Dispose();
            toDateForm.Dispose();
            responsiblePersonForm.Dispose();
            departmentForm.Dispose();
            contentDescriptionForm.Dispose();
            remarkForm.Dispose();
            filesPathForm.Dispose();
            sqlTemplatesPathForm.Dispose();
            otherForm.Dispose();
            statusForm.Dispose();

            if (isCanceled) return;

            ChangesAccept();
            MessageBox.Show("Новый отчёт полностью настроен! Ура!\n\nРабота мастера создания отчёта завершена.", "Работа мастера завершена",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            if (MANAGEMENT_FORM.PROG_REG.departmentIds.Contains(departmentIdNew)) MANAGEMENT_FORM.REG_department_ComboBox.SelectedIndex = Array.IndexOf 
            (
                MANAGEMENT_FORM.PROG_REG.departmentIds,
                departmentIdNew
            );
            MANAGEMENT_FORM.PROG_REG.DataGet();
        }


        /// <summary>
        /// Применить изменения
        /// </summary>
        private void ChangesAccept()
        {
            // Работа с SQL
            SqlParameter[] parameters =
            {
                new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@recordId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@mode", SqlDbType.VarChar) { Value = "ADD" },
                new SqlParameter("@nameNew", SqlDbType.VarChar) { Value = nameNew },
                new SqlParameter("@groupIdNew", SqlDbType.Int) { Value = groupIdNew },
                new SqlParameter("@brandIdNew", SqlDbType.Int) { Value = brandIdNew },
                new SqlParameter("@typeIdNew", SqlDbType.Int) { Value = typeIdNew },
                new SqlParameter("@frequencyIdNew", SqlDbType.Int) { Value = frequencyIdNew },
                new SqlParameter("@toDateIdNew", SqlDbType.Int) { Value = toDateIdNew },
                new SqlParameter("@departmentIdNew", SqlDbType.Int) { Value = departmentIdNew },

                new SqlParameter("@responsiblePersonIdNew", SqlDbType.Int) { Value = responsiblePersonIdNew },

                new SqlParameter("@contentDescriptionNew", SqlDbType.VarChar) { Value = contentDescriptionNew },
                new SqlParameter("@remarkNew", SqlDbType.VarChar) { Value = remarkNew },
                new SqlParameter("@filesPathNew", SqlDbType.VarChar) { Value = filesPathNew },
                new SqlParameter("@sqlTemplatesPathNew", SqlDbType.VarChar) { Value = sqlTemplatesPathNew },
                new SqlParameter("@notifyDepartmentHeadNew", SqlDbType.Bit) { Value = notifyDepartmentHeadNew },
                new SqlParameter("@statusIdNew", SqlDbType.Int) { Value = statusIdNew }

            };
            Tuple<bool, DataSet> resultSql = MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("ReportsRegistryUniversalChangerAndCreator", parameters);
            if (resultSql.Item1)
            {
                int resultSqlProcedure = (int)parameters[0].Value;
                if (resultSqlProcedure != 0)
                {
                    string errorText;
                    if (resultSqlProcedure == Constances.ERROR_ACCESS_DENIED_ERROR)
                        errorText = "Ошибка: Отказано в доступе";
                    else if (resultSqlProcedure == Constances.ERROR_RECORD_ALREADY_EXISTS_ERROR)
                        errorText = "Ошибка: данный пользователь уже существует";
                    else if (resultSqlProcedure == Constances.ERROR_SOURSE_NOT_FOUND_ERROR)
                        errorText = "Ошибка: указанный пользователь не найден";
                    else errorText = $"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}";

                    MessageBox.Show(errorText,
                        "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else return;
            int reportId = (int)parameters[1].Value;

            MANAGEMENT_FORM.PROG_REG.departmentIdCurrent = departmentIdNew;
            MANAGEMENT_FORM.REG_department_ComboBox.SelectedIndex = Array.IndexOf(MANAGEMENT_FORM.PROG_REG.departmentIds, departmentIdNew);

            MessageBox.Show("Процедура изменения/добавления отчёта в реестре выполнена успешно.\n\nОсталось только настроить пользователей отчёта", "Новые данные отчёта в реестре",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            var usersEditor = new ReportsManagement_registry_users_editor(MANAGEMENT_FORM, reportId);
            if (!usersEditor.IsDisposed) usersEditor.ShowDialog();
        }
    }
}