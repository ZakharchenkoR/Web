using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class AppUser
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
    }
}
