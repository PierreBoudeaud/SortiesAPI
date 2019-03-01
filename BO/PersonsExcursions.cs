using System;
using Newtonsoft.Json;

namespace BO
{
    public class PersonsExcursions
    {
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        public Guid ExcursionId { get; set; }

        [JsonIgnore]
        public virtual Excursion Excursion { get; set; }
    }
}
