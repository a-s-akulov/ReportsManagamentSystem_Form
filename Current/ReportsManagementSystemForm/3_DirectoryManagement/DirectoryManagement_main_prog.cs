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

    public partial class DirectoryManagement_main
    {

        public class MyProgram
        {
            public readonly DirectoryManagement_main PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;
            public DataTable Data;
            public DataTable DataVisible;
            public int sectionIdLast;
            public readonly Dictionary<int, string> sectionTables = new Dictionary<int, string>
            {
                { 0, "Directory_brands" },
                { 1, "Directory_departments" },
                { 2, "Directory_reportGroups" },
                { 3, "Directory_reportTypes" },
                { 4, "Directory_reportFrequencies" },
                { 5, "Directory_reportToDates" }
            };



            public MyProgram(DirectoryManagement_main parent)
            {
                PARENT = parent;
                STATUS_ACTIVE = Constances.STATUS_ACTIVE;
                STATUS_NOT_ACTIVE = Constances.STATUS_NOT_ACTIVE;
            }



            /// <summary>
            /// Получает данные справочника для редактирования и загружает их в таблицу
            /// </summary>
            /// <returns></returns>
            public bool DataGet()
            {
                int sectionId = PARENT.SectionSelection_ComboBox.SelectedIndex;

                DataTable statusIds = new DataTable();
                statusIds.Columns.Add(new DataColumn("ints"));

                foreach (int element in PARENT.IrrelevantRecordsShow_CheckBox.Checked ? new int[] { STATUS_ACTIVE, STATUS_NOT_ACTIVE } : new int[] { STATUS_ACTIVE })
                {
                    statusIds.Rows.Add(element);
                };

                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@tableName", SqlDbType.VarChar) { Value = sectionTables[sectionId] },
                    new SqlParameter("@statusIds", SqlDbType.Structured) { Value = statusIds }
                };
                Tuple<bool, DataSet> resultSql = PARENT.MAIN.SQL.ProcedureExecWithData("UniversalTableSelecter", parameters);
                if (resultSql.Item1)
                {
                    int resultSqlProcedure = (int)parameters[0].Value;
                    if (resultSqlProcedure != 0)
                    {
                        MessageBox.Show($"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}",
                            "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else return false;

                Data = resultSql.Item2.Tables[0];
                DataVisible = PARENT.MAIN.PROG.DataCompare(Data);

                // DEPARTMENT
                if (sectionId == 1)
                {
                    foreach (DataRow row in DataVisible.Rows) row["headPersonId_Name"] = $"[{row["headPersonId"]}] {row["headPersonId_Name"]} ({row["headPersonId_NameDomain"]})";
                    DataVisible.Columns.Remove(DataVisible.Columns["headPersonId"]);
                    DataVisible.Columns.Remove(DataVisible.Columns["headPersonId_NameDomain"]);
                }

                if (sectionIdLast != sectionId) PARENT.DataShow_GridView.Columns.Clear();
                PARENT.DataShow_GridControl.DataSource = DataVisible;

                sectionIdLast = sectionId;

                // Корректировка визуализации таблицы
                PARENT.MAIN.PROG.GridViewVisualisationAdjustment(PARENT.DataShow_GridView);

                return true;
            }


            /// <summary>
            /// Добавляет запись
            /// </summary>
            public void DataAdd()
            {
                PARENT.SectionSelection_ComboBox.SelectedIndex = sectionIdLast;
                if (Data == null)
                {
                    MessageBox.Show("Сначала необходимо получить список записей", "Добавление записи в справочник", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DirectoryManagement_editor editor = new DirectoryManagement_editor(PARENT, modeOfWork: "ADD");
                if (Data != null && !editor.IsDisposed) editor.ShowDialog();
            }



            /// <summary>
            /// Изменяет запись
            /// </summary>
            public void DataEdit()
            {
                PARENT.SectionSelection_ComboBox.SelectedIndex = sectionIdLast;

                DirectoryManagement_editor editor = new DirectoryManagement_editor(PARENT, modeOfWork: "EDIT");
                if (Data != null && !editor.IsDisposed) editor.ShowDialog();
            }



            /// <summary>
            /// Меняет актуальность выбранной записи
            /// </summary>
            public void ActualityChange()
            {
                PARENT.SectionSelection_ComboBox.SelectedIndex = sectionIdLast;

                int[] selectedRowsIds = PARENT.DataShow_GridView.GetSelectedRows();
                if (selectedRowsIds.Count() == 0)
                {
                    MessageBox.Show("Не выбрана ни одна строка", "Смена актуальности записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {   
                    DataRow row = Data.Rows[selectedRowsIds[0]];
                    DataRow rowVisible = DataVisible.Rows[selectedRowsIds[0]];
                    int recordId = (int)row[0];

                    int statusIdCurrent = (int)row["statusId"];
                    int statusIdNew = statusIdCurrent == STATUS_ACTIVE ? STATUS_NOT_ACTIVE : STATUS_ACTIVE;
                    string statusNameCurrent = PARENT.MAIN.PROG.directoryStatuses[statusIdCurrent]["name"];
                    string statusNameNew = PARENT.MAIN.PROG.directoryStatuses[statusIdNew]["name"];
                    int userIdNew = new int();

                    // DEPARTMENT
                    if (sectionIdLast == 1) userIdNew = (int)row["headPersonId"];

                    // Диалог подтверждения замены
                    DialogResult resultDialog = MessageBox.Show($"Изменить статус выбранной записи с '{statusNameCurrent}' на '{statusNameNew}'?",
                        "Смена актуальности записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultDialog != DialogResult.Yes) return;

                    // Работа с SQL
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                        new SqlParameter("@tableName", SqlDbType.VarChar) { Value = sectionTables[sectionIdLast] },
                        new SqlParameter("@mode", SqlDbType.VarChar) { Value = "EDIT" },
                        new SqlParameter("@recordId", SqlDbType.Int) { Value = recordId },
                        new SqlParameter("@recordStatusIdNew", SqlDbType.Int) { Value = statusIdNew },
                        new SqlParameter("@userIdNew", SqlDbType.Int) { Value = userIdNew }
                    };
                    Tuple<bool, DataSet> resultSql = PARENT.MAIN.SQL.ProcedureExecWithData("DirectoryUniversalChangerAndCreator", parameters);
                    if (resultSql.Item1)
                    {
                        int resultSqlProcedure = (int)parameters[0].Value;
                        if (resultSqlProcedure != 0)
                        {
                            string errorText;
                            if (resultSqlProcedure == Constances.ERROR_PARAMS_ERROR)
                                errorText = "Ошибка: Указаны некорректные параметры";
                            else if (resultSqlProcedure == Constances.ERROR_ACCESS_DENIED_ERROR)
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

                    // Обновление записи в таблице
                    row["statusId"] = statusIdNew;
                    rowVisible["statusId_Name"] = statusNameNew;

                    MessageBox.Show($"Процедура успешно выполнена",
                        "Смена актуальности записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}