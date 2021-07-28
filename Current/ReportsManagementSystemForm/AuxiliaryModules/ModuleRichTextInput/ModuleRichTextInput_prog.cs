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

    public partial class ModuleRichTextInput
    {

        public class MyProgram
        {
            public readonly ModuleRichTextInput PARENT;


            public MyProgram(ModuleRichTextInput parent)
            {
                PARENT = parent;

                ControlsInit();
            }


            public void ControlsInit()
            {
                PARENT.Text_RibbonControl.SelectedPage = PARENT.homeRibbonPage1;
            }


            public void FormClosing(FormClosingEventArgs e)
            {
                DialogResult resultDialog = MessageBox.Show($"Применить внесенные изменения?",
                        "Выход из редактора", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                
                if (resultDialog == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                PARENT.DialogResult = resultDialog;
            }
        }
    }
}