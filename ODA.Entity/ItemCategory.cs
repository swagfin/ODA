using System;
using System.Collections.Generic;
using System.Text;

namespace ODA.Entity
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; } = "no_image.png";
        public double MinimumPrice { get; set; } = 1;
        public int WaitTimeInMin { get; set; } = 5;
    }
}
