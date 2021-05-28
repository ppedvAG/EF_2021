using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCodeFirst.Model
{
    public class Abteilung : Entity
    {


        [MaxLength(58)]
        [Required]
        [Column("DepName")]
        public string Bezeichnung { get; set; }

        public virtual ICollection<Mitarbeiter> Mitarbeiter { get; set; } = new HashSet<Mitarbeiter>();

    }

}
