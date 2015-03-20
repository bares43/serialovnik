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

namespace Serialovnik
{
    public partial class FormMain : Form
    {

        XmlDocument xml = new XmlDocument();
        public XmlNode rootXmlElement;
        String configurationFile = Directory.GetCurrentDirectory() + "\\Serialovnik.xml";
        List<String> episodes = new List<String>();

        public FormMain()
        {
            InitializeComponent();
            initConfig();
            readSerials();
        }

        private void showPopup(string  msg)
        {
            FormPopup f = new FormPopup(msg);
            f.ShowDialog();
        }

        public void initConfig()
        {
            try
            {
                xml.Load(configurationFile);
            }
            catch (Exception)
            {
                createConfig();
            }

            xml.Load(configurationFile);
            rootXmlElement = xml.DocumentElement;
        }

        private void createConfig()
        {
            XmlDeclaration deklarace = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            xml.AppendChild(deklarace);
            XmlElement rootXML = xml.CreateElement("serialovnik");
            XmlElement playerXML = xml.CreateElement("player");
            playerXML.AppendChild(xml.CreateElement("path"));
            playerXML.AppendChild(xml.CreateElement("params"));
            rootXML.AppendChild(playerXML);
            rootXML.AppendChild(xml.CreateElement("serials"));
            xml.AppendChild(rootXML);
            xml.Save(configurationFile);
        }


        public void readSerials()
        {
            serials.Items.Clear();
            XmlElement srls = (XmlElement)rootXmlElement;
            XmlElement player2 = (XmlElement)srls.GetElementsByTagName("serials")[0];
            foreach (XmlNode serial in player2.ChildNodes)
            {
                XmlElement serialE = (XmlElement)serial;
                serials.Items.Add(serialE.GetElementsByTagName("name")[0].InnerText);
            }
        }

        public void addSerial(String name, String path)
        {
            XmlElement srls = (XmlElement)rootXmlElement;
            XmlElement player2 = (XmlElement)srls.GetElementsByTagName("serials")[0];
            bool can = true;
            foreach (XmlNode serial in player2.ChildNodes)
            {
                XmlElement serialE = (XmlElement)serial;
                if (serialE.GetElementsByTagName("path")[0].InnerText == path || serialE.GetElementsByTagName("name")[0].InnerText == name)
                {
                    can = false;
                    break;
                }
            }

            if (can)
            {
                XmlElement serial = xml.CreateElement("serial");

                XmlElement nameXML = xml.CreateElement("name");
                nameXML.InnerText = name;
                serial.AppendChild(nameXML);

                XmlElement pathXML = xml.CreateElement("path");
                pathXML.InnerText = path;
                serial.AppendChild(pathXML);

                XmlElement lastXML = xml.CreateElement("last");
                lastXML.InnerText = "";
                serial.AppendChild(lastXML);

                player2.AppendChild(serial);
                xml.Save(configurationFile);
                readSerials();
            }
        }

        public void setPlayer(String path, String prms)
        {
            XmlElement player = (XmlElement)rootXmlElement;
            XmlElement player2 = (XmlElement)player.GetElementsByTagName("player")[0];
            player2.GetElementsByTagName("path")[0].InnerText = path;
            player2.GetElementsByTagName("params")[0].InnerText = prms;
            xml.Save(configurationFile);
        }

