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

        public ReportsManagement_instance_files_handler()
        {
            InitializeComponent();
            this.ProgressPanel.AutoHeight = true;

            PROG = new MyProgram(this);
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
    }
}