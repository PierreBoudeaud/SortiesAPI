using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Activity: AbstractIdentifiable
    {
        public string Name { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public ICollection<Excursion> Excursions { get; set; } = new List<Excursion>();
    }
}
