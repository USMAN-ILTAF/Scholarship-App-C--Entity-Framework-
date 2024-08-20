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

    public partial class Main : Form
    {
        StudentInfo student = new StudentInfo();
        ScholarshipDbContext context= new ScholarshipDbContext();

        void Clear()
        {
            NameTextBox.Text = string.Empty;
            RegTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
        }
        public Main()
        {
            InitializeComponent();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
           student.Name = NameTextBox.Text;
        }

        private void RegTextBox_TextChanged(object sender, EventArgs e)
        {
            student.RegNumber= RegTextBox.Text;
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            student.Phone = PhoneTextBox.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (student.Name == null || student.RegNumber == null || student.Phone == null)
            {
                MessageBox.Show("Complete all Fields");
            }
            else
            {
                context.Add(student);
                context.SaveChanges();
                Clear();
            }
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
           DisplayForm display= new DisplayForm();
            display.ShowDialog();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateForm updateForm=new UpdateForm();
            updateForm.ShowDialog();
        }
    }
}
