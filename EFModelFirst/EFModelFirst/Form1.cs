using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EFModelFirst
{
    public partial class Form1 : Form
    {
        Model1Container context = new Model1Container();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            context = new Model1Container(); // eine neue Unit-of-Work startet mit den Lade aller daten

            dataGridView1.DataSource = context.PersonSet.OfType<Mitarbeiter>()
                                                        .Include(x => x.Abteilung) //eager Loading
                                                        .Include(x => x.Kunde) //eager Loading
                                                        .Where(x => x.Gebdatum.Month > 6 && x.Name.StartsWith("F"))
                                                        .OrderBy(x => x.Gebdatum.Day)
                                                        .ThenByDescending(x => x.Gebdatum.Year)
                                                        .ToList();
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
                m.Gebdatum = DateTime.Now.AddYears(-40).AddDays(i * 17);

                if (i % 2 == 0)
                    m.Abteilung.Add(abt1);

                if (i % 3 == 0)
                    m.Abteilung.Add(abt2);

                context.PersonSet.Add(m);
            }
            context.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fred6 = context.PersonSet.OfType<Mitarbeiter>().FirstOrDefault(x => x.Id == 5);

            if (fred6 != null)
            {
                MessageBox.Show($"{fred6.Name} {fred6.Gebdatum:d} {string.Join(",", fred6.Abteilung.Select(x => x.Bezeichnung))}");

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is IEnumerable<Abteilung> abts)
            {
                e.Value = string.Join(" 🚕 ", abts.Select(x => x.Bezeichnung));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = context.PersonSet.Count(x => x.Gebdatum.Month == 6);
            MessageBox.Show($"{count} Personen");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem is Mitarbeiter m)
            {

                //  context.PersonSet.Remove(m); //== context.Entry(m).State = EntityState.Deleted;

                // context.Entry(m).State = EntityState.Added; //clone

                context.Entry(m).State = EntityState.Detached;
                m.Beruf = "rljnewkj";
                m.Gebdatum = new DateTime(2000, 8, 1);
                m.Name = "FFFFFFFF";
                context.Entry(m).State = EntityState.Modified;


                MessageBox.Show($"{m.Name} {context.Entry(m).State}");
            }
        }
    }
}
