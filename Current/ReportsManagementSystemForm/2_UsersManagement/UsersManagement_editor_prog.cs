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
using System.DirectoryServices;

namespace ReportsManagementSystemForm
{
    public partial class Pass { }

    public partial class UsersManagement_editor
    {
        public class MyProgram
        {
            public readonly UsersManagement_editor PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;
            public int recordIdCurrent = -1;
            public string nameCurrent = "";
            public string nameDomainCurrent = "";
            public string emailCurrent = "";
            public int departmentIdCurrent = -1;
            public int statusIdCurrent = -1;
            public bool generalPermissionCurrent_DirectoryManagement = false;
            public bool generalPermissionCurrent_UsersManagement = false;
            public bool generalPermissionCurrent_ReportsManagement = false;
            public int[] departmentIds;

            public MyProgram(UsersManagement_editor parent)
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

                // department
                departmentIds = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments.Values
                    .Where(v => v["statusId"] == STATUS_ACTIVE.ToString())
                    .Select(v => int.Parse(v["departmentId"]))
                    .ToArray();

                int indexToSelect = 0;
                if (PARENT.Mode == "ADD")
                {
                    int currentUserDepartmentId = (int)PARENT.MANAGEMENT_FORM.MAIN.PROG.currentUserInfo.Rows[0]["departmentId"];
                    if (departmentIds.Contains(currentUserDepartmentId)) indexToSelect = Array.IndexOf(departmentIds, currentUserDepartmentId);
                }
                
                foreach (int departmentId in departmentIds)
                    PARENT.Department_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments[departmentId]["name"]);
                if (PARENT.Department_ComboBox.Items.Count > 0) PARENT.Department_ComboBox.SelectedIndex = indexToSelect;
                PARENT.Department_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                // Остальное

                PARENT.Status_Active_RadioButton.Text = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryStatuses[STATUS_ACTIVE]["name"];
                PARENT.Status_NotActive_RadioButton.Text = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryStatuses[STATUS_NOT_ACTIVE]["name"];
            }


