using System;
using System.ComponentModel.DataAnnotations;

namespace ODA.Auth
{
    public class AuthenticatedUser
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Location { get; set; } = string.Empty;
        public bool IsAccountConfirmed { get; set; }
        public string Role { get; set; } = string.Empty;
        public DateTime DateLoggedIn { get; set; } = DateTime.Now;
        public string AuthKey { get; set; } = Guid.NewGuid().ToString();
    }
}