using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODA.Data
{
    public interface ICartService
    {
        List<OrderItem> GetShoppingList();
        void AddItem(OrderItem item);
        void AddItem(Item item, int Quantity = 1);
        void RemoveItem(OrderItem item);
        void RemoveItemByItemId(int itemId);
        OrderItem GetCartItemByItemId(int? itemId);
        OrderItem GetCartItemByBarcode(string ItemBarcode);

        double GetSubTotal();
        double GetTotalDue();
        double GetTotalDiscount();
        double GetTotalTax();

        int GetTotalItems();
        bool VerifyCanCheckout();

        void EmptyShoppingCart();
    }
}
