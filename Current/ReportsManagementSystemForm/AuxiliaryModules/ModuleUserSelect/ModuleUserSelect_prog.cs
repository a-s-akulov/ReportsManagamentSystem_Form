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

    public partial class ModuleUserSelect
    {

        public class MyProgram
        {
            public readonly ModuleUserSelect PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;

            public DataTable DataRaw;
            public DataTable DataVisible;

            public DataTable DataResult;

            public bool isMultipleChoiceAllowed;
            public int[] departmentIds;


            public MyProgram(ModuleUserSelect parent, DataTable dataResult, bool isMultipleChoiceAllowed)
            {
                PARENT = parent;
                STATUS_ACTIVE = Constances.STATUS_ACTIVE;
                STATUS_NOT_ACTIVE = Constances.STATUS_NOT_ACTIVE;

                DataResult = dataResult;
                this.isMultipleChoiceAllowed = isMultipleChoiceAllowed;
                PARENT.Users_GridView.OptionsSelection.MultiSelect = isMultipleChoiceAllowed;
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
                    PARENT.SearchCriteria_department_ComboBox.Items.Add(PARENT.MAIN.PROG.directoryDepartments[departmentId]["name"]);
                if (PARENT.SearchCriteria_department_ComboBox.Items.Count > 0) PARENT.SearchCriteria_department_ComboBox.SelectedIndex = indexToSelect;
                PARENT.SearchCriteria_department_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                PARENT.ActiveControl = PARENT.Search_Button;
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
                    case "name":
                        PARENT.SearchCriteria_name_TextBox.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "nameDomain":
                        PARENT.SearchCriteria_nameDomain_TextBox.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    case "department":
                        PARENT.SearchCriteria_department_ComboBox.Enabled = CheckedStateGet(searchCriteria);
                        break;

                    default:
                        return;
                }
            }


            private bool CheckedStateGet(string searchCriteria)
            {
                switch (searchCriteria)
                {
                    case "name":
                        return PARENT.SearchCriteria_name_CheckBox.Checked;

                    case "nameDomain":
                        return PARENT.SearchCriteria_nameDomain_CheckBox.Checked;

                    case "department":
                        return PARENT.SearchCriteria_department_CheckBox.Checked;

                    default:
                        return false;
                }
            }


            /// <summary>
            /// Получает данные справочника для редактирования и загружает их в таблицу
            /// </summary>
            /// <returns></returns>
            public void Search()
            {
                // ПРОВЕРКА ПАРАМЕТРОВ
                foreach (string searchCriteria in new string[]{ "name", "nameDomain", "department" })
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
                DataTable tableSql = new DataTable();
                tableSql.Columns.Add("ints", typeof(int));
                tableSql.Rows.Add(-1);
                paramsSql.Add(new SqlParameter("@userIds", SqlDbType.Structured) { Value = tableSql });
                paramsSql.Add(new SqlParameter("@generalPermissions", SqlDbType.Structured) { Value = tableSql });
                

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

                // department
                if (CheckedStateGet("department"))
                {
                    paramsSql.Add(new SqlParameter("@departmentId", SqlDbType.Int)
                    {
                        Value = departmentIds[PARENT.SearchCriteria_department_ComboBox.SelectedIndex]
                    });
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

                // ОБНОВЛЕНИЕ ДАННЫХ И ОТОБРАЖЕНИЕ В ТАБЛИЦЕ
                DataRaw = result.Item2.Tables[0];
                DataVisible = PARENT.MAIN.PROG.DataCompare(DataRaw);

                // Обработка визуализации таблицы
                PARENT.Users_GridControl.DataSource = DataVisible;
                foreach (GridColumn column in PARENT.Users_GridView.Columns)
                {
                    column.BestFit();
                };

                PARENT.ActiveControl = PARENT.Users_GridControl;

                // Корректировка визуализации таблицы
                PARENT.MAIN.PROG.GridViewVisualisationAdjustment(PARENT.Users_GridView);
            }


            public void SelectionAccept()
            {
                int[] selectedRowsIds = PARENT.Users_GridView.GetSelectedRows();
                if (selectedRowsIds.Count() == 0 || selectedRowsIds[0] < 0)
                {
                    MessageBox.Show("Не выбрана ни одна строка", "Подтверждение выбора", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult resultDialog = MessageBox.Show($"Выбрано пользователей: {selectedRowsIds.Count()}\n\nПодтвердить?",
                        "Подтвердите выбор", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDialog != DialogResult.Yes) return;

                // Подготовка схемы таблицы результата
                DataResult.Clear();
                DataResult.Columns.Clear();
                foreach (DataColumn column in DataRaw.Columns) DataResult.Columns.Add(column.ColumnName, column.DataType);

                foreach (int rowId in selectedRowsIds)
                {
                    DataResult.Rows.Add(DataRaw.Rows[rowId].ItemArray);
                }

                PARENT.Close();
            }
        }
    }
}