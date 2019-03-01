using System;
using System.Collections.Generic;

namespace BO
{
    public class Excursion: AbstractIdentifiable
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int NbPlaces { get; set; }
        public virtual ICollection<PersonsExcursions> SubscribePeople { get; set; } = new List<PersonsExcursions>();

        public virtual Activity Activity { get; set; }

        public virtual Person Creator { get; set; }

        public virtual Weather Weather { get; set; }

    }
}
