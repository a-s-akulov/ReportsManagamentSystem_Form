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

    public partial class ReportsManagement_registry_users_editor
    {
        public class MyProgram
        {
            public readonly ReportsManagement_registry_users_editor PARENT;

            public readonly int reportId;

            public List<int> receiversIds = new List<int>();
            public List<int> creatorsIds = new List<int>();
            public List<int> editorsIds = new List<int>();
            public List<int> readersIds = new List<int>();


            public MyProgram(ReportsManagement_registry_users_editor parent, int reportId_)
            {
                PARENT = parent;

                reportId = reportId_;
                Init();
            }


            private void Init()
            {
                // Запрос данных из SQL
                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@reportId", SqlDbType.Int) { Value = reportId }
                };
                Tuple<bool, DataSet> resultSql = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("ReportsRegistryUsersSelecter", parameters);
                if (resultSql.Item1)
                {
                    int resultSqlProcedure = (int)parameters[0].Value;
                    if (resultSqlProcedure != 0)
                    {
                        string errorText;
                        if (resultSqlProcedure == Constances.ERROR_ACCESS_DENIED_ERROR)
                            errorText = "Ошибка: Отказано в доступе";
                        else errorText = $"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}";

                        MessageBox.Show(errorText,
                            "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else return;

                receiversIds.Clear();
                creatorsIds.Clear();
                editorsIds.Clear();
                readersIds.Clear();

                PARENT.Receivers_ListBox.Items.Clear();
                PARENT.Creators_ListBox.Items.Clear();
                PARENT.Editors_ListBox.Items.Clear();
                PARENT.Readers_ListBox.Items.Clear();

                DataTable receiversTable = resultSql.Item2.Tables[0];
                DataTable permissionsTable = resultSql.Item2.Tables[1];

                int userId;
                int permissionId;
                List<int> usersIdsList;
                ListBox listBox;

                foreach (DataRow row in receiversTable.Rows)
                {
                    userId = (int)row["userId"];
                    if (receiversIds.Contains(userId)) continue;

                    receiversIds.Add(userId);
                    PARENT.Receivers_ListBox.Items.Add($"[{userId}] {(string)row["userId_Name"]} ({(string)row["userId_NameDomain"]})");
                }

                foreach (DataRow row in permissionsTable.Rows)
                {
                    userId = (int)row["userId"];
                    permissionId = (int)row["permissionId"];

                    if (permissionId == Constances.PERMISSION_REPORTS_INSTANCES_CREATING) { usersIdsList = creatorsIds; listBox = PARENT.Creators_ListBox; }
                    else
                        if (permissionId == Constances.PERMISSION_REPORTS_INSTANCES_UPDATING) { usersIdsList = editorsIds; listBox = PARENT.Editors_ListBox; }
                    else
                        if (permissionId == Constances.PERMISSION_REPORTS_INSTANCES_READING) { usersIdsList = readersIds; listBox = PARENT.Readers_ListBox;  }
                    else
                    {
                        MessageBox.Show($"Ошибка обработки полученных данных разрешений пользователя [{userId}] - не распознанный permissionId ({permissionId})\n\nМодуль будет закрыт",
                            $"Ошибка обработки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PARENT.Close();
                        return;
                    }
                        
                    if (usersIdsList.Contains(userId)) continue;

                    usersIdsList.Add(userId);
                    listBox.Items.Add($"[{userId}] {(string)row["userId_Name"]} ({(string)row["userId_NameDomain"]})");
                }
            }


            public void UsersAdd(string section)
            {
                Tuple<ListBox, List<int>> sectionElementsCurrent = SectionElementsGet(section);
                ListBox listBox = sectionElementsCurrent.Item1;
                List<int> idsList = sectionElementsCurrent.Item2;

                Tuple<ListBox, List<int>> sectionElementsReaders = SectionElementsGet("readers");
                ListBox listBoxReaders = sectionElementsReaders.Item1;
                List<int> idsListReaders = sectionElementsReaders.Item2;

                Tuple<ListBox, List<int>> sectionElementsEditors = SectionElementsGet("editors");
                ListBox listBoxEditors = sectionElementsEditors.Item1;
                List<int> idsListEditors = sectionElementsEditors.Item2;

                DataTable usersTable = new DataTable();
                usersTable.Columns.Add("userId", typeof(int));
                usersTable.Columns.Add("name", typeof(string));
                usersTable.Columns.Add("nameDomain", typeof(string));
                usersTable.Columns.Add("email", typeof(string));
                usersTable.Columns.Add("departmentId", typeof(int));
                usersTable.Columns.Add("statusId", typeof(int));
                usersTable.Columns.Add("dateCreated", typeof(DateTime));
                usersTable.Columns.Add("dateChanged", typeof(DateTime));
                new ModuleUserSelect(PARENT.MANAGEMENT_FORM.MAIN, usersTable, isMultipleChoiceAllowed: true).ShowDialog();
                if (usersTable.Rows.Count == 0) { return; };

                int userId;
                string userName;
                string userNameDomain;
                int usersAdded = 0;
                int usersAlreadyExists = 0;
                foreach (DataRow row in usersTable.Rows)
                {
                    userId = (int)row["userId"];
                    userName = (string)row["name"];
                    userNameDomain = (string)row["nameDomain"];

                    if (idsList.Contains(userId))
                    {
                        usersAlreadyExists++;
                    }
                    else
                    {
                        idsList.Add(userId);
                        listBox.Items.Add($"[{userId}] {userName} ({userNameDomain})");
                        if ((section == "receivers" || section == "editors" || section == "creators") && !idsListReaders.Contains(userId))
                        {
                            idsListReaders.Add(userId);
                            listBoxReaders.Items.Add($"[{userId}] {userName} ({userNameDomain})");
                        }
                        if ((section == "creators") && !idsListEditors.Contains(userId))
                        {
                            idsListEditors.Add(userId);
                            listBoxEditors.Items.Add($"[{userId}] {userName} ({userNameDomain})");
                        }
                        usersAdded++;
                    }
                }

                MessageBox.Show($"Раздел: '{section}'\n\nДобавлено новых пользователей: {usersAdded}\nНе добавлены уже указанные пользователи: {usersAlreadyExists}",
                    "Добавление пользователей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            public void UsersDelete(string section)
            {
                Tuple<ListBox, List<int>> sectionElements = SectionElementsGet(section);
                ListBox listBox = sectionElements.Item1;
                List<int> idsList = sectionElements.Item2;

                int selectedCount = listBox.SelectedIndices.Count;
                int[] selectedIndices = new int[selectedCount];
                listBox.SelectedIndices.CopyTo(selectedIndices, 0);
                if (selectedCount == 0)
                {
                    MessageBox.Show("Не выбран ни один пользователь",
                        $"Удаление пользователей из списка '{section}'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (DialogResult.Yes != MessageBox.Show($"Удалить {selectedCount} пользователей из списка '{section}'?",
                    $"Удаление пользователей из списка '{section}'", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) return;

                int idxIndent = 0;
                foreach (int index in selectedIndices)
                {
                    listBox.Items.RemoveAt(index - idxIndent);
                    idsList.RemoveAt(index - idxIndent);

                    idxIndent++;
                }

                MessageBox.Show($"Удалено {selectedCount} пользователей из списка '{section}'",
                    $"Удаление пользователей из списка '{section}'", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private Tuple<ListBox, List<int>>SectionElementsGet(string section)
            {
                ListBox listBox = new ListBox();
                List<int> idsList = new List<int>();

                switch (section)
                {
                    case "receivers":
                        listBox = PARENT.Receivers_ListBox;
                        idsList = receiversIds;
                        break;

                    case "creators":
                        listBox = PARENT.Creators_ListBox;
                        idsList = creatorsIds;
                        break;

                    case "editors":
                        listBox = PARENT.Editors_ListBox;
                        idsList = editorsIds;
                        break;

                    case "readers":
                        listBox = PARENT.Readers_ListBox;
                        idsList = readersIds;
                        break;

                    default:
                        break;
                }

                return new Tuple<ListBox, List<int>>(listBox, idsList);
            }


            /// <summary>
            /// Применить изменения
            /// </summary>
            public void ChangesAccept()
            {
                DialogResult resultDialog = MessageBox.Show($"Применить внесенные изменения?",
                        "Применить изменения?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDialog != DialogResult.Yes) return;

                // Работа с SQL
                DataTable receivers = new DataTable();
                DataTable creators = new DataTable();
                DataTable editors = new DataTable();
                DataTable readers = new DataTable();

                receivers.Columns.Add("ints", typeof(int));
                creators.Columns.Add("ints", typeof(int));
                editors.Columns.Add("ints", typeof(int));
                readers.Columns.Add("ints", typeof(int));

                foreach (int id in receiversIds) receivers.Rows.Add(id);
                foreach (int id in creatorsIds) creators.Rows.Add(id);
                foreach (int id in editorsIds) editors.Rows.Add(id);
                foreach (int id in readersIds) readers.Rows.Add(id);

                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },

                    new SqlParameter("@reportId", SqlDbType.Int) { Value = reportId }, 

                    new SqlParameter("@receiversIds", SqlDbType.Structured) { Value = receivers },
                    new SqlParameter("@creatorsIds", SqlDbType.Structured) { Value = creators },
                    new SqlParameter("@editorsIds", SqlDbType.Structured) { Value = editors },
                    new SqlParameter("@readersIds", SqlDbType.Structured) { Value = readers }
                };
                Tuple<bool, DataSet> resultSql = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("ReportsRegistryUsersHandler", parameters);
                if (resultSql.Item1)
                {
                    int resultSqlProcedure = (int)parameters[0].Value;
                    if (resultSqlProcedure != 0)
                    {
                        string errorText;
                        if (resultSqlProcedure == Constances.ERROR_ACCESS_DENIED_ERROR)
                            errorText = "Ошибка: Отказано в доступе";
                        else errorText = $"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}";

                        MessageBox.Show(errorText,
                            "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else return;

                MessageBox.Show("Процедура редактирования списков пользователей отчёта выполнена успешно.", "Новые данные пользователей отчёта",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!PARENT.MANAGEMENT_FORM.MAIN.PROG.CurrentUserReportsPermissionsGet(PARENT)) return;
                PARENT.MANAGEMENT_FORM.PROG_REG.DataGet();
                PARENT.Close();
            }
        }
    }
}