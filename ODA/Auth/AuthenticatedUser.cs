using System;
using System.ComponentModel.DataAnnotations;

namespace ODA.Auth
{
    public enum UserRole : int
    {
        Administrator = 2,
        Moderator = 1,
        User = 0
    }

    public class AuthenticatedUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Location { get; set; }
        public bool IsAccountConfirmed { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public DateTime DateLoggedIn { get; set; } = DateTime.Now;
        public string AuthKey { get; set; } = Guid.NewGuid().ToString();
    }
}