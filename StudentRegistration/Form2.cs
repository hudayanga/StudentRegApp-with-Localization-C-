using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

namespace StudentRegistration
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Form1 fm = new Form1(new CultureInfo("en-US"));
                fm.ShowDialog();
            }
          
            if (comboBox1.SelectedIndex == 1)
            {
                Form1 fm = new Form1(new CultureInfo("si-LK"));
                fm.ShowDialog();
            }
        }
    }
}
