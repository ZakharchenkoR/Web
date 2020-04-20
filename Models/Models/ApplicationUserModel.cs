using System;

namespace Models.Models
{
    public class ApplicationUserModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
    }
}
