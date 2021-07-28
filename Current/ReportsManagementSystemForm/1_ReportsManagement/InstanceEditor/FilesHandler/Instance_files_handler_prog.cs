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
using System.Threading;

namespace ReportsManagementSystemForm
{
    public partial class Pass { }

    public partial class ReportsManagement_instance_files_handler
    {
        public class MyProgram
        {
            public readonly ReportsManagement_instance_files_handler PARENT;

            readonly object synContext;



            public MyProgram(ReportsManagement_instance_files_handler parent)
            {
                PARENT = parent;

                synContext = SynchronizationContext.Current;

                Init();
            }


            private void Init()
            {
                
            }

            public void FilesUpload(object[] params_)
            {
                string[] files = (string[])params_[0];
                int instanceId = (int)params_[1];

                string filesRawPath = $"{Constances.INSTANCE_HOME_DIR_PATH}\\{instanceId}\\filesRaw";

                PARENT.ProgressPanel.Caption = "Отправка файлов. Пожалуйста, подождите";

                // Проверка существования родительского каталога
                if (!Directory.Exists(Constances.INSTANCE_HOME_DIR_PATH))
                {
                    MessageBox.Show("Домашний каталог не найден, отправка файлов невозможна",
                        "Ошибка отправки файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    PARENT.DialogResult = DialogResult.No;
                    return;
                }

                // Создание папки для хранения файлов
                if (!Directory.Exists(filesRawPath))
                {
                    try
                    {
                        Directory.CreateDirectory(filesRawPath);
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show($"Не удалось создать каталог для файлов:\n\n{e.GetType()}: {e.Message}",
                            "Ошибка отправки файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        PARENT.DialogResult = DialogResult.No;
                        return;
                    }
                }

                // Очистка папки от файлов
                foreach (string filePath in Directory.GetFiles(filesRawPath))
                {
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show($"Не удалось очистить каталог для файлов:\n\n{e.GetType()}: {e.Message}",
                            "Ошибка отправки файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        PARENT.DialogResult = DialogResult.No;
                        return;
                    }
                }

                Thread uploadThread = new Thread(FilesUpload_);
                uploadThread.Start(new object[] { synContext, filesRawPath, files });
            }


            private void FilesUpload_(object params_) // выполняется в отдельном потоке
            {
                object[] paramsArray = (object[])params_;
                SynchronizationContext context = (SynchronizationContext)paramsArray[0];
                string filesDirectoryPath = (string)paramsArray[1];
                string[] files = (string[])paramsArray[2];

                try
                {
                    int fileIdCurrent = 0;
                    int filesCount = files.Count();
                    foreach (string file_ in files)
                    {
                        context.Send(OnFilesUploadProcessVisualisationUpdated, $"Отправлено файлов: {fileIdCurrent} из {filesCount}");
                        File.Copy(file_, $"{filesDirectoryPath}\\{Path.GetFileName(file_)}");

                        fileIdCurrent++;
                    }
                }
                catch (System.Exception e)
                {
                    context.Send(OnFilesUploadCompleted, new object[] { false, $"{e.GetType()}: {e.Message}" });
                    return;
                }

                context.Send(OnFilesUploadCompleted, new object[] { true, "" });;
            }


            public void FilesDownload(object[] params_)
            {
                int instanceId = (int)params_[0];
                string resultFileName = (string)params_[1];

                string archivePath = $"{Constances.INSTANCE_HOME_DIR_PATH}\\{instanceId}\\files.zip";
                if (!File.Exists(archivePath))
                {
                    MessageBox.Show("Не найден архив файлов экземпляра отчёта", "Ошибка получения файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    PARENT.DialogResult = DialogResult.No;
                    return;
                }

                PARENT.ProgressPanel.Caption = "Получение файлов. Пожалуйста, подождите";
                PARENT.ProgressPanel.Description = "Получение архива...";

                Thread uploadThread = new Thread(FilesDownload_);
                uploadThread.Start(new object[] { synContext, archivePath, resultFileName });
            }


            private void FilesDownload_(object params_) // выполняется в отдельном потоке
            {
                object[] paramsArray = (object[])params_;
                SynchronizationContext context = (SynchronizationContext)paramsArray[0];
                string fileFromName = (string)paramsArray[1];
                string fileToName = (string)paramsArray[2];

                try
                {
                    File.Copy(fileFromName, fileToName);
                }
                catch (System.Exception e)
                {
                    context.Send(OnFilesDownloadCompleted, new object[] { false, $"{e.GetType()}: {e.Message}" });
                    return;
                }

                context.Send(OnFilesDownloadCompleted, new object[] { true, "" });
                return;
            }



            /// <summary>
            /// ////////////// THREADING - события
            /// </summary>

            // UPLOAD
            public void OnFilesUploadProcessVisualisationUpdated(object params_)
            {
                if (PARENT.IsDisposed) { return; };
                if (params_ is null) { return; };

                PARENT.ProgressPanel.Description = (string)params_;
            }


            public void OnFilesUploadCompleted(object params_)
            {
                if (PARENT.IsDisposed) { return; };
                if (params_ is null) { return; };

                object[] paramsArray = (object[])params_;
                bool isSuccess = (bool)paramsArray[0];
                string errorText = (string)paramsArray[1];

                if (isSuccess)
                {
                    if (!PARENT.hideSuccessMessage) MessageBox.Show($"Все файлы успешно отправлены",
                        "Все файлы успешно отправлены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Не удалось копировать указанные файлы в целевую папку:\n\n{errorText}",
                        "Ошибка отправки файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                PARENT.DialogResult = isSuccess ? DialogResult.Yes : DialogResult.No;
            }

            // DOWNLOAD
            public void OnFilesDownloadCompleted(object params_)
            {
                if (PARENT.IsDisposed) { return; };
                if (params_ is null) { return; };

                object[] paramsArray = (object[])params_;
                bool isSuccess = (bool)paramsArray[0];
                string errorText = (string)paramsArray[1];

                if (isSuccess)
                {
                    if (!PARENT.hideSuccessMessage) MessageBox.Show($"Все файлы успешно получены",
                        "Все файлы успешно получены", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show($"Не удалось получить указанные файлы:\n\n{errorText}",
                        "Ошибка получения файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                PARENT.DialogResult = isSuccess ? DialogResult.Yes : DialogResult.No;
            }
        }
    }
}