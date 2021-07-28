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

        public class MyProgramInstances
        {
            public readonly ReportsManagement_main PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;
            public DataTable DataRaw;
            public DataTable DataVisible;

            public int[] departmentIds;
            public int departmentIdCurrent;



            public MyProgramInstances(ReportsManagement_main parent)
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
                    PARENT.INST_department_ComboBox.Items.Add(PARENT.MAIN.PROG.directoryDepartments[departmentId]["name"]);
                if (PARENT.INST_department_ComboBox.Items.Count > 0) PARENT.INST_department_ComboBox.SelectedIndex = indexToSelect;
                departmentIdCurrent = departmentIds[indexToSelect];
                PARENT.INST_department_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                // date
                PARENT.INST_dateFrom_DateTimePicker.Value = DateTime.Now.AddMonths(-1);
                PARENT.INST_dateTo_DateTimePicker.Value = DateTime.Now.AddDays(1);
            }


            /// <summary>
            /// Получает данные и загружает их в таблицу
            /// </summary>
            /// <returns></returns>
            public void DataGet()
            {
                int departmentId = departmentIds[PARENT.INST_department_ComboBox.SelectedIndex];
                DateTime dateFrom = PARENT.INST_dateFrom_DateTimePicker.Value;
                DateTime dateTo = PARENT.INST_dateTo_DateTimePicker.Value;
                bool isNotActiveSelect = PARENT.INST_isNotActiveShown_CheckBox.Checked;

                if (dateFrom > dateTo)
                {
                    MessageBox.Show("Дата поиска 'до' не может быть больше даты поиска 'от'", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@departmentId", SqlDbType.Int) { Value = departmentId },
                    new SqlParameter("@dateFrom", SqlDbType.DateTime) { Value = dateFrom },
                    new SqlParameter("@dateTo", SqlDbType.DateTime) { Value = dateTo },
                    new SqlParameter("@isNotActiveSelect", SqlDbType.Bit) { Value = isNotActiveSelect }
                };
                Tuple<bool, DataSet> resultSql = PARENT.MAIN.SQL.ProcedureExecWithData("ReportsInstancesRegistrySelecter", parameters);
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

                DataRaw = resultSql.Item2.Tables[0];
                DataVisible = PARENT.MAIN.PROG.DataCompare(DataRaw);

                foreach (DataRow row in DataVisible.Rows)
                {
                    row["createdUserId_Name"] = $"[{row["createdUserId"]}] {row["createdUserId_Name"]} ({row["createdUserId_NameDomain"]})";
                    row["updatedUserId_Name"] = $"[{row["updatedUserId"]}] {row["updatedUserId_Name"]} ({row["updatedUserId_NameDomain"]})";
                    row["responsiblePersonId_Name"] = $"[{row["responsiblePersonId"]}] {row["responsiblePersonId_Name"]} ({row["responsiblePersonId_NameDomain"]})";
                }

                DataVisible.Columns.Remove(DataVisible.Columns["createdUserId"]);
                DataVisible.Columns.Remove(DataVisible.Columns["createdUserId_NameDomain"]);
                DataVisible.Columns.Remove(DataVisible.Columns["updatedUserId"]);
                DataVisible.Columns.Remove(DataVisible.Columns["updatedUserId_NameDomain"]);
                DataVisible.Columns.Remove(DataVisible.Columns["responsiblePersonId"]);
                DataVisible.Columns.Remove(DataVisible.Columns["responsiblePersonId_NameDomain"]);
                DataVisible.Columns.Remove(DataVisible.Columns["responsiblePersonId_Email"]);
                DataVisible.Columns.Remove(DataVisible.Columns["notifyDepartmentHead"]);
                DataVisible.Columns.Remove(DataVisible.Columns["departmentHeadPersonId"]);
                DataVisible.Columns.Remove(DataVisible.Columns["departmentHeadPersonId_ReceiverId"]);
                DataVisible.Columns.Remove(DataVisible.Columns["departmentHeadPersonId_Name"]);
                DataVisible.Columns.Remove(DataVisible.Columns["departmentHeadPersonId_NameDomain"]);
                DataVisible.Columns.Remove(DataVisible.Columns["departmentHeadPersonId_Email"]);

                PARENT.INST_Data_GridControl.DataSource = DataVisible;

                PARENT.INST_Data_GridView.Columns["createdDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                PARENT.INST_Data_GridView.Columns["createdDate"].DisplayFormat.FormatString = "G";
                PARENT.INST_Data_GridView.Columns["updatedDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                PARENT.INST_Data_GridView.Columns["updatedDate"].DisplayFormat.FormatString = "G";

                // Корректировка визуализации таблицы
                PARENT.MAIN.PROG.GridViewVisualisationAdjustment(PARENT.INST_Data_GridView);
            }


            /// <summary>
            /// Добавляет запись
            /// </summary>
            public void DataAdd()
            {
                PARENT.INST_department_ComboBox.SelectedIndex = Array.IndexOf(departmentIds, departmentIdCurrent);
                ReportsManagement_instance_editor editor = new ReportsManagement_instance_editor(PARENT, modeOfWork: "ADD");
                if (!editor.IsDisposed) editor.ShowDialog();
            }



            /// <summary>
            /// Изменяет запись
            /// </summary>
            public void DataEdit()
            {
                if (DataRaw == null)
                {
                    MessageBox.Show("Сначала необходимо получить список экземпляров отчётов", "Просмотр или редактирвоание экземпляра отчёта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                PARENT.INST_department_ComboBox.SelectedIndex = Array.IndexOf(departmentIds, departmentIdCurrent);
                ReportsManagement_instance_editor editor = new ReportsManagement_instance_editor(PARENT, modeOfWork: "EDIT");
                if (!editor.IsDisposed) editor.ShowDialog();
            }
        }
    }
}