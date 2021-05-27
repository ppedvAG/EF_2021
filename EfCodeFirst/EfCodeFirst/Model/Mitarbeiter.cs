using System.Collections.Generic;

namespace EfCodeFirst.Model
{
    public class Mitarbeiter : Person
    {
        public string Beruf { get; set; }

        public string Gehalt { get; set; }

        public decimal GehaltAlsDec { get; set; }

        public string Sitzplatz { get; set; }

        public bool HomeOffice { get; set; }

        public virtual ICollection<Kunde> Kunden { get; set; } = new HashSet<Kunde>();

        public virtual ICollection<Abteilung> Abteilungen { get; set; } = new HashSet<Abteilung>();


    }

}
