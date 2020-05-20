using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ODA.Client.ViewModels
{
    public class MapPopularPlaceViewModel
    {
        [Key]
        public string Place { get; set; }
        public double PopularityRank { get; set; } = 0;
    }
}
