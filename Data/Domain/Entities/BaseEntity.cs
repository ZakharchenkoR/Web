﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}
