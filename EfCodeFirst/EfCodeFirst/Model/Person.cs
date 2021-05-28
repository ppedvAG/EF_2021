using System;

namespace EfCodeFirst.Model
{
    public class Person : Entity
    {

        public string Name { get; set; }

        public DateTime GebDatum { get; set; }

    }
}
