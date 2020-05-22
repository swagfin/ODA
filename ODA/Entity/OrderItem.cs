using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODA.Entity
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemBarcode { get; set; }
        [Range(1, 9999999)]
        public int Quantity { get; set; } = 1;
        [Range(0, 999999999)]
        public double Rate { get; set; } = 0;

        [StringLength(10)]
        public string TaxCode { get; set; } = "A";
        [Range(0, 999999999)]
        public double Tax { get; set; } = 0;

        [Range(0, 999999999)]
        public double Discount { get; set; } = 0;
        [Range(0, 999999999)]
        public double TotalCost
        {
            get
            {
                double totalValue = this.Rate * this.Quantity;
                totalValue -= this.Discount;
                return totalValue;
            }

            set
            {

            }
        }

        [StringLength(50)]
        public string ItemStatus { get; set; } = "Completed";
        [StringLength(210)]
        public string ItemNote { get; set; }


        [StringLength(250)]
        public string TokenKey { get; set; } = Guid.NewGuid().ToString();
        public DateTime RegisteredDate { get; set; } = DateTime.Now;
        public int? OrderRestaurantId { get; set; }
        public double WaitTimeInMin { get; set; } = 1;
        public virtual Item Item { get; set; }
    }
}
