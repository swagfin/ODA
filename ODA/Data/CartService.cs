using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ODA.Data
{
    public class CartService : ICartService
    {

        private List<OrderItem> Cart;
        public CartService()
        {
            //Instantiate New
            if (GetShoppingList() == null)
                EmptyShoppingCart();
        }
        public List<OrderItem> GetShoppingList()
        {
            return Cart;
        }


        public void AddItem(OrderItem item)
        {
            var existItem = GetCartItemByItemId(item.ItemId);
            if (existItem != null && string.IsNullOrEmpty(item.ItemNote))
            {
                existItem.Quantity += item.Quantity;
                existItem.Rate = item.Rate;
                existItem.Tax = item.Tax * existItem.Quantity;
                existItem.TotalCost = item.Rate * existItem.Quantity;
            }
            else
                Cart.Add(item);
        }
        public void AddItem(Item item, int Quantity = 1)
        {
            if (Quantity < 1)
                return;
            //Proceeed
            OrderItem newItem = new OrderItem
            {
                ItemBarcode = item.ItemBarcode,
                ItemId = item.ItemId,
                Quantity = Quantity,
                Rate = item.SellingPrice,
                ItemName = item.ItemName,
                TotalCost = item.SellingPrice * Quantity
            };
            AddItem(newItem);
        }

        public void RemoveItem(OrderItem item)
        {
            Cart.Remove(item);
        }

        public double GetTotalDue()
        {
            return Cart.Sum(x => x.TotalCost);
        }
        public double GetSubTotal()
        {
            return GetTotalDue() - GetTotalTax();
        }

        public double GetTotalDiscount()
        {
            return Cart.Sum(x => x.Discount);
        }

        public double GetTotalTax()
        {
            return Cart.Sum(x => x.Tax);
        }

        public int GetTotalItems()
        {
            return Cart.Sum(x => x.Quantity);
        }

        public bool VerifyCanCheckout()
        {
            if (GetTotalItems() < 1)
                throw new Exception("No Items added In Shopping Cart");
            foreach (var item in GetShoppingList())
            {
                if (item.Quantity < 1)
                    throw new Exception($"Quantity of {item.ItemName} can not be less than 1");
                if (item.Rate < 0)
                    throw new Exception($"Rate of {item.ItemName} can not be less than 0");
            }
            //If All Tests passed
            return true;
        }

        public OrderItem GetCartItemByItemId(int? itemId)
        {
            return Cart.FirstOrDefault(x => x.ItemId == itemId);
        }

        public OrderItem GetCartItemByBarcode(string ItemBarcode)
        {
            return Cart.FirstOrDefault(x => x.ItemBarcode == ItemBarcode);
        }

        public void EmptyShoppingCart()
        {
            Cart = new List<OrderItem>();
        }

        public void RemoveItemByItemId(int itemId)
        {
            var itemFound = GetCartItemByItemId(itemId);
            if (itemFound != null)
                RemoveItem(itemFound);
        }


    }
}
