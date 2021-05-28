using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifier { get; set; }

        public byte[] RowVersion { get; set; }

    }
}
