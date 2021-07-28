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

    public partial class DirectoryManagement_editor
    {
        public class MyProgram
        {
            public readonly DirectoryManagement_editor PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;
            public int recordIdCurrent = -1;
            public int departmentHeadPersonId = -1;

            public MyProgram(DirectoryManagement_editor parent)
            {
                PARENT = parent;
                STATUS_ACTIVE = Constances.STATUS_ACTIVE;
                STATUS_NOT_ACTIVE = Constances.STATUS_NOT_ACTIVE;

                // DEPARTMENT
                if (PARENT.MANAGEMENT_FORM.PROG.sectionIdLast == 1) PARENT.DepartmentInitializeComponent();

                ControlsTextsFill();
                if (PARENT.Mode == "EDIT") DataFieldsFill();
            }
            

            /// <summary>
            /// Устанавливает имена элементов управленя для корреткного отображения
            /// </summary>
            private void ControlsTextsFill()
            {
                string tableName = PARENT.MANAGEMENT_FORM.PROG.sectionTables[PARENT.MANAGEMENT_FORM.PROG.sectionIdLast];

                if (PARENT.Mode == "ADD") PARENT.Text += $"добавление ({tableName})";
                else if (PARENT.Mode == "EDIT") PARENT.Text += $"редактирование ({tableName})";
                PARENT.StatusActive_RadioButton.Text = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryStatuses[STATUS_ACTIVE]["name"];
                PARENT.StatusUnactive_RadioButton.Text = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryStatuses[STATUS_NOT_ACTIVE]["name"];
            }


            /// <summary>
            /// Заполняет данные при режиме редактирования
            /// </summary>
            private void DataFieldsFill()
            {
                int[] selectedRowsIds = PARENT.MANAGEMENT_FORM.DataShow_GridView.GetSelectedRows();
                if (selectedRowsIds.Count() == 0 || selectedRowsIds[0] < 0)
                {
                    MessageBox.Show("Не выбрана ни одна строка", "Редактирование записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PARENT.Close();
                    return;
                }

                DataRow row = PARENT.MANAGEMENT_FORM.PROG.Data.Rows[selectedRowsIds[0]];
                recordIdCurrent = (int)row[0];

                PARENT.ID_TextBox.Text = recordIdCurrent.ToString();
                PARENT.Name_TextBox.Text = (string)row["name"];

                int statusId = (int)row["statusId"];
                if (statusId == STATUS_ACTIVE) PARENT.StatusActive_RadioButton.Select();
                else if (statusId == STATUS_NOT_ACTIVE) PARENT.StatusUnactive_RadioButton.Select();

                // DEPARTMENT
                if (PARENT.MANAGEMENT_FORM.PROG.sectionIdLast == 1)
                {
                    departmentHeadPersonId = (int)row["headPersonId"];
                    PARENT.Department_headPerson_TextBox.Text = $"[{departmentHeadPersonId}] {row["headPersonId_Name"]} ({row["headPersonId_NameDomain"]})";
                }
            }


            public void DepartmentHeadPersonEdit()
            {
                DataTable headPersonTable = new DataTable();
                new ModuleUserSelect(PARENT.MANAGEMENT_FORM.MAIN, headPersonTable).ShowDialog();

                if (headPersonTable.Rows.Count == 0) return;

                departmentHeadPersonId = (int)headPersonTable.Rows[0]["userId"];

                PARENT.Department_headPerson_TextBox.Text = $"[{headPersonTable.Rows[0]["userId"]}] {headPersonTable.Rows[0]["name"]} ({headPersonTable.Rows[0]["nameDomain"]})";
            }


            /// <summary>
            /// Применить изменения
            /// </summary>
            public void ChangesAccept()
            {
                string nameNew = PARENT.Name_TextBox.Text.Trim(new char[] { ' ', '\n', '\t' });
                int statusIdNew = PARENT.StatusActive_RadioButton.Checked ? STATUS_ACTIVE : STATUS_NOT_ACTIVE;

                if (nameNew == "")
                {
                    MessageBox.Show("Имя новой записи не может быть пустым", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                };
                
                // DEPARTMENT
                if (PARENT.MANAGEMENT_FORM.PROG.sectionIdLast == 1 && departmentHeadPersonId == -1)
                {
                    MessageBox.Show("Не указан руководитель отдела", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Диалог подтверждения изменений
                DialogResult resultDialog = MessageBox.Show($"Сохранить новые данные?",
                    "Подтверждение изменений", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDialog != DialogResult.Yes) return;

                // Работа с SQL
                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@tableName", SqlDbType.VarChar) {
                        Value = PARENT.MANAGEMENT_FORM.PROG.sectionTables[PARENT.MANAGEMENT_FORM.PROG.sectionIdLast]
                    },
                    new SqlParameter("@mode", SqlDbType.VarChar) { Value = PARENT.Mode },
                    new SqlParameter("@recordId", SqlDbType.Int) { Value = recordIdCurrent },
                    new SqlParameter("@recordNameNew", SqlDbType.VarChar) { Value = nameNew },
                    new SqlParameter("@recordStatusIdNew", SqlDbType.Int) { Value = statusIdNew },
                    new SqlParameter("@userIdNew", SqlDbType.Int) { Value = departmentHeadPersonId }
                };
                Tuple<bool, DataSet> resultSql = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("DirectoryUniversalChangerAndCreator", parameters);
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

                // Обновить данные таблицы
                PARENT.MANAGEMENT_FORM.PROG.DataGet();
                MessageBox.Show("Процедура изменения/добавления данных выполнена успешно", "Новые данные справочника", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PARENT.Close();
            }
        }
    }
}