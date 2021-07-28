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
using System.IO;
using System.Diagnostics;

namespace ReportsManagementSystemForm
{
    public partial class Pass { }

    public partial class ReportsManagement_instance_editor
    {
        public class MyProgram
        {
            public readonly ReportsManagement_instance_editor PARENT;
            public readonly int STATUS_ACTIVE;
            public readonly int STATUS_NOT_ACTIVE;

            public int[] departmentIds;
            public Tuple<int, string>[] reportsArray;

            int instanceId = -1;
            HashSet<string> filesCurrentNamesSet = new HashSet<string>();
            HashSet<string> filesAddPathsSet = new HashSet<string>();
            HashSet<string> filesAddNamesSet = new HashSet<string>();
            HashSet<string> filesRemoveNamesSet = new HashSet<string>();

            public MyProgram(ReportsManagement_instance_editor parent)
            {
                PARENT = parent;
                STATUS_ACTIVE = Constances.STATUS_ACTIVE;
                STATUS_NOT_ACTIVE = Constances.STATUS_NOT_ACTIVE;
                


                ControlsInit();
                if (PARENT.Mode == "EDIT" || PARENT.Mode == "READ") DataFieldsFill();
            }


            /// <summary>
            /// Устанавливает имена элементов управленя для корреткного отображения
            /// </summary>
            private void ControlsInit()
            {
                if (PARENT.Mode == "ADD") PARENT.Text += "добавление";
                else if (PARENT.Mode == "EDIT") PARENT.Text += "редактирование";
                else if (PARENT.Mode == "READ") PARENT.Text += "просмотр";

                // department
                departmentIds = PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments.Values
                    .Where(v => v["statusId"] == STATUS_ACTIVE.ToString())
                    .Select(v => int.Parse(v["departmentId"]))
                    .ToArray();

                int indexToSelect = 0;
                int currentUserDepartmentId = (int)PARENT.MANAGEMENT_FORM.MAIN.PROG.currentUserInfo.Rows[0]["departmentId"];
                if (departmentIds.Contains(currentUserDepartmentId)) indexToSelect = Array.IndexOf(departmentIds, currentUserDepartmentId);

                PARENT.Department_ComboBox.Items.Clear();
                foreach (int departmentId in departmentIds)
                    PARENT.Department_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments[departmentId]["name"]);

                if (PARENT.Department_ComboBox.Items.Count > 0) PARENT.Department_ComboBox.SelectedIndex = indexToSelect;
                PARENT.Department_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                DepartmentChanged();

                RichEditControlMarginsSet(PARENT.Message_RichEditControl);
            }

            private void RichEditControlMarginsSet(DevExpress.XtraRichEdit.RichEditControl control, int left = 0, int right = 0, int top = 0, int bottom = 0)
            {
                control.Document.Sections[0].Margins.Left = left;
                control.Document.Sections[0].Margins.Right = right;
                control.Document.Sections[0].Margins.Top = top;
                control.Document.Sections[0].Margins.Bottom = bottom;
            }

