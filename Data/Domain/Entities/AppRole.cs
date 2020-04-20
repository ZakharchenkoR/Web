using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class AppRole
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public IReadOnlyCollection<AppUser> Users { get; }
    }
}
