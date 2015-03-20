using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Serialovnik
{
    public partial class FormPopup : Form
    {

        Timer t1;

        public FormPopup(string msg)
        {
            InitializeComponent();

            msgLBL.Text = msg;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ShowInTaskbar = false;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width  - this.Width, 0);

            this.Focus();
            this.Activate();
            this.TopMost = true;
            msgLBL.Text = msg;

            t1 = new Timer();
            t1.Tick += t1_Tick;
            t1.Interval = 5000; 
            t1.Start();
        }

        void t1_Tick(object sender, EventArgs e)
        {
            t1.Stop();
            this.Close();
        }

        private void FormPopup_Click(object sender, EventArgs e)
        {
            t1.Stop();
            this.Close();
        }
    }
}
