using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODA.Entity
{
    public class Order
    {

        public int Id { get; set; }

        [StringLength(250)]
        public string OrderRef { get; set; }
        [StringLength(90)]
        public string TransactionType { get; set; } = "ORDER";
        public int? RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public int TotalItems { get; set; } = 0;

        public double SubTotal { get; set; } = 0;

        public double Tax { get; set; } = 0;

        public double TaxRate { get; set; } = 0;

        public double DeliveryCost { get; set; } = 0;

        public double Discount { get; set; } = 0;

        public double DueAmount { get; set; } = 0;

        public double PaidAmount { get; set; } = 0;
        public double ChangeAmount { get; set; } = 0;

        [StringLength(240)]
        public string PayMethod { get; set; }
        [StringLength(240)]
        public string PaymentTransactionRef { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        [StringLength(240)]
        public string BookedTable { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; } = "Completed";
        public DateTime? LastModified { get; set; }
        [StringLength(255)]
        public string TokenKey { get; set; } = Guid.NewGuid().ToString();
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        public virtual List<OrderItem> OrderItems { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Restaurant Restaurant { get; set; }

    }
}
