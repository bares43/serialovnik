using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Serialovnik.Settings;

namespace Serialovnik.Forms
{
    public partial class FormSettingsSerial : Form
    {
        private App App { get; }
        private Serial Serial { get; }

        public FormSettingsSerial(App app, string serialName)
        {
            InitializeComponent();

            App = app;
            Serial = App.Config.Serials.First(s => s.Name.Equals(serialName));
            name.Text = Serial.Name;
            path.Text = Serial.Path;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (name.Text.Length > 0)
            {
                Serial.Name = name.Text;
                App.SaveConfig();
                App.NotifySerialsListChanged();
                this.Close();
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            path.Text = dialog.SelectedPath;
            Serial.Path = path.Text;
            Serial.Last = null;
        }
    }
}
