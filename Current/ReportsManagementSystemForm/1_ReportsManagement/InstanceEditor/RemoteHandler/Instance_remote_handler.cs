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
    public partial class ReportsManagement_instance_remote_handler : WaitForm
    {
        public MyProgram PROG;
        private object[] params_;
        private bool hideSuccessMessage;

        public ReportsManagement_instance_remote_handler(object[] params_, bool hideSuccessMessage = false)
        {
            InitializeComponent();
            this.ProgressPanel.AutoHeight = true;

            PROG = new MyProgram(this);
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

        private void ReportsManagement_instance_remote_handler_Shown(object sender, EventArgs e)
        {
            PROG.InstanceRemoteHandlerExec(params_);
        }
    }
}