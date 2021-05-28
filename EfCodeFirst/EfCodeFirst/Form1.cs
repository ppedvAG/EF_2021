﻿using EfCodeFirst.Data;
using EfCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
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
            dataGridView1.AutoGenerateColumns = false;
            context.Database.EnsureCreated();
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
    }
}

