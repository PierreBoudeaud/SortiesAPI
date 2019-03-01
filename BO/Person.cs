using System;
using System.Collections.Generic;

namespace BO
{
    public class Person: AbstractIdentifiable
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<PersonsExcursions> SubExcursions { get; set; } = new List<PersonsExcursions>();
    }
}
