using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Serialovnik.Forms;
using Serialovnik.Settings;

namespace Serialovnik
{
    public class App
    {
        private string ConfigurationFileName { get; } = Directory.GetCurrentDirectory() + "\\Serialovnik.json";
        
        public Config Config { get; set; }

        public delegate void SerialsListChangedDelegate();

        public event SerialsListChangedDelegate SerialsListChanged;

        private void NotifySerialsListChanged()
        {
            SerialsListChanged?.Invoke();
        }

        public App()
        {
            InitConfig();
        }

        public void InitConfig()
        {
            if (File.Exists(ConfigurationFileName))
            {
                LoadConfig();
            }
            else
            {
                Config = new Config();
                SaveConfig();
            }
        }

        public void LoadConfig()
        {
            try
            {
                var json = File.ReadAllText(ConfigurationFileName);
                Config = JsonConvert.DeserializeObject<Config>(json);
            }
            catch (Exception)
            {
                MessageBox.Show("Nepodařilo se načíst konfigurační soubor.");
            }
        }

        public void SaveConfig()
        {
            try
            {
                var json = JsonConvert.SerializeObject(Config);
                File.WriteAllText(ConfigurationFileName, json);
            }
            catch (Exception)
            {
                MessageBox.Show("Konfigurační soubor se nepodařilo uložit.");
            }

        }

        public void ShowPopup(string message)
        {
            if (Config.ShowPlayPopup)
            {
                new FormPopup(message, Config.PlayPopupInterval).ShowDialog();
            }
        }

        public void AddSerial(string name, string path)
        {
            if (!Config.Serials.Any(s => s.Name.Equals(name) && s.Path.Equals(path)))
            {
                Config.Serials.Add(new Serial() { Name = name, Path = path });

                SaveConfig();
                NotifySerialsListChanged();
            }
        }

        public void RemoveSerial(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Config.Serials.RemoveAll(s => s.Name.Equals(name));
            }

            SaveConfig();
            NotifySerialsListChanged();
        }

        public void SetPlayer(string path, string arguments)
        {
            Config.Player = new Player() {Path = path, Arguments = arguments};
            SaveConfig();
        }

        public List<string> ScanFiles(string path)
        {
            var episodes = new List<string>();

            try
            {
                var files = Directory.GetFiles(path);
                Array.Sort(files, new NaturalSort());

                episodes = files.Where(f =>
                {
                    var extension = Path.GetExtension(f);
                    return extension != null && (extension.Equals(".mkv") ||
                                                 extension.Equals(".avi") ||
                                                 extension.Equals(".mp4") ||
                                                 extension.Equals(".mpg") ||
                                                 extension.Equals(".webm") ||
                                                 extension.Equals(".flv"));
                }).ToList();

                var directories = Directory.GetDirectories(path);
                Array.Sort(directories, new NaturalSort());
                foreach (var directory in directories)
                {
                    episodes.AddRange(ScanFiles(directory));
                }

                return episodes;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Nastala chyba při hledání souborů");
                throw exception;
            }

        }

        public void Play(string path)
        {
            if (Config.Player == null || string.IsNullOrEmpty(Config.Player.Path) ||
                string.IsNullOrEmpty(Config.Player.Arguments))
            {
                new FormSettings(this).Show();
            }
            else
            {
                var rgx = new Regex("{FILE}");
                var playParams = rgx.Replace(Config.Player.Arguments, "\"" + path + "\"");
                try
                {
                    Process.Start(Config.Player.Path, playParams);
                    ShowPopup(path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Soubor se nepodařilo přehrát.");
                }
            }
        }

        public void Continue(string name)
        {
            var serial = Config.Serials.First(s => s.Name.Equals(name));
            var episodes = ScanFiles(serial.Path);

            if (episodes.Count > 0)
            {
                string episodeToPlay = null;
                if (string.IsNullOrEmpty(serial.Last))
                {
                    episodeToPlay = episodes[0];
                }
                else
                {
                    var i = episodes.IndexOf(serial.Last);
                    if (i == episodes.Count - 1)
                    {
                        MessageBox.Show("Všechny epizody byly přehrány. Začnu od začátku.");
                        episodeToPlay = episodes[0];
                    }
                    else
                    {
                        episodeToPlay = episodes[i + 1];
                    }
                }

                if (!string.IsNullOrEmpty(episodeToPlay))
                {
                    serial.Last = episodeToPlay;
                    Play(episodeToPlay);
                    SaveConfig();
                }

            }
            else
            {
                MessageBox.Show("Žádné epizody k přehrání.");
            }
        }

        public void Previous(string name)
        {
            var serial = Config.Serials.First(s => s.Name.Equals(name));
            var episodes = ScanFiles(serial.Path);

            if (episodes.Count > 0)
            {
                string episodeToPlay = null;
                if (string.IsNullOrEmpty(serial.Last))
                {
                    episodeToPlay = episodes[0];
                }
                else
                {
                    var i = episodes.IndexOf(serial.Last);
                    if (i == 0)
                    {
                        MessageBox.Show("Všechny epizody byly přehrány. Začnu od začátku.");
                        episodeToPlay = episodes[0];
                    }
                    else
                    {
                        episodeToPlay = episodes[i - 1];
                    }
                }

                if (!string.IsNullOrEmpty(episodeToPlay))
                {
                    serial.Last = episodeToPlay;
                    Play(episodeToPlay);
                    SaveConfig();
                }

            }
            else
            {
                MessageBox.Show("Žádné epizody k přehrání.");
            }
        }

        public void Repeat(string name)
        {
            var serial = Config.Serials.First(s => s.Name.Equals(name));
            var episodes = ScanFiles(serial.Path);

            if (episodes.Count > 0)
            {
                string episodeToPlay = null;
                if (string.IsNullOrEmpty(serial.Last))
                {
                    episodeToPlay = episodes[0];
                }
                else
                {
                    var i = episodes.IndexOf(serial.Last);
                    episodeToPlay = episodes[i];
                }

                Play(episodeToPlay);

            }
            else
            {
                MessageBox.Show("Žádné epizody k přehrání.");
            }
        }

        public void Random(IEnumerable<string> serialNames)
        {
            var episodes = new List<string>();

            foreach(var name in serialNames)
            {
                episodes.AddRange(ScanFiles(Config.Serials.Where(s => s.Name.Equals(name)).Select(s => s.Path).First()));
            }

            var random = new Random();
            Play(episodes[random.Next(episodes.Count)]);
        }

        public void OpenSettings()
        {
            new FormSettings(this).Show();
        }

        public void OpenAddSerial()
        {
            new FormAdd(this).Show();
        }
    }
}
