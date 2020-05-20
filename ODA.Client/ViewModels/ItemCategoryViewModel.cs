using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ODA.Client.ViewModels
{
    public class ItemCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFile { get; set; } = "no_image.png";
        public double MinimumPrice { get; set; } = 1;
        public int WaitTimeInMin { get; set; } = 5;
    }
}
