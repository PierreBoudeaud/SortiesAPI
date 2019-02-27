using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    class ExcursionsActivities
    {
        public Guid ExcursionId { get; set; }
        public Excursion Excursion { get; set; }

        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
