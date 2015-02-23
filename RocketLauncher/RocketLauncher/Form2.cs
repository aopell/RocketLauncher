using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketLauncher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int replaceval = pickButtonSlot();

                Form1.settings.RemoveAt(replaceval);
                Form1.displayNames.RemoveAt(replaceval);
                Form1.settings.Insert(replaceval, textBox2.Text);
                Form1.displayNames.Insert(replaceval, textBox1.Text);
                Form1.icons.RemoveAt(replaceval);
                Form1.icons.Insert(replaceval, openFileDialog2.FileName);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error! Path must not be blank!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;
        }

        public int pickButtonSlot()
        {
            for (int i = 0; i < 7; i++)
            {
                if(Form1.settings[i] == "")
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
            if(textBox2.Text != "" && !textBox3.Text.EndsWith(".ico"))
            {
                textBox3.Text = "Using Icon to Left";
            }
            else if (!textBox3.Text.EndsWith(".ico"))
            {
                textBox3.Text = "Select a Shortcut Path";
            }
            if (!textBox3.Text.EndsWith(".ico"))
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
            openFileDialog2.ShowDialog();
            if (openFileDialog2.FileName.EndsWith(".ico"))
            {
                textBox3.Text = openFileDialog2.SafeFileName;
                pictureBox1.Image = Icon.ExtractAssociatedIcon(openFileDialog2.FileName).ToBitmap();
            }
            else
            {
                MessageBox.Show("Please choose a file with the .ico file type");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Info inf = new Info();
            inf.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
