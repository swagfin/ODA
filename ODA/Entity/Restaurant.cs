using System;
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
        [StringLength(180)]
        public string MerchantId { get; set; }
        [Required]
        [StringLength(80)]
        public string ContactMobile { get; set; }
        [Required]
        [StringLength(95)]
        public string ContactEmail { get; set; }

        [StringLength(180)]
        public string Location { get; set; }
        [StringLength(240)]
        public string ImageFile { get; set; } = "no_image.png";

        public string MoreInfo { get; set; }
        [StringLength(80)]
        public string PriceEstimate { get; set; } = "$$";
        public double Rating { get; set; } = 0;
        public int OpeningHours { get; set; } = 0;
        public int ClosingHours { get; set; } = 0;

        public bool IsOpened
        {
            get
            {
                if (OpeningHours < 1 && ClosingHours < 1)
                    return true;
                DateTime currNow = new DateTime();
                //Set Opening Date
                DateTime opened = new DateTime(currNow.Year, currNow.Month, currNow.Day, OpeningHours, 0, 0);
                if (opened > currNow)
                    return false;
                //Set Closing Hour
                DateTime closed = new DateTime(currNow.Year, currNow.Month, currNow.Day, ClosingHours, 0, 0);
                if (currNow >= closed)
                    return false;
                return true;
            }
        }
        public virtual List<Item> Items { get; set; }
    }
}