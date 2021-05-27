namespace EfCodeFirst.Model
{
    public class Kunde : Person
    {
        public string Kundennummer { get; set; }

        public Mitarbeiter Mitarbeiter { get; set; }
    }

}
