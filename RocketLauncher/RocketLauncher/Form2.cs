using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketLauncher
{
    public partial class Form2 : Form
    {
        int selectedButtonIndex;

        public Form2(int buttonIndex)
        {
            selectedButtonIndex = buttonIndex;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedButtonIndex == -1)
            {
                selectedButtonIndex = pickButtonSlot();
            }

            if(textBox2.Text == "")
            {
                MessageBox.Show("Path must not be blank");
                return;
            }

            if ((textBox2.Text.StartsWith("http://") || textBox2.Text.StartsWith("https://")) && openFileDialog2.FileName == "Select a File")
            {
                openFileDialog2.FileName = textBox2.Text;
            }

            Form1.settings.RemoveAt(selectedButtonIndex);
            Form1.displayNames.RemoveAt(selectedButtonIndex);
            Form1.settings.Insert(selectedButtonIndex, textBox2.Text);
            Form1.displayNames.Insert(selectedButtonIndex, textBox1.Text);
            Form1.icons.RemoveAt(selectedButtonIndex);
            Form1.icons.Insert(selectedButtonIndex, textBox3.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;
            textBox3.Text = textBox2.Text;
        }

        public int pickButtonSlot()
        {
            for (int i = 0; i < 7; i++)
            {
                if (Form1.settings[i] == "")
                {
                    return i;
                }
            }
            return 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && openFileDialog2.FileName == "Select a File")
            {
                textBox3.Text = textBox2.Text;
            }
            else if (openFileDialog2.FileName == "Select a File")
            {
                textBox3.Text = "Select a Shortcut Path";
            }
            if (openFileDialog2.FileName == "Select a File")
            {
                try
                {
                    pictureBox1.Image = Icon.ExtractAssociatedIcon(textBox2.Text).ToBitmap();
                }
                catch
                {
                    if (textBox2.Text.StartsWith("http://") || textBox2.Text.StartsWith("https://"))
                    {
                        try
                        {
                            string[] temp = new string[] { "//" };
                            Uri u = new Uri(textBox2.Text);
                            pictureBox1.ImageLocation = u.GetLeftPart(UriPartial.Authority) + "/favicon.ico";
                            pictureBox1.LoadAsync();
                        }
                        catch
                        {
                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog2.ShowDialog();
            textBox3.Text = openFileDialog2.SafeFileName;
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Icon.ExtractAssociatedIcon(openFileDialog2.FileName).ToBitmap();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Info inf = new Info();
            inf.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "Select a File";

            try
            {
                pictureBox1.Image = Icon.ExtractAssociatedIcon(textBox2.Text).ToBitmap();
                textBox3.Text = textBox2.Text;
            }
            catch
            {
                if (textBox2.Text.StartsWith("http://") || textBox2.Text.StartsWith("https://"))
                {
                    try
                    {
                        string[] temp = new string[] { "//" };
                        Uri u = new Uri(textBox2.Text);
                        pictureBox1.ImageLocation = u.GetLeftPart(UriPartial.Authority) + "/favicon.ico";
                        pictureBox1.LoadAsync();
                        openFileDialog2.FileName = textBox2.Text;
                        textBox3.Text = textBox2.Text;
                    }
                    catch
                    {
                        pictureBox1.Image = null;
                        textBox3.Text = "Select a Shortcut Path";
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                    textBox3.Text = "Select a Shortcut Path";
                }
            }
        }
    }
}
