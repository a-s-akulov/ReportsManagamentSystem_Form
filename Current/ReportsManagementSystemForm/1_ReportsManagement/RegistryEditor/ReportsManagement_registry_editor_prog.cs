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

    public partial class ReportsManagement_registry_editor
    {
        public class MyProgram
        {
            public readonly ReportsManagement_registry_editor PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;

            public int recordIdCurrent = -1;
            public int responsiblePersonId = -1;

            public int[] groupIds;
            public int[] brandIds;
            public int[] typeIds;
            public int[] frequencyIds;
            public int[] toDateIds;
            public int[] departmentIds;

            public MyProgram(ReportsManagement_registry_editor parent)
            {
                PARENT = parent;
                STATUS_ACTIVE = Constances.STATUS_ACTIVE;
                STATUS_NOT_ACTIVE = Constances.STATUS_NOT_ACTIVE;

                ControlsTextsFill();
                if (PARENT.Mode == "EDIT") DataFieldsFill();
            }


            /// <summary>
            /// Устанавливает имена элементов управленя для корреткного отображения
            /// </summary>
            private void ControlsTextsFill()
            {
                if (PARENT.Mode == "ADD") PARENT.Text += "добавление";
                else if (PARENT.Mode == "EDIT") PARENT.Text += "редактирование";

                // Заполнение переменных корректными записями для ComboBox
                foreach (Tuple<string, Dictionary<int, Dictionary<string, string>>, ComboBox> items in
                    new Tuple<string, Dictionary<int, Dictionary<string, string>>, ComboBox>[] {

                        new Tuple<string, Dictionary<int, Dictionary<string, string>>, ComboBox>
                            ("groupId", PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportGroups, PARENT.Group_ComboBox ),

                        new Tuple<string, Dictionary<int, Dictionary<string, string>>, ComboBox>
                            ("brandId", PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryBrands, PARENT.Brand_ComboBox ),

                        new Tuple<string, Dictionary<int, Dictionary<string, string>>, ComboBox>
                            ("typeId", PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportTypes, PARENT.Type_ComboBox ),

                        new Tuple<string, Dictionary<int, Dictionary<string, string>>, ComboBox>
                            ("frequencyId", PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportFrequencies, PARENT.Frequency_ComboBox ),

                        new Tuple<string, Dictionary<int, Dictionary<string, string>>, ComboBox>
                            ("toDateId", PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportToDates, PARENT.ToDate_ComboBox ),

                        new Tuple<string, Dictionary<int, Dictionary<string, string>>, ComboBox>
                            ("departmentId", PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments, PARENT.Department_ComboBox )
                })
                {
                    string columnName = items.Item1;
                    var directory = items.Item2;
                    ComboBox control = items.Item3;

                    int[] ids = directory.Values
                        .Where(v => v["statusId"] == STATUS_ACTIVE.ToString())
                        .Select(v => int.Parse(v[columnName]))
                        .ToArray();

                    foreach (int recordId in ids)
                        control.Items.Add(directory[recordId]["name"]);
                    if (control.Items.Count > 0) control.SelectedIndex = 0;
                    control.DropDownStyle = ComboBoxStyle.DropDownList;

                    if (columnName == "groupId") groupIds = ids;
                    else if (columnName == "brandId") brandIds = ids;
                    else if (columnName == "typeId") typeIds = ids;
                    else if (columnName == "frequencyId") frequencyIds = ids;
                    else if (columnName == "toDateId") toDateIds = ids;
                    else if (columnName == "departmentId") departmentIds = ids;
                }

                // department - поправка
                PARENT.Department_ComboBox.SelectedIndex = Array.IndexOf(departmentIds, PARENT.MANAGEMENT_FORM.PROG_REG.departmentIdCurrent);


                // Остальное
                PARENT.Status_Active_RadioButton.Text = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryStatuses[STATUS_ACTIVE]["name"];
                PARENT.Status_NotActive_RadioButton.Text = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryStatuses[STATUS_NOT_ACTIVE]["name"];
            }


            /// <summary>
            /// Заполняет данные при режиме редактирования
            /// </summary>
            private void DataFieldsFill()
            {
                int[] selectedRowsIds = PARENT.MANAGEMENT_FORM.REG_Data_GridView.GetSelectedRows();
                if (selectedRowsIds.Count() == 0 || selectedRowsIds[0] < 0)
                {
                    MessageBox.Show("Не выбрана ни одна строка", "Редактирование записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PARENT.Close();
                    return;
                }

                DataRow rowRaw = PARENT.MANAGEMENT_FORM.PROG_REG.DataRaw.Rows[selectedRowsIds[0]];
                DataRow rowVisible = PARENT.MANAGEMENT_FORM.PROG_REG.DataVisible.Rows[selectedRowsIds[0]];
                recordIdCurrent = (int)rowRaw[0];

                int groupId = (int)rowRaw["groupId"];
                int brandId = (int)rowRaw["brandId"];
                int typeId = (int)rowRaw["typeId"];
                int frequencyId = (int)rowRaw["frequencyId"];
                int toDateId = (int)rowRaw["toDateId"];
                int departmentId = (int)rowRaw["departmentId"];

                responsiblePersonId = (int)rowRaw["responsiblePersonId"];

                PARENT.ReportId_TextBox.Text = recordIdCurrent.ToString();
                PARENT.Name_TextBox.Text = (string)rowRaw["name"];


                // groupId
                if (groupIds.Contains(groupId)) PARENT.Group_ComboBox.SelectedIndex = Array.IndexOf(groupIds, groupId);
                else
                {
                    int[] a = new int[groupIds.Length + 1];
                    a[0] = groupId;
                    groupIds.CopyTo(a, 1);
                    groupIds = a;

                    PARENT.Group_ComboBox.Items.Clear();
                    foreach (int groupId_ in groupIds)
                        PARENT.Group_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportGroups[groupId_]["name"]);
                    PARENT.Group_ComboBox.SelectedIndex = 0;
                }

                // brandId
                if (brandIds.Contains(brandId)) PARENT.Brand_ComboBox.SelectedIndex = Array.IndexOf(brandIds, brandId);
                else
                {
                    int[] a = new int[brandIds.Length + 1];
                    a[0] = brandId;
                    brandIds.CopyTo(a, 1);
                    brandIds = a;

                    PARENT.Brand_ComboBox.Items.Clear();
                    foreach (int brandId_ in brandIds)
                        PARENT.Brand_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryBrands[brandId_]["name"]);
                    PARENT.Brand_ComboBox.SelectedIndex = 0;
                }

                // typeId
                if (typeIds.Contains(typeId)) PARENT.Type_ComboBox.SelectedIndex = Array.IndexOf(typeIds, typeId);
                else
                {
                    int[] a = new int[typeIds.Length + 1];
                    a[0] = typeId;
                    typeIds.CopyTo(a, 1);
                    typeIds = a;

                    PARENT.Type_ComboBox.Items.Clear();
                    foreach (int typeId_ in typeIds)
                        PARENT.Type_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportTypes[typeId_]["name"]);
                    PARENT.Type_ComboBox.SelectedIndex = 0;
                }

                // frequencyId
                if (frequencyIds.Contains(frequencyId)) PARENT.Frequency_ComboBox.SelectedIndex = Array.IndexOf(frequencyIds, frequencyId);
                else
                {
                    int[] a = new int[frequencyIds.Length + 1];
                    a[0] = frequencyId;
                    frequencyIds.CopyTo(a, 1);
                    frequencyIds = a;

                    PARENT.Frequency_ComboBox.Items.Clear();
                    foreach (int frequencyId_ in frequencyIds)
                        PARENT.Frequency_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportFrequencies[frequencyId_]["name"]);
                    PARENT.Frequency_ComboBox.SelectedIndex = 0;
                }

                // toDateId
                if (toDateIds.Contains(toDateId)) PARENT.ToDate_ComboBox.SelectedIndex = Array.IndexOf(toDateIds, toDateId);
                else
                {
                    int[] a = new int[toDateIds.Length + 1];
                    a[0] = toDateId;
                    toDateIds.CopyTo(a, 1);
                    toDateIds = a;

                    PARENT.ToDate_ComboBox.Items.Clear();
                    foreach (int toDateId_ in toDateIds)
                        PARENT.ToDate_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryReportToDates[toDateId_]["name"]);
                    PARENT.ToDate_ComboBox.SelectedIndex = 0;
                }

                // departmentId
                if (departmentIds.Contains(departmentId)) PARENT.Department_ComboBox.SelectedIndex = Array.IndexOf(departmentIds, departmentId);
                else
                {
                    int[] a = new int[departmentIds.Length + 1];
                    a[0] = departmentId;
                    departmentIds.CopyTo(a, 1);
                    departmentIds = a;

                    PARENT.Department_ComboBox.Items.Clear();
                    foreach (int departmentId_ in departmentIds)
                        PARENT.Department_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments[departmentId_]["name"]);
                    PARENT.Department_ComboBox.SelectedIndex = 0;
                }

                PARENT.ResponsiblePerson_show_TextBox.Text = (string)rowVisible["responsiblePersonId_Name"];

                PARENT.ContentDescription_show_TextBox.Text = (string)rowRaw["contentDescription"];
                PARENT.Remark_show_TextBox.Text = (string)rowRaw["remark"];
                PARENT.FilesPath_show_TextBox.Text = (string)rowRaw["filesPath"];
                PARENT.SqlTemplatesPath_show_TextBox.Text = (string)rowRaw["sqlTemplatesPath"];
                PARENT.NotifyDepartmentHead_CheckBox.Checked = (bool)rowRaw["notifyDepartmentHead"];

                if ((int)rowRaw["statusId"] == STATUS_ACTIVE) PARENT.Status_Active_RadioButton.Checked = true;
                else PARENT.Status_NotActive_RadioButton.Checked = true;
            }


            public void ResponsoblePersonEdit()
            {
                DataTable responsiblePersonTable = new DataTable();
                new ModuleUserSelect(PARENT.MANAGEMENT_FORM.MAIN, responsiblePersonTable).ShowDialog();

                if (responsiblePersonTable.Rows.Count == 0) return;

                responsiblePersonId = (int)responsiblePersonTable.Rows[0]["userId"];

                PARENT.ResponsiblePerson_show_TextBox.Text = $"[{responsiblePersonTable.Rows[0]["userId"]}] {responsiblePersonTable.Rows[0]["name"]} " +
                    $"({responsiblePersonTable.Rows[0]["nameDomain"]})";
            }


            public void RichTextEdit(string paramName)
            {
                TextBox textBox;

                switch (paramName)
                {
                    case "contentDescription":
                        textBox = PARENT.ContentDescription_show_TextBox;
                        break;

                    case "remark":
                        textBox = PARENT.Remark_show_TextBox;
                        break;

                    case "filesPath":
                        textBox = PARENT.FilesPath_show_TextBox;
                        break;

                    case "sqlTemplatesPath":
                        textBox = PARENT.SqlTemplatesPath_show_TextBox;
                        break;

                    default:
                        return;
                }

                ModuleTextInput module = new ModuleTextInput(maxResultLength: 250, startValue: textBox.Text);
                if (module.ShowDialog() != DialogResult.OK) return;

                textBox.Text = module.resultString;
            }


            /// <summary>
            /// Применить изменения
            /// </summary>
            public void ChangesAccept()
            {
                DialogResult resultDialog;

                string nameNew = PARENT.Name_TextBox.Text.Trim(' ', '\n', '\t');
                int groupIdNew = groupIds[PARENT.Group_ComboBox.SelectedIndex];
                int brandIdNew = brandIds[PARENT.Brand_ComboBox.SelectedIndex];
                int typeIdNew = typeIds[PARENT.Type_ComboBox.SelectedIndex];
                int frequencyIdNew = frequencyIds[PARENT.Frequency_ComboBox.SelectedIndex];
                int toDateIdNew = toDateIds[PARENT.ToDate_ComboBox.SelectedIndex];
                int departmentIdNew = departmentIds[PARENT.Department_ComboBox.SelectedIndex];

                int responsiblePersonIdNew = responsiblePersonId;

                string contentDescriptionNew = PARENT.ContentDescription_show_TextBox.Text.Trim(' ', '\n', '\t');
                string remarkNew = PARENT.Remark_show_TextBox.Text.Trim(' ', '\n', '\t');
                string filesPathNew = PARENT.FilesPath_show_TextBox.Text.Trim(' ', '\n', '\t');
                string sqlTemplatesPathNew = PARENT.SqlTemplatesPath_show_TextBox.Text.Trim(' ', '\n', '\t');
                bool notifyDepartmentHeadNew = PARENT.NotifyDepartmentHead_CheckBox.Checked;
                int statusIdNew = PARENT.Status_Active_RadioButton.Checked ? STATUS_ACTIVE : STATUS_NOT_ACTIVE;

                // ПРОВЕРКА ВВЕДЕННЫХ ДАННЫХ
                // name
                if (nameNew == "")
                {
                    MessageBox.Show("Имя отчёта не может быть пустым", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                // responsiblePerson
                if (responsiblePersonIdNew == -1)
                {
                    MessageBox.Show("Должно быть указано ответственное лицо",
                        "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                // departmentId
                if (departmentIdNew != (int)PARENT.MANAGEMENT_FORM.MAIN.PROG.currentUserInfo.Rows[0]["departmentId"])
                {
                    if (DialogResult.Yes != MessageBox.Show($"Для отчёта вы указали не свой отдел, продолжить?",
                        "Создание/изменение отчёта для другого отдела", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)) return;
                }
                // contentDescription
                if (contentDescriptionNew == "")
                {
                    MessageBox.Show("Описание содержания отчёта не может быть пустым", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Диалог подтверждения изменений
                resultDialog = MessageBox.Show($"Сохранить новые данные?",
                    "Подтверждение изменений", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDialog != DialogResult.Yes) return;

                // Работа с SQL
                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@mode", SqlDbType.VarChar) { Value = PARENT.Mode },
                    new SqlParameter("@recordId", SqlDbType.Int) { Value = recordIdCurrent },
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
                Tuple<bool, DataSet> resultSql = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("ReportsRegistryUniversalChangerAndCreator", parameters);
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

                MessageBox.Show("Процедура изменения/добавления отчёта в реестре выполнена успешно.", "Новые данные отчёта в реестре",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!PARENT.MANAGEMENT_FORM.MAIN.PROG.CurrentUserReportsPermissionsGet(PARENT)) return;
                PARENT.MANAGEMENT_FORM.PROG_REG.DataGet();
                PARENT.Close();
            }
        }
    }
}