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
            if (listBox1.SelectedItems.Count != 0)
            {
                Form1.settings.RemoveAt(listBox1.SelectedIndex);
                Form1.settings.Insert(listBox1.SelectedIndex, "");
                Form1.displayNames.RemoveAt(listBox1.SelectedIndex);
                Form1.displayNames.Insert(listBox1.SelectedIndex, "");
                Application.Restart();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Location = new Point((this.Width - button1.Width) / 2, button1.Location.Y);

            this.CenterToScreen();

            foreach(string s in Form1.displayNames)
            {
                if (s != "")
                {
                    listBox1.Items.Add(s);
                }
                else
                {
                    listBox1.Items.Add("<none>");
                }
            }
        }
    }
}
