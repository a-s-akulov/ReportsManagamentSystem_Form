using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace ReportsManagementSystemForm
{
    public partial class ReportsManagement_instance_files_handler : WaitForm
    {
        public MyProgram PROG;
        private string mode;
        private object[] params_;
        private bool hideSuccessMessage;

        public ReportsManagement_instance_files_handler(string mode, object[] params_, bool hideSuccessMessage = false)
        {
            InitializeComponent();
            this.ProgressPanel.AutoHeight = true;

            PROG = new MyProgram(this);
            this.mode = mode;
            this.params_ = params_;
            this.hideSuccessMessage = hideSuccessMessage;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.ProgressPanel.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.ProgressPanel.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void ReportsManagement_instance_files_handler_Shown(object sender, EventArgs e)
        {
            if (mode == "UPLOAD") PROG.FilesUpload(params_);
            else if (mode == "DOWNLOAD") PROG.FilesDownload(params_);
        }
    }
}