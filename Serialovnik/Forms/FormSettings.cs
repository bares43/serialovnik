using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Serialovnik.Forms
{
    public partial class FormSettings : Form
    {
        private App App { get; }

        public FormSettings(App app)
        {
            InitializeComponent();
            this.App = app;

            if (App.Config.Player != null)
            {
                path.Text = App.Config.Player.Path;
                prms.Text = App.Config.Player.Arguments;
            }

            showPlayPopup.Checked = App.Config.ShowPlayPopup;
            timeout.Text = App.Config.PlayPopupInterval.ToString();

        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Spustitelné soubory (.exe)|*.exe";
            dialog.ShowDialog();
            if (dialog.FileName.Length > 0)
            {
                path.Text = dialog.FileName;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (path.Text.Length > 0 && prms.Text.Length > 0)
            {
                App.SetPlayer(path.Text, prms.Text);
            }

            App.Config.ShowPlayPopup = showPlayPopup.Checked;
            App.Config.PlayPopupInterval = int.Parse(timeout.Text);

            App.SaveConfig();

            this.Close();
        }
    }
}