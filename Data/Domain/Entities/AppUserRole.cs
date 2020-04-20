using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    class AppUserRole
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set;}
        public AppUser AppUser { get; set; }

        [Required]
        public Guid RoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
