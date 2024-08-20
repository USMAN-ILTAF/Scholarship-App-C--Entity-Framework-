using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
           
        }
        ScholarshipDbContext context= new ScholarshipDbContext();

        StudentInfo student = new StudentInfo();
        
        private void UpdateForm_Load(object sender, EventArgs e)
        {
            UpdateInfo();

        }
        private void UpdateInfo()
        {
            var students = context.StudentInfo.ToList();
            dataGridView1.DataSource = students;
            NameTextBox.Text = "";
            RegTextBox.Text = "";
            PhoneTextBox.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];    
             student.Id = (int) selectedRow.Cells["ID"].Value;
            NameTextBox.Text = (string) selectedRow.Cells["Name"].Value;
            RegTextBox.Text= (string) selectedRow.Cells["RegNumber"].Value;
            PhoneTextBox.Text = (string) selectedRow.Cells["Phone"].Value;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            student = context.StudentInfo.Find(student?.Id);
            if (student != null )
            {
                student.Name = NameTextBox.Text;
                student.Phone = PhoneTextBox.Text;
                student.RegNumber = RegTextBox.Text;

                context.Update(student);
                context.SaveChanges();
                MessageBox.Show("Student Updated Successfully!!");
                UpdateInfo();
            }
            else
            {
                MessageBox.Show("Student not found. Update failed.");

            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            student = context.StudentInfo.Find(student?.Id);

            if (student != null)
            {
                student.Name = NameTextBox.Text;
                student.Phone = PhoneTextBox.Text;
                student.RegNumber = RegTextBox.Text;

                context.Remove(student);
                context.SaveChanges();
                MessageBox.Show("Student deleted Successfully!!");
                UpdateInfo();
            }
            else
            {
                MessageBox.Show("Select a Student!!");

            }

        }
    }
}
