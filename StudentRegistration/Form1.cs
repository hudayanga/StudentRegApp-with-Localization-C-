using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

using System.Globalization;
using System.Threading;
using System.Resources;

namespace StudentRegistration
{
    public partial class Form1 : Form
    {
        CultureInfo culture;

        public Form1(CultureInfo local)
        {
            InitializeComponent();
            culture = local;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDBDataSet.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.studentDBDataSet.Department);
            // TODO: This line of code loads data into the 'studentDBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentDBDataSet.Student);


            DateTime dt = DateTime.Now;
            label7.Text = dt.ToLongDateString();

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            pictureBox1.DataBindings.Add("ImageLocation", studentBindingSource, "Pic");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            ResourceManager rm = new ResourceManager("StudentRegistration.Form1",System.Reflection.Assembly.GetExecutingAssembly());

            this.Text = rm.GetString("$this.Text");
            label1.Text = rm.GetString("label1.Text");
            label2.Text = rm.GetString("label2.Text");
            label3.Text = rm.GetString("label3.Text");
            label4.Text = rm.GetString("label4.Text");
            label5.Text = rm.GetString("label5.Text");
            label6.Text = rm.GetString("label6.Text");

            button2.Text = rm.GetString("button2.Text");
            button3.Text = rm.GetString("button3.Text");
            button4.Text = rm.GetString("button4.Text");
            button5.Text = rm.GetString("button5.Text");




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentTableAdapter.Insert(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), textBox4.Text, pictureBox1.ImageLocation, (int)comboBox1.SelectedValue);
            MessageBox.Show("Student Added!");
            this.studentTableAdapter.Fill(this.studentDBDataSet.Student);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentTableAdapter.Delete(textBox1.Text);
            MessageBox.Show("Student Deleted!");
            this.studentTableAdapter.Fill(this.studentDBDataSet.Student);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            studentTableAdapter.Update(textBox2.Text, int.Parse(textBox3.Text), textBox4.Text, pictureBox1.ImageLocation, (int)comboBox1.SelectedValue, textBox1.Text);
            MessageBox.Show("Student Updated!");
            this.studentTableAdapter.Fill(this.studentDBDataSet.Student);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection oldb=new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\3rd year\2nd semester\DCBSD\ex\StudentDB.mdb");
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = oldb;
//            cmd.CommandText = "SELECT        Department.DepartmentName, COUNT(Student.StudentID) AS no_of_student
//FROM            (Department LEFT OUTER JOIN
//                         Student ON Department.DepartmentID = Student.DeptId)
//GROUP BY Department.DepartmentName";
        }
    }
}
