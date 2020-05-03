using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}
