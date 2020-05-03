﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
    public class Phone : BaseEntity
    {
        public decimal Price { get; set; }
        public int Count { get; set; }

        [Required]
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [Required]
        public Guid ModelId { get; set; }
        public Model Model { get; set; }
    }
}
