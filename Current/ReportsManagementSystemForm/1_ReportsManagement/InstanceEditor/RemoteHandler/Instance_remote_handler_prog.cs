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
using System.Diagnostics;

namespace ReportsManagementSystemForm
{
    public partial class Pass { }

    public partial class ReportsManagement_instance_remote_handler
    {
        public class MyProgram
        {
            public readonly ReportsManagement_instance_remote_handler PARENT;

            readonly object synContext;



            public MyProgram(ReportsManagement_instance_remote_handler parent)
            {
                PARENT = parent;

                synContext = SynchronizationContext.Current;

                Init();
            }


            private void Init()
            {
                
            }

            
            public void InstanceRemoteHandlerExec(object[] params_)
            {
                int modeId = (int)params_[0];
                int instanceId = (int)params_[1];
                int userId = (int)params_[2];

                PARENT.ProgressPanel.Caption = "Обработка экземпляра сервером. Пожалуйста, подождите";
                PARENT.ProgressPanel.Description = "Обработка экземпляра...";

                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = Constances.INSTANCE_REMOTE_EXEC_FILE,
                        Arguments = $"{modeId} {instanceId} {userId}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                Thread remoteExecThread = new Thread(InstanceRemoteHandlerExec_);
                remoteExecThread.Start(new object[] { synContext, process });
            }


            private void InstanceRemoteHandlerExec_(object params_) // выполняется в отдельном потоке
            {
                int exitCode;

                object[] paramsArray = (object[])params_;
                SynchronizationContext context = (SynchronizationContext)paramsArray[0];
                Process process = (Process)paramsArray[1];

                try
                {
                    process.Start();
                    while (!process.HasExited)
                    {
                        Thread.Sleep(1000);
                    }
                    exitCode = process.ExitCode;
                }
                catch (Exception ex)
                {
                    Exception exc = ex;
                    string mes = $"{exc.GetType()}: {exc.Message}\n\n";
                    while (exc.InnerException != null)
                    {
                        exc = exc.InnerException;
                        mes += $"{exc.GetType()}: {exc.Message}\n\n";
                    }

                    context.Send(OnRemoteExecCompleted, new object[] { false, mes });
                    return;
                }

                if (exitCode != 0)
                {
                    context.Send(OnRemoteExecCompleted, new object[] { false, $"Удаленный процесс завершился с ошибкой: {exitCode}" });
                    return;
                }

                context.Send(OnRemoteExecCompleted, new object[] { true, "" });
            }



            /// <summary>
            /// ////////////// THREADING - события
            /// </summary>
            public void OnRemoteExecCompleted(object params_)
            {
                if (PARENT.IsDisposed) { return; };
                if (params_ is null) { return; };

                object[] paramsArray = (object[])params_;
                bool isSuccess = (bool)paramsArray[0];
                string errorText = (string)paramsArray[1];

                if (isSuccess)
                {
                    if (!PARENT.hideSuccessMessage) MessageBox.Show($"Обработка указанного экземпляра успешно выполнена",
                        "Обработка указанного экземпляра успешно выполнена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Не удалось выполнить удаленную обработку указанного экземпляра:\n\n{errorText}",
                        "Ошибка обработки указанного экземпляра", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                PARENT.DialogResult = isSuccess ? DialogResult.Yes : DialogResult.No;
            }
        }
    }
}