﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NORTHWNDEntities context = new NORTHWNDEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = context.Ten_Most_Expensive_Products();
            dataGridView1.DataSource = result;
        }
    }
}
