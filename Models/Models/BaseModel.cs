using System;

namespace Models.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual bool IsNew => Id == Guid.Empty;
    }
}
