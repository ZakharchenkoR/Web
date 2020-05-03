﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Model : BaseEntity
    {
        [Required]
        public override string Name { get; set; }

        [Required]
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
