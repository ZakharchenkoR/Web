using System;
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

        [Required]

        public decimal Price { get; set; }

        [Required]

        public int Count { get; set; }
    }
}
