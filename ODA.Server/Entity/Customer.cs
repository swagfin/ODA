using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Server.Entity
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string FirstName { get; set; }

        [StringLength(120)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string PrimaryMobile { get; set; }

        [StringLength(100)]
        public string PrimaryEmail { get; set; }
        public string Address { get; set; }
        public double PlacedOrders { get; set; } = 0;
        public double CancelledOrders { get; set; } = 0;
        public double CompletedOrders { get; set; } = 0;
        [StringLength(255)]
        public string TokenKey { get; set; } = Guid.NewGuid().ToString();
    }
}
