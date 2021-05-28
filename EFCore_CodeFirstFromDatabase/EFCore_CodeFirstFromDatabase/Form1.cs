using EFCore_CodeFirstFromDatabase.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EFCore_CodeFirstFromDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NORTHWNDContext context = new NORTHWNDContext();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}
