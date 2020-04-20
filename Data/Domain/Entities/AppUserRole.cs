using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class AppUserRole
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set;}
        public AppUser AppUser { get; set; }

        [Required]
        public Guid RoleId { get; set; }
        public AppRole AppRole { get; set; }

        public IReadOnlyList<AppRole> Roles { get; set; }
        public IReadOnlyList<AppUser> Users { get; set; }


    }
}
