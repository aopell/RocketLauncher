using RocketLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
            settings = new List<string> { Settings.Default.Program1, Settings.Default.Program2, Settings.Default.Program3, Settings.Default.Program4, Settings.Default.Program5, Settings.Default.Program6, Settings.Default.Program7 };
            displayNames = new List<string> { Settings.Default.Display1, Settings.Default.Display2, Settings.Default.Display3, Settings.Default.Display4, Settings.Default.Display5, Settings.Default.Display6, Settings.Default.Display7 };
            slots = new List<bool>() { false, false, false, false, false, false, false };

            for (int i = 0; i < 7; i++)
            {
                if (settings[i] == "")
                {
                    slots[i] = false;
                }
                else
                {
                    slots[i] = true;
                }
            }

            for (int i = 0; i <  this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(Button))
                {
                    if (settings[i - 7] != "")
                    {
                        try
                        {
                            if (displayNames[i - 7] == "")
                            {
                                this.Controls[i].Text = settings[i - 7];
                            }
                            else
                            {
                                this.Controls[i].Text = displayNames[i - 7];
                            }
                        }
                        catch
                        {
                            this.Controls[i].Text = "Error";
                        }
                    }
                    else
                    {
                        this.Controls[i].Text = "<Add Program>";
                    }
                }
            }


            for (int i = 0; i < 7; i++)
            {
                PictureBox p = (PictureBox)this.Controls.Find("pictureBox" + (i + 1), false)[0];
                try
                {
                    p.Image = Icon.ExtractAssociatedIcon(settings[i]).ToBitmap();
                }
                catch
                {
                    p.Visible = false;
                }
            }
        }

        public static List<string> settings = new List<string> { Settings.Default.Program1, Settings.Default.Program2, Settings.Default.Program3, Settings.Default.Program4, Settings.Default.Program5, Settings.Default.Program6, Settings.Default.Program7 };
        public static List<string> displayNames = new List<string> { Settings.Default.Display1, Settings.Default.Display2, Settings.Default.Display3, Settings.Default.Display4, Settings.Default.Display5, Settings.Default.Display6, Settings.Default.Display7 };
        public static List<bool> slots = new List<bool>() { false, false, false, false, false, false, false };

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            ResetAll();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text != "<Add Program>")
            {
                Process.Start(settings[0]);
                this.Close();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text != "<Add Program>")
            {
                Process.Start(settings[1]);
                this.Close();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text != "<Add Program>")
            {
                Process.Start(settings[2]);
                this.Close();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text != "<Add Program>")
            {
                Process.Start(settings[3]);
                this.Close();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text != "<Add Program>")
            {
                Process.Start(settings[4]);
                this.Close();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != "<Add Program>")
            {
                Process.Start(settings[5]);
                this.Close();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "<Add Program>")
            {
                Process.Start(settings[6]);
                this.Close();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }

        private void addProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int j = 0;

            foreach (string s in settings)
            {
                if (s != "")
                {
                    j++;
                }
            }

            if (j != 7)
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("All slots taken");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Program1 = settings[0];
            Settings.Default.Program2 = settings[1];
            Settings.Default.Program3 = settings[2];
            Settings.Default.Program4 = settings[3];
            Settings.Default.Program5 = settings[4];
            Settings.Default.Program6 = settings[5];
            Settings.Default.Program7 = settings[6];
            Settings.Default.Display1 = displayNames[0];
            Settings.Default.Display2 = displayNames[1];
            Settings.Default.Display3 = displayNames[2];
            Settings.Default.Display4 = displayNames[3];
            Settings.Default.Display5 = displayNames[4];
            Settings.Default.Display6 = displayNames[5];
            Settings.Default.Display7 = displayNames[6];
            Settings.Default.Save();
        }

        private void removeProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }
    }
}
