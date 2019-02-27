using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Excursion: AbstractIdentifiable
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int NbPlaces { get; set; }

        public ICollection<PersonsExcursions> SubscribePeople { get; set; } = new List<PersonsExcursions>();

        public Activity Activity { get; set; }

        public Person Creator { get; set; }

        public Weather Weather { get; set; }

    }
}
