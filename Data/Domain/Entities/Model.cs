using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
    public class Model : BaseEntity
    {
        [Required]
        public override string Name { get; set; }

        [Required]
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
