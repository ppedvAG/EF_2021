using EfCodeFirst.Data;
using EfCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace EfCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            context.Database.EnsureCreated();

            var dt = DateTime.Now;

            dt.GetKW();
        }

        EfContext context = new EfContext();

        private void button1_Click(object sender, EventArgs e)
        {
            if (context.ChangeTracker.HasChanges())
            {
                var msg = $"Es sind nicht gespeicherte änderungen Vorhanden, sollen diese gespeichert werden?";
                var dlgRes = MessageBox.Show(msg, "Speichern?", MessageBoxButtons.YesNoCancel);

                if (dlgRes == DialogResult.Yes)
                    context.SaveChanges();
                else if (dlgRes == DialogResult.Cancel)
                    return;
            }
            context = new EfContext();

            LoadAllMitarbeiter();
        }

        private void LoadAllMitarbeiter()
        {

            dataGridView1.DataSource = context.Mitarbeiter
                                              .Include(x => x.Abteilungen)
                                              .Include(x => x.Kunden)
                                              .ToList();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Abteilung abt1 = new Abteilung() { Bezeichnung = "Steine" };
            Abteilung abt2 = new Abteilung() { Bezeichnung = "Holz" };

            for (int i = 0; i < 100; i++)
            {
                Mitarbeiter m = new Mitarbeiter();
                m.Name = $"Fred #{i:000}";
                m.Beruf = $"Macht dinge";
                m.GebDatum = DateTime.Now.AddYears(-40).AddDays(i * 17);

                if (i % 2 == 0)
                    m.Abteilungen.Add(abt1);

                if (i % 3 == 0)
                    m.Abteilungen.Add(abt2);

                context.Mitarbeiter.Add(m);
            }
            context.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Mitarbeiter m)
            {
                MessageBox.Show($"{m.Name} {string.Join(", ", m.Abteilungen.Select(x => x.Bezeichnung))}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Mitarbeiter m)
            {
                var abts = context.Abteilungen.Where(x => x.Mitarbeiter.Contains(m));

                MessageBox.Show($"{m.Name} {string.Join(", ", abts.Select(x => x.Bezeichnung))}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void SaveAll()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var msg = "Die Daten wurden zwischenzeitlich geändert. Welche Version soll nun verwendet werden.\n\n[JA] Meine Daten\n[NEIN] Datenbankversion erhalten";
                var dlgRes = MessageBox.Show(msg, "", MessageBoxButtons.YesNoCancel);

                if (dlgRes == DialogResult.Yes) //DB überscheiben
                {
                    foreach (var item in ex.Entries)
                    {
                        item.OriginalValues.SetValues(item.GetDatabaseValues());
                    }
                    SaveAll();
                }
                else if (dlgRes == DialogResult.No) //DB Daten laden
                {
                    foreach (var item in ex.Entries)
                    {
                        item.CurrentValues.SetValues(item.GetDatabaseValues());
                        item.OriginalValues.SetValues(item.CurrentValues);
                    }
                    LoadAllMitarbeiter();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var abt = context.Abteilungen.FirstOrDefault();
            abt.Bezeichnung += "#";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Mitarbeiter> zeug = new List<Mitarbeiter>();
            var queryO = from m in zeug //linq-to-objects
                         where m.AnzahlOhren < 100
                         orderby m.GebDatum
                         select m;


            var query = from m in context.Mitarbeiter.Include(x => x.Abteilungen) //linq-to-entity
                        where m.AnzahlOhren < 100
                        orderby m.GebDatum.Year, m.GebDatum.Month descending
                        select m;


            dataGridView1.DataSource = query.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var query = context.Mitarbeiter.Include(x => x.Abteilungen)
                                           .Where(m => m.AnzahlOhren < 100)
                                           .OrderBy(m => m.GebDatum.Year)
                                           .ThenByDescending(x => x.GebDatum.Month);

            dataGridView1.DataSource = query.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var result = context.Mitarbeiter.Sum(x => x.GebDatum.Month);

            MessageBox.Show(result.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var result = context.Mitarbeiter.OrderBy(x => x.GebDatum.Month == 5).FirstOrDefault(x => x.Name.StartsWith("F"));

            if (result != null)
                MessageBox.Show(result.Name.ToString());
            else
                MessageBox.Show("Nix gefunden");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var query = context.Mitarbeiter.ToList().GroupBy(x => x.GebDatum.Month);

            //Debug.WriteLine(query.ToQueryString());
            treeView1.Nodes.Clear();

            foreach (IGrouping<int, Mitarbeiter> item in query)
            {
                var monthNode = new TreeNode() { Text = $"Monat: { item.Key}" };
                foreach (var m in item)
                {
                    monthNode.Nodes.Add($"{m.Name} [{m.GebDatum:d}]");
                }
                treeView1.Nodes.Add(monthNode);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int elementeProSeite = 25;
            int aktiveSeite = 2;

            var result = context.Mitarbeiter.Skip(elementeProSeite * aktiveSeite).Take(elementeProSeite);

            dataGridView1.DataSource = result.ToList();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //var query = context.Mitarbeiter.Any(x => x.GebDatum.Month > 5);

            var anonym = new { Zahl = 12, Ding = 98.13 };


            //var query = context.Mitarbeiter.Select(x => new { Name = x.Name, Monat = x.GebDatum.Month, Gehalt = x.Gehalt });

            //var query = context.Mitarbeiter.Select(x => x.Abteilungen); //viele liste mit jeweils den Abteilungen des Mitarbeiters
            var query = context.Mitarbeiter.SelectMany(x => x.Abteilungen).Distinct(); //eine liste mit allen Abteilungen



            var f = new Form() { Width = 1000, Height = 800 };
            var dgv = new DataGridView() { DataSource = query.ToList(), Dock = DockStyle.Fill };
            f.Controls.Add(dgv);
            f.ShowDialog();

            //MessageBox.Show(string.Join(", ", query));


        }
    }
}


