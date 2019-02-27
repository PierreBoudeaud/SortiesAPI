using System;

namespace BO
{
    public class PersonsExcursions
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public Guid ExcursionId { get; set; }
        public Excursion Excursion { get; set; }
    }
}
