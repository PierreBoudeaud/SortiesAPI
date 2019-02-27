using System;

namespace BO
{
    public abstract  class AbstractIdentifiable
    {
        public Guid Id { get; set; } = new Guid();
    }
}
