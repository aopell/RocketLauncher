using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            try
            {
                pictureBox1.Image = Icon.ExtractAssociatedIcon(textBox2.Text).ToBitmap();
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }
    }
}
