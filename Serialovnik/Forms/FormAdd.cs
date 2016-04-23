using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Serialovnik.Forms
{
    public partial class FormAdd : Form
    {
        FormMain formMain;
        private App App { get; }

        public FormAdd(App app)
        {
            InitializeComponent();
            App = app;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            path.Text = dialog.SelectedPath;
            var match = Regex.Match(path.Text, @"\\[^\\]+$");
            if (match.Value.Length > 1)
            {
                name.Text = match.Value.Substring(1);
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (name.Text.Length > 0 && path.Text.Length > 0)
            {
                App.AddSerial(name.Text, path.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Zvolte název a cestu k seriálu");
            }
        }
    }
}