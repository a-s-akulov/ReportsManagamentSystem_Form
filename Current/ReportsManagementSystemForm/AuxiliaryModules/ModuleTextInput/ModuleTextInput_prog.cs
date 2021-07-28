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

    public partial class ModuleTextInput
    {

        public class MyProgram
        {
            public readonly ModuleTextInput PARENT;


            public MyProgram(ModuleTextInput parent, int maxResultLength, string startValue)
            {
                PARENT = parent;

                ControlsInit(maxResultLength, startValue);
            }

            public void ControlsInit(int maxResultLength, string startValue)
            {
                PARENT.Text_RichTextBox.Text = startValue;
                PARENT.Text_RichTextBox.MaxLength = maxResultLength;
            }


            public void ChangesAccept()
            {
                DialogResult resultDialog = MessageBox.Show($"Применить внесенные изменения?",
                        "Применить изменения?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDialog != DialogResult.Yes) return;

                PARENT.resultString = PARENT.Text_RichTextBox.Text;
                PARENT.DialogResult = DialogResult.OK;
                PARENT.Close();
            }
        }
    }
}