        private void play(string path)
        {
            XmlElement player = (XmlElement)rootXmlElement;
            XmlElement player2 = (XmlElement)player.GetElementsByTagName("player")[0];
            String playerPath = player2.GetElementsByTagName("path")[0].InnerText;
            String playParams = player2.GetElementsByTagName("params")[0].InnerText;

            if (playerPath.Length == 0 || playParams.Length == 0)
            {
                FormSettings f = new FormSettings(this);
                f.Show();
            }
            else
            {
                Regex rgx = new Regex("{FILE}");
                playParams = rgx.Replace(playParams, "\"" + path + "\"");
                try
                {
                    Process.Start(playerPath, playParams);
                    showPopup(path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Soubor se nepodařilo přehrát.");
                }
            }
        }

        private void ScanFiles(string path)
        {
            try
            {
                string[] files;
                string[] directories;
                files = Directory.GetFiles(path);
                Array.Sort(files, new NaturalSort());
                foreach (string file in files)
                {
                    Match match = Regex.Match(file, "(mkv)|(avi)|(mp4)|(mpg)|(webm)|(flv)$", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        episodes.Add(file);
                    }
                }

                directories = Directory.GetDirectories(path);
                Array.Sort(directories, new NaturalSort());
                foreach (string directory in directories)
                {
                    ScanFiles(directory);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Chyba, soubor se nepodařilo spustit");
            }
        }

        private void _goon(string name)
        {
            string item = name;
            string last = "";
            XmlElement srls = (XmlElement)rootXmlElement;
            XmlElement player2 = (XmlElement)srls.GetElementsByTagName("serials")[0];
            XmlElement serialE = (XmlElement)player2.ChildNodes[0];

            foreach (XmlNode serial in player2.ChildNodes)
            {
                serialE = (XmlElement)serial;

                if (serialE.GetElementsByTagName("name")[0].InnerText == item)
                {
                    last = serialE.GetElementsByTagName("last")[0].InnerText;
                    ScanFiles(serialE.GetElementsByTagName("path")[0].InnerText);
                    break;
                }
            }

            if (episodes.Count > 0)
            {
                if (last.Length == 0)
                {
                    serialE.GetElementsByTagName("last")[0].InnerText = (string)episodes[0];
                    play((string)episodes[0]);
                }
                else
                {
                    int i = episodes.IndexOf(last);
                    if (i == episodes.Count - 1)
                    {
                        MessageBox.Show("Všechny epizody byly přehrány. Začnu od začátku.");
                        serialE.GetElementsByTagName("last")[0].InnerText = (string)episodes[0];
                        play((string)episodes[0]);
                    }
                    else
                    {
                        serialE.GetElementsByTagName("last")[0].InnerText = (string)episodes[i + 1];
                        play((string)episodes[i + 1]);
                    }
                }
                xml.Save(configurationFile);
            }
            else
            {
                MessageBox.Show("Žádné epizody k přehrání.");
            }
            episodes.Clear();
        }
        
        // Buttons
        private void add_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd(this);
            formAdd.Show();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(this);
            formSettings.Show();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            foreach (string item in serials.SelectedItems)
            {
                XmlElement srls = (XmlElement)rootXmlElement;
                XmlElement player2 = (XmlElement)srls.GetElementsByTagName("serials")[0];

                foreach (XmlNode serial in player2.ChildNodes)
                {
                    XmlElement serialE = (XmlElement)serial;

                    if (serialE.GetElementsByTagName("name")[0].InnerText == item)
                    {
                        player2.RemoveChild(serialE);
                    }
                }
            }
            xml.Save(configurationFile);
            readSerials();
        }

        private void random_Click(object sender, EventArgs e)
        {
            foreach (string item in serials.SelectedItems)
            {
                XmlElement srls = (XmlElement)rootXmlElement;
                XmlElement player2 = (XmlElement)srls.GetElementsByTagName("serials")[0];

                foreach (XmlNode serial in player2.ChildNodes)
                {
                    XmlElement serialE = (XmlElement)serial;

                    if (serialE.GetElementsByTagName("name")[0].InnerText == item)
                    {
                        ScanFiles(serialE.GetElementsByTagName("path")[0].InnerText);
                    }
                }
            }

            if (episodes.Count > 0)
            {
                Random rnd = new Random();
                string s = episodes[rnd.Next(episodes.Count)];
                play(s);
            }
            else
            {
                MessageBox.Show("Žádné epizody k přehrání");
            }
            episodes.Clear();
        }

        private void goon_Click(object sender, EventArgs e)
        {
            string item = (string)serials.SelectedItem;
            _goon(item);
        }

        private void serials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serials.SelectedItems.Count > 1)
            {
                random.Enabled = true;
                goOn.Enabled = false;
                repeat.Enabled = false;
            }
            else if (serials.SelectedItems.Count == 1)
            {
                random.Enabled = true;
                goOn.Enabled = true;
                repeat.Enabled = true;
            }
            else
            {
                random.Enabled = false;
                goOn.Enabled = false;
                repeat.Enabled = false;
            }
        }

        private void repeat_Click(object sender, EventArgs e)
        {
            string item = (string)serials.SelectedItem;
            string last = "";
            XmlElement srls = (XmlElement)rootXmlElement;
            XmlElement player2 = (XmlElement)srls.GetElementsByTagName("serials")[0];
            XmlElement serialE = (XmlElement)player2.ChildNodes[0];

            foreach (XmlNode serial in player2.ChildNodes)
            {
                serialE = (XmlElement)serial;

                if (serialE.GetElementsByTagName("name")[0].InnerText == item)
                {
                    last = serialE.GetElementsByTagName("last")[0].InnerText;
                    ScanFiles(serialE.GetElementsByTagName("path")[0].InnerText);
                    break;
                }
            }

            if (episodes.Count > 0)
            {
                if (last.Length == 0)
                {
                    play((string)episodes[0]);
                }
                else
                {
                    int i = episodes.IndexOf(last);
                    play((string)episodes[i]);
                }
            }
            else
            {
                MessageBox.Show("Žádné epizody k přehrání.");
            }
            episodes.Clear();
        }

        private void serials_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = serials.IndexFromPoint(e.Location);
            if (index >= 0 && index < serials.Items.Count)
            {
                string name = serials.Items[index].ToString();
                _goon(name);
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
        //    MessageBox.Show("Seriálovník\n\n27.6.2014\nJan Bareš\njanbares43@gmail.com");
        }
    }
}
