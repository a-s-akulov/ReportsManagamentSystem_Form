using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;


namespace ReportsManagementSystemForm
{
    public partial class Pass { }

    public partial class ReportsManagement_main
    {

        public class MyProgramRegistry
        {
            public readonly ReportsManagement_main PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;

            public DataTable DataRaw;
            public DataTable DataVisible;
            public DataTable NotificationsReceivers;

            public int departmentIdCurrent;
            public int[] departmentIds;



            public MyProgramRegistry(ReportsManagement_main parent)
            {
                PARENT = parent;
                STATUS_ACTIVE = Constances.STATUS_ACTIVE;
                STATUS_NOT_ACTIVE = Constances.STATUS_NOT_ACTIVE;
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
                if (departmentIds.Contains(currentUserDepartmentId)) indexToSelect = Array.IndexOf(departmentIds, currentUserDepartmentId);

                foreach (int departmentId in departmentIds)
                    PARENT.REG_department_ComboBox.Items.Add(PARENT.MAIN.PROG.directoryDepartments[departmentId]["name"]);
                if (PARENT.REG_department_ComboBox.Items.Count > 0) PARENT.REG_department_ComboBox.SelectedIndex = indexToSelect;
                PARENT.REG_department_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }


            /// <summary>
            /// Получает данные справочника для редактирования и загружает их в таблицу
            /// </summary>
            /// <returns></returns>
            public void DataGet()
            {
                int departmentIdCurrent_ = departmentIds[PARENT.REG_department_ComboBox.SelectedIndex];
                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@departmentId", SqlDbType.Int) { Value = departmentIdCurrent_ },
                    new SqlParameter("@isNotActiveSelect", SqlDbType.Bit) { Value = PARENT.REG_isNotActiveShown_CheckBox.Checked }
                };
                Tuple<bool, DataSet> resultSql = PARENT.MAIN.SQL.ProcedureExecWithData("ReportsRegistrySelecter", parameters);
                if (resultSql.Item1)
                {
                    int resultSqlProcedure = (int)parameters[0].Value;
                    if (resultSqlProcedure != 0)
                    {
                        MessageBox.Show($"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}",
                            "Ошибка получения реестра отчётов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else return;

                // Обработка полученных данных
                DataRaw = resultSql.Item2.Tables[0];
                DataVisible = PARENT.MAIN.PROG.DataCompare(DataRaw);
                foreach (DataRow row in DataVisible.Rows) row["responsiblePersonId_Name"] = $"[{row["responsiblePersonId"]}] {row["responsiblePersonId_Name"]} ({row["responsiblePersonId_NameDomain"]})";
                DataVisible.Columns.Remove(DataVisible.Columns["responsiblePersonId"]);
                DataVisible.Columns.Remove(DataVisible.Columns["responsiblePersonId_NameDomain"]);
                DataVisible.Columns.Remove(DataVisible.Columns["filesPath"]);
                DataVisible.Columns.Remove(DataVisible.Columns["sqlTemplatesPath"]);

                // Получение списка получателей уведомления отчётов
                HashSet<int> reportIdsSet = new HashSet<int>();
                foreach (DataRow row in DataRaw.Rows) reportIdsSet.Add((int)row["reportId"]);
                if (reportIdsSet.Count != 0)
                {
                    DataTable tableSql = new DataTable();
                    tableSql.Columns.Add("ints", typeof(int));
                    foreach (int reportId_ in reportIdsSet) { tableSql.Rows.Add(reportId_); };

                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                        new SqlParameter("@reportIds", SqlDbType.Structured) { Value = tableSql }
                    };
                    resultSql = PARENT.MAIN.SQL.ProcedureExecWithData("ReportsRegistryReceiversSelecter", parameters);
                    if (resultSql.Item1)
                    {
                        int resultSqlProcedure = (int)parameters[0].Value;
                        if (resultSqlProcedure != 0)
                        {
                            MessageBox.Show($"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}",
                                "Ошибка получения информации о получателях уведомлений реестра отчётов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else return;

                    NotificationsReceivers = resultSql.Item2.Tables[0];
                }
                else NotificationsReceivers = null;

                // Обновление переменных
                departmentIdCurrent = departmentIdCurrent_;

                // Установка данных
                PARENT.REG_Data_GridControl.DataSource = DataVisible;

                // Обновление данных дублирующих полей
                TableRowEnter();

                PARENT.ActiveControl = PARENT.REG_Data_GridControl;

                // Корректировка визуализации таблицы
                PARENT.MAIN.PROG.GridViewVisualisationAdjustment(PARENT.REG_Data_GridView);
            }


            public void TableRowEnter()
            {
                PARENT.REG_DataDescription_RichTextBox.Text = "";
                PARENT.REG_NotificationReceivers_ListBox.Items.Clear();

                int[] selectedRowsIds = PARENT.REG_Data_GridView.GetSelectedRows();
                if (selectedRowsIds.Count() == 0 || selectedRowsIds[0] < 0) return;
                
                DataRow rowRaw = PARENT.PROG_REG.DataRaw.Rows[selectedRowsIds[0]];
                int reportId = (int)rowRaw[0];

                PARENT.REG_DataDescription_RichTextBox.Text = (string)rowRaw["contentDescription"];
                if (!(NotificationsReceivers is null))
                {
                    foreach (DataRow row in NotificationsReceivers.Rows)
                    {
                        if ((int)row["reportId"] == reportId) PARENT.REG_NotificationReceivers_ListBox.Items.Add($"[{row["userId"]}] {row["userId_Name"]} ({row["userId_NameDomain"]})");
                    }
                }
            }


            /// <summary>
            /// Добавляет запись
            /// </summary>
            public void DataAdd()
            {
                if (DataRaw == null)
                {
                    MessageBox.Show("Сначала необходимо получить список отчётов", "Добавление отчёта в реестр", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Form dialog = new Form()
                {
                    ControlBox = false,
                    ClientSize = new Size(300, 100),
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = "Выберите способ создания отчёта"
                };
                TableLayoutPanel dialogLayout = new TableLayoutPanel()
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                    Size = new Size(300, 100)
                };
                Button buttonMaster = new Button()
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    DialogResult = DialogResult.Yes,
                    Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold),
                    AutoSize = true,
                    Text = "Мастер создания отчета"
                };
                Button buttonDefault = new Button()
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    DialogResult = DialogResult.No,
                    Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold),
                    AutoSize = true,
                    Text = "Стандартный редактор"
                };
                dialogLayout.Controls.Add(buttonMaster, 0, 0);
                dialogLayout.Controls.Add(buttonDefault, 0, 1);
                dialog.Controls.Add(dialogLayout);

                PARENT.REG_department_ComboBox.SelectedIndex = Array.IndexOf(departmentIds, departmentIdCurrent);
                if (DialogResult.Yes == dialog.ShowDialog())
                {
                    new ReportsManagement_registry_creatingMaster(PARENT);
                }
                else
                {
                    ReportsManagement_registry_editor editor = new ReportsManagement_registry_editor(PARENT, modeOfWork: "ADD");
                    if (!editor.IsDisposed) editor.ShowDialog();
                    editor.Dispose();
                }
            }



            /// <summary>
            /// Изменяет запись
            /// </summary>
            public void DataEdit()
            {
                if (DataRaw == null)
                {
                    MessageBox.Show("Сначала необходимо получить список отчётов", "Редактирвоание отчёта в реестре", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                PARENT.REG_department_ComboBox.SelectedIndex = Array.IndexOf(departmentIds, departmentIdCurrent);
                ReportsManagement_registry_editor editor = new ReportsManagement_registry_editor(PARENT, modeOfWork: "EDIT");
                if (!editor.IsDisposed) editor.ShowDialog();
            }


            /// <summary>
            /// Настройка пользователей отчёта
            /// </summary>
            public void UsersEdit()
            {
                if (DataRaw == null)
                {
                    MessageBox.Show("Сначала необходимо получить список отчётов", "Редактирвоание пользователей отчёта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int[] selectedRowsIds = PARENT.REG_Data_GridView.GetSelectedRows();
                if (selectedRowsIds.Count() == 0 || selectedRowsIds[0] < 0)
                {
                    MessageBox.Show("Не выбрана ни одна строка", "Редактирвоание пользователей отчёта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow rowRaw = PARENT.PROG_REG.DataRaw.Rows[selectedRowsIds[0]];
                int reportId = (int)rowRaw[0];

                PARENT.REG_department_ComboBox.SelectedIndex = Array.IndexOf(departmentIds, departmentIdCurrent);
                ReportsManagement_registry_users_editor editor = new ReportsManagement_registry_users_editor(PARENT, reportId);
                if (!editor.IsDisposed) editor.ShowDialog();
            }
        }
    }
}