            /// <summary>
            /// Заполняет данные при режиме редактирования
            /// </summary>
            private void DataFieldsFill()
            {
                int[] selectedRowsIds = PARENT.MANAGEMENT_FORM.Show_GridView.GetSelectedRows();
                if (selectedRowsIds.Count() == 0 || selectedRowsIds[0] < 0)
                {
                    MessageBox.Show("Не выбрана ни одна строка", "Редактирование записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PARENT.Close();
                    return;
                }

                DataRow row = PARENT.MANAGEMENT_FORM.PROG.usersDataRaw.Rows[selectedRowsIds[0]];
                recordIdCurrent = (int)row[0];


                nameCurrent = (string)row["name"];
                nameDomainCurrent = (string)row["nameDomain"];
                emailCurrent = (string)row["email"];

                PARENT.ID_TextBox.Text = recordIdCurrent.ToString();
                PARENT.Name_TextBox.Text = nameCurrent;
                PARENT.NameDomain_TextBox.Text = nameDomainCurrent;
                PARENT.Email_TextBox.Text = emailCurrent;

                // department
                departmentIdCurrent = (int)row["departmentId"];
                if (departmentIds.Contains(departmentIdCurrent)) PARENT.Department_ComboBox.SelectedIndex = Array.IndexOf(departmentIds, departmentIdCurrent); else
                {
                    int[] a = new int[departmentIds.Length + 1];
                    a[0] = departmentIdCurrent;
                    departmentIds.CopyTo(a, 1);
                    departmentIds = a;

                    PARENT.Department_ComboBox.Items.Clear();
                    foreach (int departmentId in departmentIds)
                        PARENT.Department_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments[departmentId]["name"]);
                    PARENT.Department_ComboBox.SelectedIndex = 0;
                }

                // status
                statusIdCurrent = (int)row["statusId"];
                if (statusIdCurrent == STATUS_ACTIVE) PARENT.Status_Active_RadioButton.Select();
                else if (statusIdCurrent == STATUS_NOT_ACTIVE) PARENT.Status_NotActive_RadioButton.Select();

                // generalPermissions
                SqlParameter[] paramsSql = new SqlParameter[] {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@isGeneralPermission_DirectoryManagement", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                    new SqlParameter("@isGeneralPermission_UsersManagement", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                    new SqlParameter("@isGeneralPermission_ReportsManagement", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                    new SqlParameter("@userId", SqlDbType.Int) { Value = recordIdCurrent }
                };
                Tuple<bool, DataSet> result = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("UserGeneralPermissionsGet", paramsSql);
                if (!result.Item1) {
                    MessageBox.Show("Окно редактора будет закрыто", "Ошибка инициализации редактора пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PARENT.Close();
                    return;
                }
                int resultErrorId = (int)paramsSql[0].Value;
                if (resultErrorId != 0)
                {
                    MessageBox.Show($"Ошибка выполнения процедуры запроса разрешений пользователя. Процедура вернула код: {resultErrorId}.\n\nОкно редактора будет закрыто",
                        "Ошибка инициализации редактора пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                generalPermissionCurrent_DirectoryManagement = (bool)paramsSql[1].Value;
                generalPermissionCurrent_UsersManagement = (bool)paramsSql[2].Value;
                generalPermissionCurrent_ReportsManagement = (bool)paramsSql[3].Value;
                PARENT.GeneralPermissions_DirectoryManagement_CheckBox.Checked = generalPermissionCurrent_DirectoryManagement;
                PARENT.GeneralPermissions_UsersManagement_CheckBox.Checked = generalPermissionCurrent_UsersManagement;
                PARENT.GeneralPermissions_ReportsManagement_CheckBox.Checked = generalPermissionCurrent_ReportsManagement;

                // datetime
                object dateCreatedRaw = row["dateCreated"];
                if (!(dateCreatedRaw is null))
                {
                    PARENT.DateCreated_TextBox.Text = ((DateTime)dateCreatedRaw).ToString("dd.MM.yyyy HH:mm");
                    PARENT.DateChanged_TextBox.Text = ((DateTime)row["dateChanged"]).ToString("dd.MM.yyyy HH:mm");
                }
            }


            /// <summary>
            /// Применить изменения
            /// </summary>
            public void ChangesAccept()
            {
                DialogResult resultDialog;
                Regex OnlyEnglishLetters = new Regex(@"^([^а-яА-Я]+)$");

                string nameNew = PARENT.Name_TextBox.Text.Trim(' ', '\n', '\t');
                string nameDomainNew = PARENT.NameDomain_TextBox.Text.Trim(' ', '\n', '\t');
                string emailNew = PARENT.Email_TextBox.Text.Trim(' ', '\n', '\t');
                int departmentIdNew = departmentIds[PARENT.Department_ComboBox.SelectedIndex];
                int statusIdNew = PARENT.Status_Active_RadioButton.Checked ? STATUS_ACTIVE : STATUS_NOT_ACTIVE;
                bool generalPermissionNew_DirectoryManagement = PARENT.GeneralPermissions_DirectoryManagement_CheckBox.Checked;
                bool generalPermissionNew_UsersManagement = PARENT.GeneralPermissions_UsersManagement_CheckBox.Checked;
                bool generalPermissionNew_ReportsManagement = PARENT.GeneralPermissions_ReportsManagement_CheckBox.Checked;

                // ПРОВЕРКА ВВЕДЕННЫХ ДАННЫХ
                // name
                if (nameNew == "")
                {
                    MessageBox.Show("Имя пользователя не может быть пустым", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                // nameDomain
                string[] nameDomainNewSepareted = nameDomainNew.Split(separator: new string[] { "BOOKCENTRE\\" }, options: StringSplitOptions.RemoveEmptyEntries);
                if (
                    nameDomainNew == "" ||
                    !OnlyEnglishLetters.IsMatch(nameDomainNew) ||
                    !nameDomainNew.StartsWith("BOOKCENTRE\\") ||
                    nameDomainNewSepareted.Count() != 1 ||
                    nameDomainNewSepareted[0].Trim(' ', '\n', '\t') == ""
                )
                {
                    MessageBox.Show("Доменное имя пользователя указано некорректно.\n\nОно должно начинатсья с 'BOOKCENTRE\\', не содержать русских букв," +
                        " а вторая его часть не может быть пустой",
                        "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // email
                string[] emailNewSepareted = emailNew.Split(separator: new string[] { "@bookcentre.ru" }, options: StringSplitOptions.RemoveEmptyEntries);
                if (
                    emailNew == "" ||
                    !OnlyEnglishLetters.IsMatch(emailNew) ||
                    !emailNew.EndsWith("@bookcentre.ru") ||
                    emailNewSepareted.Count() != 1 ||
                    emailNewSepareted[0].Trim(' ', '\n', '\t') == ""
                )
                {
                    MessageBox.Show("E-mail пользователя указан некорректно.\n\nОн должен заканчиваться на '@bookcentre.ru', не содержать русских букв," +
                        " а первая его часть не может быть пустой",
                        "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // departmentId
                if (departmentIdNew == Constances.DIRECTORY_DEPARTMENT_UNKNOWN_ID)
                {
                    if (DialogResult.Yes != MessageBox.Show($"Для пользователя указан отдел 'UNKNOWN'.\n\nПродолжить с некорректным отделом?",
                   "Указан некорректный отдел пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) return;
                }

                if (PARENT.Mode == "EDIT")
                {
                    if (
                        nameNew == nameCurrent &&
                        nameDomainNew == nameDomainCurrent &&
                        emailNew == emailCurrent &&
                        departmentIdNew == departmentIdCurrent &&
                        statusIdNew == statusIdCurrent &&
                        generalPermissionNew_DirectoryManagement == generalPermissionCurrent_DirectoryManagement &&
                        generalPermissionNew_UsersManagement == generalPermissionCurrent_UsersManagement &&
                        generalPermissionNew_ReportsManagement == generalPermissionCurrent_ReportsManagement
                    )
                    {
                        MessageBox.Show("Прежде чем сохранять изменения, их необходимо сначала сделать", "Изменения не обнаружены",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    };
                };

                // Диалог подтверждения изменений
                resultDialog = MessageBox.Show($"Сохранить новые данные?",
                    "Подтверждение изменений", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDialog != DialogResult.Yes) return;

                // Работа с SQL
                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@resultRecordId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@mode", SqlDbType.VarChar) { Value = PARENT.Mode },
                    new SqlParameter("@recordId", SqlDbType.Int) { Value = recordIdCurrent },
                    new SqlParameter("@recordNameNew", SqlDbType.VarChar) { Value = nameNew },
                    new SqlParameter("@recordNameDomainNew", SqlDbType.VarChar) { Value = nameDomainNew },
                    new SqlParameter("@recordEmailNew", SqlDbType.VarChar) { Value = emailNew },
                    new SqlParameter("@recordDepartmentIdNew", SqlDbType.Int) { Value = departmentIdNew },
                    new SqlParameter("@recordStatusIdNew", SqlDbType.Int) { Value = statusIdNew },
                    new SqlParameter("@recordGeneralPermissionNew_DirectoryManagement", SqlDbType.Bit) { Value = generalPermissionNew_DirectoryManagement },
                    new SqlParameter("@recordGeneralPermissionNew_UsersManagement", SqlDbType.Bit) { Value = generalPermissionNew_UsersManagement },
                    new SqlParameter("@recordGeneralPermissionNew_ReportsManagement", SqlDbType.Bit) { Value = generalPermissionNew_ReportsManagement }
                };
                Tuple<bool, DataSet> resultSql = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("UsersUniversalChangerAndCreator", parameters);
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

                // Обновить данные таблицы
                resultDialog = MessageBox.Show("Процедура изменения/добавления пользователя выполнена успешно\n\nОтобразить его в таблице?", "Новые данные пользователя",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDialog == DialogResult.Yes)
                {
                    PARENT.MANAGEMENT_FORM.SearchCriteria_userIds_CheckBox.Checked = true;
                    PARENT.MANAGEMENT_FORM.SearchCriteria_userIds_TextBox.Text = ((int)parameters[1].Value).ToString();

                    PARENT.MANAGEMENT_FORM.SearchCriteria_name_CheckBox.Checked = false;
                    PARENT.MANAGEMENT_FORM.SearchCriteria_nameDomain_CheckBox.Checked = false;
                    PARENT.MANAGEMENT_FORM.SearchCriteria_email_CheckBox.Checked = false;
                    PARENT.MANAGEMENT_FORM.SearchCriteria_department_CheckBox.Checked = false;
                    PARENT.MANAGEMENT_FORM.SearchCriteria_status_CheckBox.Checked = false;
                    PARENT.MANAGEMENT_FORM.SearchCriteria_generalPermissions_CheckBox.Checked = false;
                    PARENT.MANAGEMENT_FORM.SearchCriteria_dateCreated_CheckBox.Checked = false;
                    PARENT.MANAGEMENT_FORM.SearchCriteria_dateChanged_CheckBox.Checked = false;
                }

                PARENT.MANAGEMENT_FORM.PROG.Search();
                PARENT.Close();
            }
        }
    }
}