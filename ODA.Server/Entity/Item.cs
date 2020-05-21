using System;
using System.ComponentModel.DataAnnotations;

namespace ODA.Server.Entity
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required]
        [StringLength(150)]
        public string ItemBarcode { get; set; } = new Random().Next(10011, 999999).ToString();

        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }

        [StringLength(225)]
        public string Category { get; set; }

        [StringLength(255)]
        public string MoreInfo { get; set; }
        public Double WaitTimeInMin { get; set; } = 5;
        [Range(0, 999999999)]
        public int OrderedQuantity { get; set; } = 0;
        [Range(0, 999999999)]
        public double SellingPrice { get; set; } = 0;
        public string ImageFile { get; set; } = "no_image.png";
        public bool IsActive { get; set; } = true;
        public int? RestaurantId { get; set; }
        public bool IsFeaturd { get; set; } = false;
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public virtual Restaurant Restaurant { get; set; }
    }
}