            /// <summary>
            /// Заполняет данные при режиме редактирования
            /// </summary>
            private void DataFieldsFill()
            {
                int[] selectedRowsIds = PARENT.MANAGEMENT_FORM.INST_Data_GridView.GetSelectedRows();
                if (selectedRowsIds.Count() == 0 || selectedRowsIds[0] < 0)
                {
                    MessageBox.Show("Не выбрана ни одна строка", "Просмотр или редактирование записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PARENT.Close();
                    return;
                }

                DataRow rowRaw = PARENT.MANAGEMENT_FORM.PROG_INST.DataRaw.Rows[selectedRowsIds[0]];
                DataRow rowVisible = PARENT.MANAGEMENT_FORM.PROG_INST.DataVisible.Rows[selectedRowsIds[0]];
                instanceId = (int)rowRaw[0];

                int reportId = (int)rowRaw["reportId"];
                int departmentId = PARENT.MANAGEMENT_FORM.PROG_INST.departmentIdCurrent;
                string reportName = (string)rowRaw["reportId_Name"];
                int statusId = (int)rowRaw["statusId"];

                if (PARENT.Mode == "EDIT")
                {
                    DataRow[] permissionEditRows = PARENT.MANAGEMENT_FORM.MAIN.PROG.currentUserReportsPermissions.Select(
                        $"reportId = {reportId} AND permissionId = {Constances.PERMISSION_REPORTS_INSTANCES_UPDATING}");
                    if (permissionEditRows.Count() == 0)
                    {
                        PARENT.Mode = "READ";
                        PARENT.Text = "Управление экземпляром отчёта - просмотр";
                    }
                }

                PARENT.Department_ComboBox.Items.Clear();
                PARENT.Department_ComboBox.Items.Add(PARENT.MANAGEMENT_FORM.MAIN.PROG.directoryDepartments[departmentId]["name"]);
                PARENT.Department_ComboBox.SelectedIndex = 0;

                PARENT.Report_ComboBox.Items.Clear();
                PARENT.Report_ComboBox.Items.Add(reportName);
                PARENT.Report_ComboBox.SelectedIndex = 0;

                PARENT.InstanceId_TextBox.Text = instanceId.ToString();

                if (statusId == STATUS_ACTIVE)
                {
                    // Список файлов
                    PARENT.Files_ListBox.Items.Clear();
                    string filesRegistryFilePath = $"{Constances.INSTANCE_HOME_DIR_PATH}\\{instanceId}\\registry";
                    if (File.Exists(filesRegistryFilePath))
                    {
                        try
                        {
                            using (StreamReader sr = new StreamReader(filesRegistryFilePath, System.Text.Encoding.UTF8))
                            {
                                string fileName;
                                while ((fileName = sr.ReadLine()) != null)
                                {
                                    filesCurrentNamesSet.Add(fileName);
                                    PARENT.Files_ListBox.Items.Add(fileName);
                                }
                            }
                        }
                        catch (System.Exception e)
                        {
                            MessageBox.Show($"Не удалось прочитать файл реестра файлов экземпляра отчёта:\n\n{e.GetType()}: {e.Message}",
                                "Ошибка чтения реестра файлов экземпляра", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    } else MessageBox.Show($"Файл реестра файлов экземпляра отчёта не найден", "Ошибка чтения реестра файлов экземпляра", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // Сообщение получателям
                    string messageFilePath = $"{Constances.INSTANCE_HOME_DIR_PATH}\\{instanceId}\\message";
                    if (File.Exists(messageFilePath))
                    {
                        try
                        {
                            using (StreamReader sr = new StreamReader(messageFilePath, System.Text.Encoding.UTF8))
                            {
                                PARENT.Message_RichEditControl.HtmlText = sr.ReadToEnd();
                                RichEditControlMarginsSet(PARENT.Message_RichEditControl);
                            }
                        }
                        catch (System.Exception e)
                        {
                            MessageBox.Show($"Не удалось прочитать файл сообщения получателям экземпляра отчёта:\n\n{e.GetType()}: {e.Message}",
                                "Ошибка чтения сообщения получателям экземпляра", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else MessageBox.Show($"Файл сообщения получателям экземпляра отчёта не найден", "Ошибка чтения сообщения получателям экземпляра",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                PARENT.Department_ComboBox.Enabled = false;
                PARENT.Report_ComboBox.Enabled = false;

                if (PARENT.Mode == "READ" || statusId != STATUS_ACTIVE)
                {
                    PARENT.Files_add_Button.Enabled = false;
                    PARENT.Files_delete_Button.Enabled = false;
                    PARENT.Message_fullEditor_open_Button.Enabled = false;
                    PARENT.Message_RichEditControl.ReadOnly = true;
                    PARENT.ChangesAccept_Button.Enabled = false;
                }
                
                if (statusId == STATUS_ACTIVE) PARENT.Files_get_Button.Enabled = true;
            }


            public void DepartmentChanged()
            {
                if (PARENT.Mode != "ADD") return;

                int departmentId = departmentIds[PARENT.Department_ComboBox.SelectedIndex];

                DataRow[] permissionsRows = PARENT.MANAGEMENT_FORM.MAIN.PROG.currentUserReportsPermissions.Select(
                    $"departmentId = {departmentId} AND permissionId = {Constances.PERMISSION_REPORTS_INSTANCES_CREATING}");

                int i = 0;
                int reportId;
                string reportName;
                PARENT.Report_ComboBox.Items.Clear();
                reportsArray = new Tuple<int, string>[permissionsRows.Count()];
                foreach (DataRow row in permissionsRows)
                {
                    reportId = (int)row["reportId"];
                    reportName = (string)row["reportName"];
                    reportsArray[i] = new Tuple<int, string>(reportId, reportName);

                    PARENT.Report_ComboBox.Items.Add(reportName);

                    i++;
                }

                if (PARENT.Report_ComboBox.Items.Count > 0) PARENT.Report_ComboBox.SelectedIndex = 0;
                PARENT.Report_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }


            public void FilesAdd()
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        int filesCountAdded = 0;
                        int filesCountSkipped = 0;
                        string fileName;
                        foreach (string filePath in openFileDialog.FileNames)
                        {
                            if (File.Exists(filePath))
                            {
                                fileName = Path.GetFileName(filePath);

                                if (!filesAddNamesSet.Contains(fileName) && (!filesCurrentNamesSet.Contains(fileName) || filesRemoveNamesSet.Contains(fileName)))
                                {
                                    filesAddPathsSet.Add(filePath);
                                    filesAddNamesSet.Add(fileName);
                                    PARENT.Files_ListBox.Items.Add(filePath);
                                    filesCountAdded++;
                                }
                                else
                                {
                                    MessageBox.Show($"Файл с именем '{fileName}' уже выбран.\n" +
                                        $"Файл '{filePath}' не может быть добавлен и будет пропущен (даже если имеет другой путь)",
                                        "Редактирование списка файлов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    filesCountSkipped++;
                                }
                            }
                            else filesCountSkipped++;
                        }

                        MessageBox.Show($"Добавлено файлов: {filesCountAdded}\nПропущено файлов: {filesCountSkipped}",
                            "Редактирование списка файлов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }


            public void FilesDelete()
            {
                var selectedIndices_ = PARENT.Files_ListBox.SelectedIndices;
                int[] selectedIndicesArray = new int[selectedIndices_.Count];
                selectedIndices_.CopyTo(selectedIndicesArray, 0);

                int selectedIndicesCount = selectedIndicesArray.Count();

                if (selectedIndicesCount == 0)
                {
                    MessageBox.Show("Не выбрана ни одна строка", "Редактирование списка файлов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (DialogResult.Yes != MessageBox.Show($"Удалить {selectedIndicesCount} файлов из списка?",
                        "Редактирование списка файлов", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) return;
                }

                int i = 0;
                string filePathOrName;
                foreach (int selectedIndex in selectedIndicesArray)
                {
                    filePathOrName = (string)PARENT.Files_ListBox.Items[selectedIndex - i];

                    if (filesCurrentNamesSet.Contains(filePathOrName))
                    {
                        filesRemoveNamesSet.Add(filePathOrName);
                    }
                    else
                    {
                        filesAddPathsSet.Remove(filePathOrName);
                        filesAddNamesSet.Remove(Path.GetFileName(filePathOrName));
                    }

                    PARENT.Files_ListBox.Items.RemoveAt(selectedIndex - i);
                    i++;
                }
            }


            public void FilesGet()
            {
                if (instanceId == -1)
                {
                    MessageBox.Show("Не указан ID экземпляра", "Ошибка получения файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = "Выберите место для сохранения архива",
                    InitialDirectory = "c:\\",
                    Filter = "ZIP-архивы (*.zip)|*.zip",
                    RestoreDirectory = true
                };
                saveFileDialog.ShowDialog();

                string resultFileName = saveFileDialog.FileName;
                if (resultFileName == "") return;

                // Работа с файлами
                ReportsManagement_instance_files_handler filesHandler = new ReportsManagement_instance_files_handler(
                    "DOWNLOAD",
                    new object[] { instanceId, resultFileName },
                    hideSuccessMessage: true
                );
                if (DialogResult.Yes != filesHandler.ShowDialog())
                {
                    filesHandler.Dispose();
                    return;
                }
                filesHandler.Dispose();

                // Отправка события в SQL
                SqlParameter[] parameters =
                {
                    new SqlParameter("@event", SqlDbType.VarChar) { Value = "OPENED" },
                    new SqlParameter("@instanceId", SqlDbType.Int) { Value = instanceId },
                    new SqlParameter("@href", SqlDbType.VarChar) { Value = "RM" },
                };
                PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("ReportsInstancesEventsHandler", parameters);

                MessageBox.Show("Архив файлов экземпляра отчёта успешно получен", "Архив получен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    Process.Start(resultFileName);
                }
                catch (System.Exception e)
                {
                    MessageBox.Show($"Не удалось открыть архив экземпляра отчёта:\n\n{e.GetType()}: {e.Message}",
                        "Ошибка открытия полученного архива", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            public void MessageEditInFullEditor()
            {
                ModuleRichTextInput textInputModule = new ModuleRichTextInput();
                textInputModule.SuspendLayout();

                textInputModule.Text_RichEditControl.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
                textInputModule.Text_RichEditControl.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
                textInputModule.changeSectionPageMarginsItem1.Dispose();
                textInputModule.changeSectionPageOrientationItem1.Dispose();
                textInputModule.changeSectionPaperKindItem1.Dispose();
                textInputModule.reviewRibbonPage1.Visible = false;

                textInputModule.Text_RichEditControl.HtmlText = PARENT.Message_RichEditControl.HtmlText;
                RichEditControlMarginsSet(textInputModule.Text_RichEditControl);

                textInputModule.ResumeLayout();

                if (DialogResult.Yes == textInputModule.ShowDialog())
                {
                    PARENT.Message_RichEditControl.HtmlText = textInputModule.Text_RichEditControl.HtmlText;
                    RichEditControlMarginsSet(PARENT.Message_RichEditControl);
                }

                textInputModule.Dispose();
            }


            /// <summary>
            /// Применить изменения
            /// </summary>
            public void ChangesAccept() // ОТСУТСТВУЕТ ОБРАБОТКА СООБЩЕНИЯ ПОЛУЧАТЕЛЯМ И РЕДАКТИРОВАНИЕ
            {
                int reportId;
                int departmentId = departmentIds[PARENT.Department_ComboBox.SelectedIndex];
                int reportIdIndex = PARENT.Report_ComboBox.SelectedIndex; // in ADD mode ONLY
                string messageHTML = PARENT.Message_RichEditControl.HtmlText;

                // ПРОВЕРКА ВВЕДЕННЫХ ДАННЫХ
                // reportId
                if (PARENT.Mode == "ADD")
                {
                    if (reportIdIndex < 0)
                    {
                        MessageBox.Show("Не указан отчёт", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                // files
                if (filesAddNamesSet.Count == 0 && filesCurrentNamesSet.Count == filesRemoveNamesSet.Count)
                {
                    MessageBox.Show("Не выбраны файлы для загрузки", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // message
                if (PARENT.Message_RichEditControl.Text == "")
                {
                    MessageBox.Show("Должно быть указано сообщение для получателей отчёта", "Ошибка заполнения поля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                // Диалог подтверждения изменений
                if (DialogResult.Yes != MessageBox.Show($"Сохранить новые данные?",
                    "Подтверждение изменений", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) return;

                // Работа с SQL
                SqlParameter[] parametersSQL;
                if (PARENT.Mode == "ADD")
                {
                    reportId = reportsArray[reportIdIndex].Item1;
                    parametersSQL = new SqlParameter[]
                    {
                        new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                        new SqlParameter("@instanceId", SqlDbType.Int) { Direction = ParameterDirection.Output },

                        new SqlParameter("@mode", SqlDbType.VarChar) { Value = PARENT.Mode },
                        new SqlParameter("@reportId", SqlDbType.Int) { Value = reportId },
                        new SqlParameter("@statusId", SqlDbType.Int) { Value = Constances.STATUS_RECEIVING_FILES }
                    };
                }
                else
                {
                    parametersSQL = new SqlParameter[]
                    {
                        new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },
                        new SqlParameter("@instanceId", SqlDbType.Int) { Value = instanceId },

                        new SqlParameter("@mode", SqlDbType.VarChar) { Value = PARENT.Mode },
                        new SqlParameter("@statusId", SqlDbType.Int) { Value = Constances.STATUS_RECEIVING_FILES }
                    };
                }
                Tuple<bool, DataSet> resultSql = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("ReportsInstancesRegistryUniversalChangerAndCreator", parametersSQL);
                if (resultSql.Item1)
                {
                    int resultSqlProcedure = (int)parametersSQL[0].Value;
                    if (resultSqlProcedure != 0)
                    {
                        string errorText;
                        if (resultSqlProcedure == Constances.ERROR_ACCESS_DENIED_ERROR)
                            errorText = "Ошибка: Отказано в доступе";
                        else if (resultSqlProcedure == Constances.ERROR_SOURSE_NOT_FOUND_ERROR)
                            errorText = "Ошибка: указанный экземпляр не найден в реестре";
                        else errorText = $"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}";

                        MessageBox.Show(errorText,
                            "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else return;

                if (PARENT.Mode == "ADD") instanceId = (int)parametersSQL[1].Value;

                // Работа с файлами
                if (filesAddPathsSet.Count > 0)
                {
                    ReportsManagement_instance_files_handler filesHandler = new ReportsManagement_instance_files_handler(
                        "UPLOAD",
                        new object[] { filesAddPathsSet.ToArray(), instanceId },
                        hideSuccessMessage: true
                    );
                    if (DialogResult.Yes != filesHandler.ShowDialog())
                    {
                        filesHandler.Dispose();

                        ReportInstanceStatusUpdate(instanceId, Constances.STATUS_RECEIVING_FILES_ERROR); // Нет проверки успеха обновления статуса
                        return;
                    }
                    filesHandler.Dispose();
                }

                // Создание файла реестра файлов экземпляра
                try
                {
                    string registryFilePath = $"{Constances.INSTANCE_HOME_DIR_PATH}\\{instanceId}\\registryRaw";

                    if (File.Exists(registryFilePath)) File.Delete(registryFilePath);
                    using (FileStream fs = File.Create(registryFilePath))
                    {
                        byte[] fileNameBytes;
                        int fileId = 0;

                        // remove
                        foreach (string fileName in filesRemoveNamesSet)
                        {
                            fileNameBytes = new UTF8Encoding(true).GetBytes(fileId == 0 ? $"REM|{Path.GetFileName(fileName)}" : $"\nREM|{Path.GetFileName(fileName)}");
                            fs.Write(fileNameBytes, 0, fileNameBytes.Length);

                            fileId++;
                        }

                        // add
                        foreach (string fileName in filesAddNamesSet)
                        {
                            fileNameBytes = new UTF8Encoding(true).GetBytes(fileId == 0 ? $"ADD|{Path.GetFileName(fileName)}" : $"\nADD|{Path.GetFileName(fileName)}");
                            fs.Write(fileNameBytes, 0, fileNameBytes.Length);

                            fileId++;
                        }
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show($"Не удалось создать файл реестра файлов экземпляра:\n\n{e.GetType()}: {e.Message}",
                        "Ошибка отправки файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ReportInstanceStatusUpdate(instanceId, Constances.STATUS_RECEIVING_FILES_ERROR); // Нет проверки успеха обновления статуса
                    return;
                }

                // Создание файла сообщения получателей экземпляра
                try
                {
                    string messageFilePath = $"{Constances.INSTANCE_HOME_DIR_PATH}\\{instanceId}\\messageRaw";

                    if (File.Exists(messageFilePath)) File.Delete(messageFilePath);
                    using (FileStream fs = File.Create(messageFilePath))
                    {
                        byte[] messageBytes = new UTF8Encoding(true).GetBytes(messageHTML);
                        fs.Write(messageBytes, 0, messageBytes.Length);
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show($"Не удалось создать файл сообщения получателям отчёта:\n\n{e.GetType()}: {e.Message}",
                        "Ошибка отправки файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ReportInstanceStatusUpdate(instanceId, Constances.STATUS_RECEIVING_FILES_ERROR); // Нет проверки успеха обновления статуса
                    return;
                }

                // Работа с удаленным обработчиком экземпляра
                ReportsManagement_instance_remote_handler instanceRemoteHandler = new ReportsManagement_instance_remote_handler(
                    new object[] { PARENT.Mode == "ADD" ? 0 : 1, instanceId, (int)PARENT.MANAGEMENT_FORM.MAIN.PROG.currentUserInfo.Rows[0]["userId"] },
                    hideSuccessMessage: true
                );
                if (DialogResult.Yes != instanceRemoteHandler.ShowDialog())
                {
                    instanceRemoteHandler.Dispose();

                    ReportInstanceStatusUpdate(instanceId, Constances.STATUS_RECORD_HANDLING_ERROR, checkStatus: true); // Нет проверки успеха обновления статуса
                    return;
                };
                instanceRemoteHandler.Dispose();


                // Завершение
                MessageBox.Show("Процедура изменения/добавления экземпляра отчёта выполнена успешно.", "Новые данные экземпляра отчёта в реестре",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (PARENT.Mode == "ADD" && PARENT.MANAGEMENT_FORM.PROG_INST.departmentIds.Contains(departmentId))
                {
                    PARENT.MANAGEMENT_FORM.INST_department_ComboBox.SelectedIndex = Array.IndexOf(PARENT.MANAGEMENT_FORM.PROG_INST.departmentIds, departmentId);
                }
                PARENT.MANAGEMENT_FORM.PROG_INST.DataGet();
                PARENT.Close();
            }


            public bool ReportInstanceStatusUpdate(int instanceId, int statusId, bool checkStatus = false)
            {
                SqlParameter[] parametersSql;
                Tuple<bool, DataSet> resultSql;

                // Проверить, отличается ли устанавливаемый статус от текущего
                if (checkStatus)
                {
                    parametersSql = new SqlParameter[]
                    {
                        new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },

                        new SqlParameter("@instanceId", SqlDbType.Int) { Value = instanceId }
                    };

                    resultSql = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("ReportsInstancesRegistrySelecter", parametersSql);
                    if (resultSql.Item1)
                    {
                        int resultSqlProcedure = (int)parametersSql[0].Value;
                        if (resultSqlProcedure != 0)
                        {
                            string errorText;
                            if (resultSqlProcedure == Constances.ERROR_ACCESS_DENIED_ERROR)
                                errorText = "Ошибка: Отказано в доступе";
                            else if (resultSqlProcedure == Constances.ERROR_SOURSE_NOT_FOUND_ERROR)
                                errorText = "Ошибка: указанный экземпляр не найден в реестре";
                            else errorText = $"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}";

                            MessageBox.Show(errorText,
                                "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else return false;

                    DataSet dataSet = resultSql.Item2;
                    if (dataSet.Tables.Count != 0 && dataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow row = dataSet.Tables[0].Rows[0];
                        if ((int)row["statusId"] == statusId) return true; // Сама проверка на соответствие, если статусы уже совпадают - менять не требуется
                    }
                }

                parametersSql = new SqlParameter[]
                {
                    new SqlParameter("@resultErrorId", SqlDbType.Int) { Direction = ParameterDirection.Output },

                    new SqlParameter("@mode", SqlDbType.VarChar) { Value = "EDIT" },
                    new SqlParameter("@instanceId", SqlDbType.Int) { Value = instanceId },
                    new SqlParameter("@statusId", SqlDbType.Int) { Value = statusId },
                    new SqlParameter("@isPermissionForced", SqlDbType.Bit) { Value = true }
                };

                resultSql = PARENT.MANAGEMENT_FORM.MAIN.SQL.ProcedureExecWithData("ReportsInstancesRegistryUniversalChangerAndCreator", parametersSql);
                if (resultSql.Item1)
                {
                    int resultSqlProcedure = (int)parametersSql[0].Value;
                    if (resultSqlProcedure != 0)
                    {
                        string errorText;
                        if (resultSqlProcedure == Constances.ERROR_ACCESS_DENIED_ERROR)
                            errorText = "Ошибка: Отказано в доступе";
                        else if (resultSqlProcedure == Constances.ERROR_SOURSE_NOT_FOUND_ERROR)
                            errorText = "Ошибка: указанный экземпляр не найден в реестре";
                        else errorText = $"Ошибка: SQL-процедура завершилась с кодом {resultSqlProcedure}";

                        MessageBox.Show(errorText,
                            "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else return false;

                return true;
            }
        }
    }
}