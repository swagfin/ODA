using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Entity
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(220)]
        public string FullName { get; set; }
        [StringLength(120)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string VerificationCode { get; set; } = new Random().Next(12013, 99999).ToString();
        public bool IsAccountConfirmed { get; set; } = false;
        [StringLength(180)]
        public string EmailAddress { get; set; }
        [StringLength(110), Required]
        public string UserAccountType { get; set; }
        public string Location { get; set; } = string.Empty;
        public double PlacedOrders { get; set; } = 0;
        public double CancelledOrders { get; set; } = 0;
        public double LoyaltyWalletBalance { get; set; } = 0;
        [StringLength(255)]
        public string TokenKey { get; set; } = Guid.NewGuid().ToString();
    }
}
