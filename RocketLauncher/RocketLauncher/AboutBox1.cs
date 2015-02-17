using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketLauncher
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = "About Rocket Launcher";
            this.labelProductName.Text = "Rocket Launcher - 7 Programs in the Space of One!";
            this.labelVersion.Text = String.Format("Version 2.0");
            this.labelCopyright.Text = "Copyright © 2015 Aaron Opell";
            this.labelCompanyName.Text = "http://aopell.me";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        public static string version = "2.1";

        private void AboutBox1_Load(object sender, EventArgs e)
        {

        }

        private void labelCompanyName_Click(object sender, EventArgs e)
        {
            Process.Start("http://aopell.me");
        }

        private void labelCompanyName_MouseEnter(object sender, EventArgs e)
        {
            labelCompanyName.Font = new Font(labelCompanyName.Font.FontFamily, labelCompanyName.Font.Size, FontStyle.Underline);
        }

        private void labelCompanyName_MouseLeave(object sender, EventArgs e)
        {
            labelCompanyName.Font = new Font(labelCompanyName.Font.FontFamily, labelCompanyName.Font.Size, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                string webData = wc.DownloadString("https://raw.githubusercontent.com/aopell/RocketLauncher/master/NewestVersion");
                if (webData.Split('-')[0] == version)
                {
                    MessageBox.Show("The program is up to date");
                }
                else
                {
                    DialogResult dr = MessageBox.Show(String.Format("A newer version is available.\nYour version: {0}\nNewest Version: {1}\n\nWould you like to update now?", version, webData.Split('-')[0]),"An Update is Available",MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        string CurrentFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        wc.DownloadFile("https://github.com/aopell/SimpleUpdater/releases/download/v1.0/SimpleUpdater.exe", CurrentFolder + "/SimpleUpdater.exe");
                        Process.Start(CurrentFolder + "/SimpleUpdater.exe", webData.Split('-')[1] + " " + System.Reflection.Assembly.GetExecutingAssembly().Location);
                        Application.Exit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error has occurred. You may not be connected to the internet.");
            }
        }
    }
}
