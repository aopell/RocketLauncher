using RocketLauncher.Properties;
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
            this.labelProductName.Text = "Rocket Launcher - Seven Programs in the Space of One!";
            this.labelVersion.Text = String.Format("Version {0}", version);
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

        public static string version = "3.1";

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
            UpdateAvailable updateAvailable = new UpdateAvailable();
            updateAvailable.ShowDialog();
        }

        public static void BackupShortcutInformation()
        {
            System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RocketLauncherSettings.rktl", Form1.settings);
            System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RocketLauncherDisplayNames.rktl", Form1.displayNames);
        }

        public static void LoadShortcutInformation()
        {
            if (Settings.Default.FirstLaunch)
            {
                Settings.Default.FirstLaunch = false;
                Settings.Default.Save();
                try
                {
                    if (System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RocketLauncherSettings.rktl"))
                    {
                        Form1.settings = System.IO.File.ReadAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RocketLauncherSettings.rktl").ToList();
                        Form1.displayNames = System.IO.File.ReadAllLines(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RocketLauncherDisplayNames.rktl").ToList();
                        System.IO.File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RocketLauncherSettings.rktl");
                        System.IO.File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RocketLauncherDisplayNames.rktl");
                    }
                }
                catch
                {
                    MessageBox.Show("Error loading settings files. Your old shortcuts may or may not appear.");
                }
            }
        }
    }
}
