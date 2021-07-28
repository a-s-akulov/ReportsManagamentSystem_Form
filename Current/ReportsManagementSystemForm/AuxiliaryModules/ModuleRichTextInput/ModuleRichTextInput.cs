using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportsManagementSystemForm
{
    public partial class ModuleRichTextInput : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        MyProgram PROG;

        public ModuleRichTextInput()
        {
            InitializeComponent();

            PROG = new MyProgram(this);
        }

        private void ModuleRichTextInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            PROG.FormClosing(e);
        }
    }
}
