using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ReportsManagementSystemForm
{
    public partial class MainMenu : Form
    {
        public readonly MyProgram PROG;
        public readonly ModuleSQL SQL = new ModuleSQL();

        public MainMenu()
        {
            InitializeComponent();

            PROG = new MyProgram(this);
        }

        private void ReportsManagement_Button_Click(object sender, EventArgs e)
        {
            Hide();
            new ReportsManagement_main(this);
        }

        private void UsersManagement_Button_Click(object sender, EventArgs e)
        {
            Hide();
            new UsersManagement_main(this);
        }

        private void DirectoryManagement_Button_Click(object sender, EventArgs e)
        {
            Hide();
            new DirectoryManagement_main(this);
        }

        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) PROG.PermissionsLoad();
        }

        private void MainMenu_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            PROG.HelpButtonClicked();
            e.Cancel = true;
        }
    }
}