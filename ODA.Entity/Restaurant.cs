using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODA.Entity
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string RegisteredName { get; set; }

        [Required]
        [StringLength(80)]
        public string ContactMobile { get; set; }
        [Required]
        [StringLength(95)]
        public string ContactEmail { get; set; }

        [StringLength(180)]
        public string Location { get; set; }

        [StringLength(50)]
        public string MoreInfo { get; set; }
        [StringLength(80)]
        public string PriceEstimate { get; set; } = "$$";
        public virtual List<Item> Items { get; set; }
    }
}