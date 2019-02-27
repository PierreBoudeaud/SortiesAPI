using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public abstract  class AbstractIdentifiable
    {
        public Guid Id { get; set; } = new Guid();
    }
}
