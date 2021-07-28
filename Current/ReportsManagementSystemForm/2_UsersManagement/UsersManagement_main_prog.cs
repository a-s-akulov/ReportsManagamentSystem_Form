using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ReportsManagementSystemForm
{
    public partial class Pass { }

    public partial class UsersManagement_main
    {

        public class MyProgram
        {
            public readonly UsersManagement_main PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;
            public readonly int PERMISSION_DIRECTORY_MANAGEMENT;
            public readonly int PERMISSION_USERS_MANAGEMENT;
            public readonly int PERMISSION_REPORTS_MANAGEMENT;

            public DataTable usersDataRaw;
            public DataTable usersDataVisible;

            public int[] departmentIds;

            public MyProgram(UsersManagement_main parent)
            {
                PARENT = parent;
                STATUS_ACTIVE = Constances.STATUS_ACTIVE;
                STATUS_NOT_ACTIVE = Constances.STATUS_NOT_ACTIVE;

                PERMISSION_DIRECTORY_MANAGEMENT = Constances.PERMISSION_DIRECTORY_MANAGEMENT;
                PERMISSION_USERS_MANAGEMENT = Constances.PERMISSION_USERS_MANAGEMENT;
                PERMISSION_REPORTS_MANAGEMENT = Constances.PERMISSION_REPORTS_MANAGEMENT;
            }


            /// <summary>
            /// Осуществляет инициализацию элементов управления
            /// </summary>
            public void ControlsInit()
            {
                // department
                departmentIds = PARENT.MAIN.PROG.directoryDepartments.Values
                    .Where(v => v["statusId"] == STATUS_ACTIVE.ToString())
                    .Select(v => int.Parse(v["departmentId"]))
                    .ToArray();

                int indexToSelect = 0;
                int currentUserDepartmentId = (int)PARENT.MAIN.PROG.currentUserInfo.Rows[0]["departmentId"];
                if (!departmentIds.Contains(currentUserDepartmentId))
                {
                    int[] departmentIdsTmp = new int[departmentIds.Length + 1];
                    departmentIdsTmp[0] = currentUserDepartmentId;
                    departmentIds.CopyTo(departmentIdsTmp, 1);
                    departmentIds = departmentIdsTmp;
                }
                else indexToSelect = Array.IndexOf(departmentIds, currentUserDepartmentId);

                foreach (int departmentId in departmentIds)
                    PARENT.SearchCriteria_department_ComboBox.Items.Add(PARENT.MAIN.PROG.directoryDepartments[departmentId]["name"]);
                if (PARENT.SearchCriteria_department_ComboBox.Items.Count > 0) PARENT.SearchCriteria_department_ComboBox.SelectedIndex = indexToSelect;
                PARENT.SearchCriteria_department_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                // Остальное
                PARENT.SearchCriteria_status_notActive_RadioButton.Text = PARENT.MAIN.PROG.directoryStatuses[STATUS_NOT_ACTIVE]["name"];
                PARENT.SearchCriteria_status_active_RadioButton.Text = PARENT.MAIN.PROG.directoryStatuses[STATUS_ACTIVE]["name"];

                PARENT.SearchCriteria_dateCreated_from_DateTimePicker.Value = DateTime.Now.AddDays(-30);
                PARENT.SearchCriteria_dateCreated_to_DateTimePicker.Value = DateTime.Now.AddDays(1);
                PARENT.SearchCriteria_dateChanged_from_DateTimePicker.Value = DateTime.Now.AddDays(-30);
                PARENT.SearchCriteria_dateChanged_to_DateTimePicker.Value = DateTime.Now.AddDays(1);
            }


            /// <summary>
            /// Обрабатывает событие изменения состояния CheckBox критериев поиска
            /// </summary>
            /// <param name="searchCriteria"></param>
            /// <param name="isChecked"></param>
            public void SearchCriteria_CheckBox_CheckedChanged(string searchCriteria)
            {
                switch (searchCriteria)
                {
                    case "userIds":
                        PARENT.SearchCriteria_userIds_TextBox.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "name":
                        PARENT.SearchCriteria_name_TextBox.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "nameDomain":
                        PARENT.SearchCriteria_nameDomain_TextBox.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "email":
                        PARENT.SearchCriteria_email_TextBox.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "department":
                        PARENT.SearchCriteria_department_ComboBox.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "status":
                        PARENT.SearchCriteria_status_TableLayoutPanel.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "generalPermissions":
                        PARENT.SearchCriteria_generalPermissions_TableLayoutPanel.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "dateCreated":
                        PARENT.SearchCriteria_dateCreated_TableLayoutPanel.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "dateChanged":
                        PARENT.SearchCriteria_dateChanged_TableLayoutPanel.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    default:
                        return;
                }
            }


            private bool CheckedStateGet(string searchCriteria)
            {
                switch (searchCriteria)
                {
                    case "userIds":
                        return PARENT.SearchCriteria_userIds_CheckBox.Checked;

                    case "name":
                        return PARENT.SearchCriteria_name_CheckBox.Checked;

                    case "nameDomain":
                        return PARENT.SearchCriteria_nameDomain_CheckBox.Checked;

                    case "email":
                        return PARENT.SearchCriteria_email_CheckBox.Checked;

                    case "department":
                        return PARENT.SearchCriteria_department_CheckBox.Checked;

                    case "status":
                        return PARENT.SearchCriteria_status_CheckBox.Checked; ;

                    case "generalPermissions":
                        return PARENT.SearchCriteria_generalPermissions_CheckBox.Checked;

                    case "dateCreated":
                        return PARENT.SearchCriteria_dateCreated_CheckBox.Checked;

                    case "dateChanged":
                        return PARENT.SearchCriteria_dateChanged_CheckBox.Checked;

                    default:
                        return false;
                }
            }


            /// <summary>
            /// Выполянет поиск пользователя по заданным критериям
            /// </summary>
            public void Search()
            {
                // ПРОВЕРКА ПАРАМЕТРОВ
                foreach (string searchCriteria in new string[]{ "userIds", "name", "nameDomain",
                    "email", "department", "status", "generalPermissions", "dateCreated", "dateChanged"})
                {
                    if (CheckedStateGet(searchCriteria)) break;

                    if (searchCriteria == "dateChanged")
                    {
                        MessageBox.Show(
                            "Необходимо выбрать хотя бы один критерий для поиска",
                            "Не выбран ни один критерий",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                }

                // СБОРКА ПАРАМЕТРОВ SQL КРИТЕРИЕВ ПОИСКА
                List<SqlParameter> paramsSql = new List<SqlParameter>() { new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output } };

                // userIds
                if (CheckedStateGet("userIds"))
                {
                    string[] userIdsText = PARENT.SearchCriteria_userIds_TextBox.Text.Split(
                        new char[] { ',', ' ', '\n', '\t' },
                        options: StringSplitOptions.RemoveEmptyEntries
                    );

                    if (userIdsText.Count() == 0)
                    {
                        MessageBox.Show(
                            "Строка перечисления userId должна состоять из целых чисел, разделенных разделителями (запятая/пробел/табуляция)\n\n" +
                            "В заданной строке нет ни одного элемента.",
                            "Ошибка параметров поиска",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                    }

                    List<int> userIds = new List<int>();
                    int userId = new int();
                    foreach (string userIdStr in userIdsText)
                    {
                        if (int.TryParse(userIdStr, out userId)) userIds.Add(userId);
                        else
                        {
                            MessageBox.Show(
                                "Строка перечисления userId должна состоять из целых чисел, разделенных разделителями (запятая/пробел/табуляция)\n\n" +
                                $"Не удалось преобразовать выражение '{userIdStr}' в целое число",
                                "Ошибка параметров поиска",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }
                    }

                    DataTable tableSql = new DataTable();
                    tableSql.Columns.Add("ints", typeof(int));
                    foreach (int userId_ in userIds) { tableSql.Rows.Add(userId_); };
                    paramsSql.Add(new SqlParameter("@userIds", SqlDbType.Structured) { Value = tableSql });
                }
                else
                {
                    DataTable tableSql = new DataTable();
                    tableSql.Columns.Add("ints", typeof(int));
                    tableSql.Rows.Add(-1);
                    paramsSql.Add(new SqlParameter("@userIds", SqlDbType.Structured) { Value = tableSql });
                }

                // name
                if (CheckedStateGet("name"))
                {
                    paramsSql.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value = PARENT.SearchCriteria_name_TextBox.Text });
                }

                // nameDomain
                if (CheckedStateGet("nameDomain"))
                {
                    paramsSql.Add(new SqlParameter("@nameDomain", SqlDbType.VarChar) { Value = PARENT.SearchCriteria_nameDomain_TextBox.Text });
                }

                // email
                if (CheckedStateGet("email"))
                {
                    paramsSql.Add(new SqlParameter("@email", SqlDbType.VarChar) { Value = PARENT.SearchCriteria_email_TextBox.Text });
                }

                // department
                if (CheckedStateGet("department"))
                {
                    paramsSql.Add(new SqlParameter("@departmentId", SqlDbType.Int) {
                        Value = departmentIds[PARENT.SearchCriteria_department_ComboBox.SelectedIndex]
                    });
                }

                // status
                if (CheckedStateGet("status"))
                {
                    paramsSql.Add(new SqlParameter("@statusId", SqlDbType.Int) {
                        Value = PARENT.SearchCriteria_status_notActive_RadioButton.Checked ? STATUS_NOT_ACTIVE : STATUS_ACTIVE
                    });
                }

                // generalPermissions
                if (CheckedStateGet("generalPermissions"))
                {
                    if (!(
                        PARENT.SearchCriteria_generalPermissions_directoryManagement_CheckBox.Checked ||
                        PARENT.SearchCriteria_generalPermissions_usersManagement_CheckBox.Checked ||
                        PARENT.SearchCriteria_generalPermissions_reportsManagement_CheckBox.Checked
                    ))
                    {
                        MessageBox.Show(
                                "Должно быть указано хотя бы одно глобальное разрешение пользователя",
                                "Ошибка параметров поиска",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        return;
                    }

                    DataTable tableSql = new DataTable();
                    tableSql.Columns.Add("ints", typeof(int));

                    if (PARENT.SearchCriteria_generalPermissions_directoryManagement_CheckBox.Checked) tableSql.Rows.Add(PERMISSION_DIRECTORY_MANAGEMENT);
                    if (PARENT.SearchCriteria_generalPermissions_usersManagement_CheckBox.Checked) tableSql.Rows.Add(PERMISSION_USERS_MANAGEMENT);
                    if (PARENT.SearchCriteria_generalPermissions_reportsManagement_CheckBox.Checked) tableSql.Rows.Add(PERMISSION_REPORTS_MANAGEMENT);

                    paramsSql.Add(new SqlParameter("@generalPermissions", SqlDbType.Structured) { Value = tableSql });
                }
                else
                {
                    DataTable tableSql = new DataTable();
                    tableSql.Columns.Add("ints", typeof(int));
                    tableSql.Rows.Add(-1);
                    paramsSql.Add(new SqlParameter("@generalPermissions", SqlDbType.Structured) { Value = tableSql });
                }

                // dateCreated
                if (CheckedStateGet("dateCreated"))
                {
                    paramsSql.Add(new SqlParameter("@dateCreatedFrom", SqlDbType.DateTime) { Value = PARENT.SearchCriteria_dateCreated_from_DateTimePicker.Value });
                    paramsSql.Add(new SqlParameter("@dateCreatedTo", SqlDbType.DateTime) { Value = PARENT.SearchCriteria_dateCreated_to_DateTimePicker.Value });
                }

                // dateChanged
                if (CheckedStateGet("dateChanged"))
                {
                    paramsSql.Add(new SqlParameter("@dateChangedFrom", SqlDbType.DateTime) { Value = PARENT.SearchCriteria_dateChanged_from_DateTimePicker.Value });
                    paramsSql.Add(new SqlParameter("@dateChangedTo", SqlDbType.DateTime) { Value = PARENT.SearchCriteria_dateChanged_to_DateTimePicker.Value });
                }


                // ПОИСК
                Tuple<bool, DataSet> result = PARENT.MAIN.SQL.ProcedureExecWithData("usersFind", paramsSql.ToArray());
                if (!result.Item1) { return; };
                int resultErrorId = (int)paramsSql[0].Value;
                if (resultErrorId != 0)
                {
                    MessageBox.Show($"Ошибка выполнения процедуры поиска пользователей. Процедура вернула код: {resultErrorId}.",
                        "Ошибка поиска пользователей", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ОБНОВЛЕНИЕ ДАННЫХ
                usersDataRaw = result.Item2.Tables[0];
                usersDataVisible = PARENT.MAIN.PROG.DataCompare(usersDataRaw);
                PARENT.Show_GridControl.DataSource = usersDataVisible;

                // Корректировка визуализации таблицы
                PARENT.MAIN.PROG.GridViewVisualisationAdjustment(PARENT.Show_GridView);
            }


            /// <summary>
            /// Добавляет запись
            /// </summary>
            public void DataAdd()
            {
                UsersManagement_editor editor = new UsersManagement_editor(PARENT, modeOfWork: "ADD");
                if (!editor.IsDisposed) editor.ShowDialog();
            }


            /// <summary>
            /// Изменяет запись
            /// </summary>
            public void DataEdit()
            {
                UsersManagement_editor editor = new UsersManagement_editor(PARENT, modeOfWork: "EDIT");
                if (usersDataRaw != null && !editor.IsDisposed) editor.ShowDialog();
            }
        }
    }
}