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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.SelectedItems.Contains(listBox1.Items[i]))
                {
                    Form1.settings.RemoveAt(i);
                    Form1.settings.Insert(i, "");
                    Form1.displayNames.RemoveAt(i);
                    Form1.displayNames.Insert(i, "");
                    Form1.icons.RemoveAt(i);
                    Form1.icons.Insert(i, "");
                }
            }

            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Location = new Point((this.Width - button1.Width) / 2, button1.Location.Y);

            this.CenterToScreen();

            int index = 0;

            foreach (string s in Form1.displayNames)
            {
                if (s != "")
                {
                    listBox1.Items.Add(s + " (" + Form1.settings[index] + ")");
                }
                else if (Form1.settings[index] != "")
                {
                    listBox1.Items.Add(Form1.settings[index]);
                }
                else
                {
                    listBox1.Items.Add("<none>");
                }

                index++;
            }
        }
    }
}
