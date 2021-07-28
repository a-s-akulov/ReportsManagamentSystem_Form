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

    public partial class MainMenu
    {
        public class MyProgram
        {
            readonly MainMenu MAIN;

            // Справочник
            public Dictionary<int, Dictionary<string, string>> directoryStatuses;
            public Dictionary<int, Dictionary<string, string>> directoryBrands;
            public Dictionary<int, Dictionary<string, string>> directoryDepartments;
            public Dictionary<int, Dictionary<string, string>> directoryPermissions;
            public Dictionary<int, Dictionary<string, string>> directoryProcedureExitCodes;
            public Dictionary<int, Dictionary<string, string>> directoryReportFrequencies;
            public Dictionary<int, Dictionary<string, string>> directoryReportGroups;
            public Dictionary<int, Dictionary<string, string>> directoryReportToDates;
            public Dictionary<int, Dictionary<string, string>> directoryReportTypes;

            public bool permissionUsersManagementGranted = false;
            public bool permissionReportsManagementGranted = false;
            public bool permissionDirectoryManagementGranted = false;
            public readonly Dictionary<string, Dictionary<int, Dictionary<string, string>>> columnsComparingInfo = new Dictionary<string, Dictionary<int, Dictionary<string, string>>>();
            public DataTable currentUserInfo;
            public DataTable currentUserReportsPermissions;


            public MyProgram(MainMenu parent)
            {
                MAIN = parent;
            }


            public void HelpButtonClicked()
            {
                try
                {
                    System.Diagnostics.Process.Start(Constances.APP_HELP_FILE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось открыть справку: {ex}", "Ошибка открытия справки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            /// <summary>
            /// Получает инфомрацию о текущем пользователе из БД SQL
            /// </summary>
            /// <returns></returns>
            public bool CurrentUserInfoGet(Form module)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@userId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@userName", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output },
                    new SqlParameter("@userNameDomain", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output },
                    new SqlParameter("@email", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output },
                    new SqlParameter("@departmentId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@statusId", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                Tuple<bool, DataSet> result = MAIN.SQL.ProcedureExecWithData("UserInfoGet", parameters);
                if (!result.Item1 || (int)parameters[0].Value != 0)
                {
                    MessageBox.Show($"Ошибка получения данных о текущем пользователе, модуль будет закрыт",
                            "Ошибка (Получение данных пользователя)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    module.Close();
                    MAIN.Show();
                    return false;
                }

                currentUserInfo = new DataTable();
                currentUserInfo.Columns.Add("userId", typeof(int));
                currentUserInfo.Columns.Add("userName", typeof(string));
                currentUserInfo.Columns.Add("userNameDomain", typeof(string));
                currentUserInfo.Columns.Add("email", typeof(string));
                currentUserInfo.Columns.Add("departmentId", typeof(int));
                currentUserInfo.Columns.Add("statusId", typeof(int));

                DataRow rowNew = currentUserInfo.NewRow();
                rowNew["userId"] = (int)parameters[1].Value;
                rowNew["userName"] = (string)parameters[2].Value;
                rowNew["userNameDomain"] = (string)parameters[3].Value;
                rowNew["email"] = (string)parameters[4].Value;
                rowNew["departmentId"] = (int)parameters[5].Value;
                rowNew["statusId"] = (int)parameters[6].Value;

                currentUserInfo.Rows.Add(rowNew);

                return true;
            }


            /// <summary>
            /// Получает разрешения на отчёты для текущего пользователя из БД SQL
            /// </summary>
            /// <returns></returns>
            public bool CurrentUserReportsPermissionsGet(Form module)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                };
                Tuple<bool, DataSet> result = MAIN.SQL.ProcedureExecWithData("UserReportsPermissionsGet", parameters);
                if (!result.Item1 || (int)parameters[0].Value != 0)
                {
                    MessageBox.Show($"Ошибка получения данных о текущем пользователе, модуль будет закрыт",
                            "Ошибка (Получение данных пользователя)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    module.Close();
                    MAIN.Show();
                    return false;
                }

                currentUserReportsPermissions = result.Item2.Tables[0];

                return true;
            }


            /// <summary>
            /// Вызывается при открытии модуля - обновляет словарь, управляет видимость главного и дочернего окна
            /// </summary>
            /// <param name="sections"></param>
            /// <returns></returns>
            public bool DirectoryUpdate(Form module, string[] sections)
            {
                foreach (string section in sections)
                {
                    bool result = DirectoryDataGet(section);
                    if (!result)
                    {
                        MessageBox.Show($"Ошибка получения данных из раздела справочника '{section}', модуль будет закрыт",
                                "Ошибка (Получение данных справочника)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        module.Close();
                        MAIN.Show();
                        return false;
                    }
                }

                module.Show();
                return true;
            }

            /// <summary>
            /// Получает необходимые данные из справочника для сопоставления типизированных данных с их именами/свойствами
            /// </summary>
            /// <returns></returns>
            public bool DirectoryDataGet(string section)
            {
                // Получение данных
                DataTable paramTable = new DataTable();
                paramTable.Columns.Add(new DataColumn("ints"));
                paramTable.Rows.Add(-1);

                SqlParameter[] parameters =
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@tableName", SqlDbType.VarChar) { Value = $"Directory_{section}" },
                    new SqlParameter("@statusIds", SqlDbType.Structured) { Value = paramTable }
                };
                Tuple<bool, DataSet> result = MAIN.SQL.ProcedureExecWithData("UniversalTableSelecter", parameters);
                if (!result.Item1 || (int)parameters[0].Value != 0)
                {
                    return false;
                }

                // Преобразование данных
                DataTable resultTable = result.Item2.Tables[0];
                Dictionary<int, Dictionary<string, string>> dataTransformed = new Dictionary<int, Dictionary<string, string>>();
                foreach (DataRow row in resultTable.Rows)
                {
                    Dictionary<string, string> record = new Dictionary<string, string>();
                    for (int columnId = 0; columnId < resultTable.Columns.Count; columnId++)
                    {
                        record[resultTable.Columns[columnId].ColumnName] = row[columnId].ToString();
                    };
                    dataTransformed[(int)row[0]] = record;
                };

                // Запись данных
                switch (section)
                {
                    case "statuses":
                        directoryStatuses = dataTransformed;
                        columnsComparingInfo["statusId"] = directoryStatuses;
                        break;
                    case "brands":
                        directoryBrands = dataTransformed;
                        columnsComparingInfo["brandId"] = directoryBrands;
                        break;
                    case "departments":
                        directoryDepartments = dataTransformed;
                        columnsComparingInfo["departmentId"] = directoryDepartments;
                        break;
                    case "permissions":
                        directoryPermissions = dataTransformed;
                        columnsComparingInfo["permissionId"] = directoryPermissions;
                        break;
                    case "procedureExitCodes":
                        directoryProcedureExitCodes = dataTransformed;
                        break;
                    case "reportFrequencies":
                        directoryReportFrequencies = dataTransformed;
                        columnsComparingInfo["frequencyId"] = directoryReportFrequencies;
                        break;
                    case "reportGroups":
                        directoryReportGroups = dataTransformed;
                        columnsComparingInfo["groupId"] = directoryReportGroups;
                        break;
                    case "reportToDates":
                        directoryReportToDates = dataTransformed;
                        columnsComparingInfo["toDateId"] = directoryReportToDates;
                        break;
                    case "reportTypes":
                        directoryReportTypes = dataTransformed;
                        columnsComparingInfo["typeId"] = directoryReportTypes;
                        break;
                    default:
                        return false;
                }
                return true;
            }

            /// <summary>
            /// Возвращает таблицу с замененными типизированными данными на их названия из справочника
            /// </summary>
            /// <param name="dataInput"></param>
            /// <returns></returns>
            public DataTable DataCompare(DataTable dataInput)
            {
                DataTable dataOutput = new DataTable();

                // Список обрабатываемых колонок и сборка столбцов новой таблицы
                HashSet<string> columnsTargetedNames = new HashSet<string>();
                foreach (DataColumn column in dataInput.Columns)
                {
                    if (columnsComparingInfo.Keys.Contains(column.ColumnName) && column.ColumnName != dataInput.Columns[0].ColumnName)
                    {
                        columnsTargetedNames.Add(column.ColumnName);
                        dataOutput.Columns.Add($"{column.ColumnName}_Name", typeof(string));
                    }
                    else
                    {
                        dataOutput.Columns.Add(column.ColumnName, column.DataType);
                    }
                }

                // Обработка каждой строки
                DataRow rowNew;
                string columnName;
                foreach (DataRow row in dataInput.Rows)
                {
                    rowNew = dataOutput.Rows.Add();

                    foreach (DataColumn column in dataInput.Columns)
                    {
                        columnName = column.ColumnName;

                        if (columnsTargetedNames.Contains(column.ColumnName))
                        {
                            rowNew[$"{columnName}_Name"] = columnsComparingInfo[columnName][(int)row[columnName]]["name"];
                        }
                        else
                        {
                            rowNew[columnName] = row[columnName];
                        }
                    }
                }

                return dataOutput;
            }


            /// <summary>
            /// Загружает глобальные разрешения пользователя и устанавливает доступность модулей
            /// </summary>
            public void PermissionsLoad()
            {
                SqlParameter[] paramsSql = new SqlParameter[] {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@isGeneralPermission_UsersManagement", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                    new SqlParameter("@isGeneralPermission_ReportsManagement", SqlDbType.Bit) { Direction = ParameterDirection.Output },
                    new SqlParameter("@isGeneralPermission_DirectoryManagement", SqlDbType.Bit) { Direction = ParameterDirection.Output }
                };
                Tuple<bool, DataSet> result = MAIN.SQL.ProcedureExecWithData("UserGeneralPermissionsGet", paramsSql);
                if (!result.Item1) { return; };
                int resultErrorId = (int)paramsSql[0].Value;
                if (resultErrorId != 0)
                {
                    MessageBox.Show($"Ошибка выполнения процедуры получения разрешений. Процедура вернула код: {resultErrorId}.\n\nМодуль будет закрыт",
                        "Ошибка загрузки разрешений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MAIN.Close();
                    return;
                }

                permissionUsersManagementGranted = (bool)paramsSql[1].Value;
                permissionReportsManagementGranted = (bool)paramsSql[2].Value;
                permissionDirectoryManagementGranted = (bool)paramsSql[3].Value;

                MAIN.UsersManagement_Button.Enabled = permissionUsersManagementGranted;
                MAIN.DirectoryManagement_Button.Enabled = permissionDirectoryManagementGranted;
            }


            public void ControlCustomBorderPainter(
                Control sender,
                PaintEventArgs e = null, // при null пока что не работал

                int lineWidth = 1,
                int borderOffset = 1,
                Brush brush = null,

                bool ignoreWhenControlFocused = true,
                bool ignoreWhenMouseOnControl = true
            )
            {
                if (brush is null) brush = Brushes.DarkOrange;

                int width = sender.Width;
                int height = sender.Height;
                Point senderLocationOnScreen = sender.Parent.PointToScreen(sender.Location);

                if (
                    (
                        ignoreWhenControlFocused &&
                        sender.Focused
                    ) ||
                    (
                        ignoreWhenMouseOnControl &&
                        MousePosition.X >= senderLocationOnScreen.X &&
                        MousePosition.X < senderLocationOnScreen.X + width &&
                        MousePosition.Y >= senderLocationOnScreen.Y &&
                        MousePosition.Y < senderLocationOnScreen.Y + height
                    )
                ) return;

                Graphics graphics = e is null ? sender.CreateGraphics() : e.Graphics;
                Pen pen = new Pen(brush) { Width = lineWidth };

                
                graphics.DrawRectangle(pen, new Rectangle(
                    new Point(borderOffset + lineWidth / 2, borderOffset + lineWidth / 2),
                    new Size(width - lineWidth - borderOffset * 2, height - lineWidth - borderOffset * 2)
                ));
            }

            public void GridViewVisualisationAdjustment(DevExpress.XtraGrid.Views.Grid.GridView gridView)
            {
                Dictionary<string, string> columnsNamesDictionary = new Dictionary<string, string>()
                {
                    { "idx", "ID" },
                    { "name", "Имя" },
                    { "nameDomain", "Доменное имя" },
                    { "email", "E-Mail" },

                    { "statusId", "ID статуса" },
                    { "statusId_Name", "Статус" },
                    { "brandId", "ID Бренда" },
                    { "brandId_Name", "Бренд" },
                    { "departmentId", "ID Отдела" },
                    { "departmentId_Name", "Отдел" },
                    { "groupId", "ID группы отчёта" },
                    { "groupId_Name", "Группа отчёта" },
                    { "typeId", "ID Типа отчёта" },
                    { "typeId_Name", "Тип отчёта" },
                    { "frequencyId", "ID Частоты подготовки отчёта" },
                    { "frequencyId_Name", "Частота подготовки отчёта" },
                    { "toDateId", "ID Даты подготовки отчёта" },
                    { "toDateId_Name", "Дата подготовки отчёта" },

                    { "headPersonId", "ID Руководителя отдела" },
                    { "headPersonId_Name", "Руководитель отдела" },
                    { "headPersonId_NameDomain", "Доменное имя руководителя отдела" },
                    { "headPersonId_Email", "E-Mail Руководителя отдела" },

                    { "userId", "ID Пользователя" },
                    { "userId_Name", "Пользователь" },
                    { "userId_NameDomain", "Доменное имя пользователя" },
                    { "userId_Email", "E-Mail Пользователя" },

                    { "dateCreated", "Дата создания" },
                    { "createdDate", "Дата создания" },
                    { "createdUserId", "ID Создавшего пользователя" },
                    { "createdUserId_Name", "Создавший пользователь" },
                    { "createdUserId_NameDomain", "Доменное имя создавшего пользователя" },
                    { "createdUserId_Email", "E-Mail Создавшего пользователя" },

                    { "dateChanged", "Дата изменения" },
                    { "changedUserId", "ID Изменившего пользователя" },
                    { "changedUserId_Name", "Изменивший пользователь" },
                    { "changedUserId_NameDomain", "Доменное имя изменившего пользователя" },
                    { "changedUserId_Email", "E-Mail Изменившего пользователя" },

                    { "updatedDate", "Дата обновления" },
                    { "updatedUserId", "ID Обновившего пользователя" },
                    { "updatedUserId_Name", "Обновивший пользователь" },
                    { "updatedUserId_NameDomain", "Доменное имя обновившего пользователя" },
                    { "updatedUserId_Email", "E-Mail Обновившего пользователя" },

                    { "responsiblePersonId", "ID Ответственного" },
                    { "responsiblePersonId_Name", "Ответственный" },
                    { "responsiblePersonId_NameDomain", "Доменное имя ответственного" },
                    { "responsiblePersonId_Email", "E-Mail Ответственного" },

                    { "instanceId", "ID Экземпляра" },
                    { "reportId", "ID Отчёта" },
                    { "reportId_Name", "Отчёт" },

                    { "receiversCount", "Получателей" },
                    { "contentDescription", "Описание" },
                    { "remark", "Заметки" },
                    { "notifyDepartmentHead", "Уведомлять руководителя" }
                };

                foreach (GridColumn column in gridView.Columns)
                {
                    if (columnsNamesDictionary.ContainsKey(column.FieldName)) column.Caption = columnsNamesDictionary[column.FieldName];
                    column.BestFit();
                };
            }
        }
    }
}