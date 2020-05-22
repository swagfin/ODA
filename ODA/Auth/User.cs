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

    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Alias { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        public UserRole Role { get; set; } = UserRole.User;
        [Required]
        public string Password { get; set; }
        public DateTime DateLoggedIn { get; set; } = DateTime.Now;
    }
}