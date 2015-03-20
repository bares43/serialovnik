using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Serialovnik
{
    public partial class FormSettings : Form
    {
        FormMain formMain;

        public FormSettings(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;

            XmlElement player = (XmlElement)formMain.rootXmlElement;
            XmlElement player2 = (XmlElement)player.GetElementsByTagName("player")[0];
            path.Text = player2.GetElementsByTagName("path")[0].InnerText;
            if (player2.GetElementsByTagName("params")[0].InnerText.Length > 0)
            {
                prms.Text = player2.GetElementsByTagName("params")[0].InnerText;
            }
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
                formMain.setPlayer(path.Text, prms.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Zvolte cestu k přehrávači a jeho parametry.");
            }
        }

    }
}