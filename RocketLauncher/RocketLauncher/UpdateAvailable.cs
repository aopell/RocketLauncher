using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketLauncher
{
    public partial class UpdateAvailable : Form
    {
        bool ShowUpToDate;

        public UpdateAvailable(bool showUpToDate = true)
        {
            ShowUpToDate = showUpToDate;
            InitializeComponent();
        }

        private void UpdateAvailable_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            try
            {
                WebClient wc = new WebClient();
                string webData = wc.DownloadString("https://raw.githubusercontent.com/aopell/RocketLauncher/master/NewestVersion");
                if (webData.Split('-')[0] == AboutBox1.version)
                {
                    if (ShowUpToDate)
                    {
                        MessageBox.Show("The program is up to date");
                    }
                    this.Close();
                }
                else
                {
                    this.Opacity = 100;
                    richTextBox1.Text = String.Format("An update to RocketLauncher is available:\r\n\r\nYour Version: {0}\r\nNew Version: {1}\r\n\r\n",AboutBox1.version,webData.Split('-')[0]);
                    string changelog = wc.DownloadString("https://raw.githubusercontent.com/aopell/RocketLauncher/master/Changelog");
                    richTextBox1.Text += changelog.Replace("\n","\r\n");
                    richTextBox1.DeselectAll();
                }
            }
            catch
            {
                if (ShowUpToDate)
                {
                    MessageBox.Show("An error has occurred. You may not be connected to the internet.");
                }
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string webData = wc.DownloadString("https://raw.githubusercontent.com/aopell/RocketLauncher/master/NewestVersion");

            string CurrentFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            wc.DownloadFile("https://github.com/aopell/SimpleUpdater/releases/download/v1.1/SimpleUpdater.exe", CurrentFolder + "/SimpleUpdater.exe");
            Process.Start(CurrentFolder + "/SimpleUpdater.exe", webData.Split('-')[1] + " " + System.Reflection.Assembly.GetExecutingAssembly().Location);
            AboutBox1.BackupShortcutInformation();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
