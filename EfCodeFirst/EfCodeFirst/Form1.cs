using EfCodeFirst.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EfCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EfContext context = new EfContext();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Mitarbeiter.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = Properties.Settings.Default.WinPos.X;
            this.Top = Properties.Settings.Default.WinPos.Y;
            this.Width = Properties.Settings.Default.WinSize.Width;
            this.Height = Properties.Settings.Default.WinSize.Height;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.WinPos = new System.Drawing.Point(this.Left, this.Top);
            Properties.Settings.Default.WinSize = new System.Drawing.Size(this.Width, this.Height);
            Properties.Settings.Default.Save();
        }
    }
}

