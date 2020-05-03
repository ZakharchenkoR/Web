using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}
