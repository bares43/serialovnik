using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Security.Principal;
using Newtonsoft.Json;
using Serialovnik.Settings;

namespace Serialovnik.Forms
{
    public partial class FormMain : Form
    {
        public App App { get; set; }

        public FormMain(App app)
        {
            try
            {
                InitializeComponent();
                App = app;
                App.SerialsListChanged += LoadSerialsToBox;

                LoadSerialsToBox();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        public void LoadSerialsToBox()
        {
            serials.Items.Clear();

            foreach (var serial in App.Config.Serials)
            {
                serials.Items.Add(serial.Name);
            }
        }
        
        // Events
        private void add_Click(object sender, EventArgs e)
        {
            App.OpenAddSerial();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            App.OpenSettings();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            App.RemoveSerial(serials.SelectedItems.Cast<string>());
        }

        private void random_Click(object sender, EventArgs e)
        {
            App.Random(serials.SelectedItems.Cast<string>());
        }

        private void goon_Click(object sender, EventArgs e)
        {
            App.Continue(serials.SelectedItem.ToString());
        }

        private void serials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serials.SelectedItems.Count > 1)
            {
                random.Enabled = true;
                goOn.Enabled = false;
                previous.Enabled = false;
                repeat.Enabled = false;
                settingsSerial.Enabled = false;
            }
            else if (serials.SelectedItems.Count == 1)
            {
                random.Enabled = true;
                goOn.Enabled = true;
                previous.Enabled = true;
                repeat.Enabled = true;
                settingsSerial.Enabled = true;
            }
            else
            {
                random.Enabled = false;
                goOn.Enabled = false;
                previous.Enabled = false;
                repeat.Enabled = false;
                settingsSerial.Enabled = false;
            }
        }

        private void repeat_Click(object sender, EventArgs e)
        {
            App.Repeat(serials.SelectedItem.ToString());
        }

        private void serials_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = serials.IndexFromPoint(e.Location);
            if (index >= 0 && index < serials.Items.Count)
            {
                App.Continue(serials.Items[index].ToString());
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            App.OpenAbout();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            App.Previous(serials.SelectedItem.ToString());
        }

        private void settingsSerial_Click(object sender, EventArgs e)
        {
            App.OpenSettingsSerial(serials.SelectedItem.ToString());
        }
    }
}