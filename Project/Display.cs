using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class DisplayForm : Form
    {
        ScholarshipDbContext context = new ScholarshipDbContext();

        public DisplayForm()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            var students = context.StudentInfo.ToList();
            dataGridView1.DataSource= students;
        }
        private void Display_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
