using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Serialovnik
{
    public partial class FormAdd : Form
    {
        FormMain formMain;

        public FormAdd(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            path.Text = dialog.SelectedPath;
            Match match = Regex.Match(path.Text, @"\\[^\\]+$");
            if (match.Value.Length > 1)
            {
                name.Text = match.Value.Substring(1);
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (name.Text.Length > 0 && path.Text.Length > 0)
            {
                formMain.addSerial(name.Text, path.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Zvolte název a cestu k seriálu");
            }
        }
    }
}