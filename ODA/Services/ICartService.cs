using ODA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Services
{
    public interface ICartService
    {
        Task AddItemAsync(Item item, int Quantity = 1);
        Task AddItemAsync(OrderItem item);
        Task EmptyShoppingCartAsync();
        Task<List<OrderItem>> GetShoppingListAsync();
        Task<double> GetSubTotal();
        Task<double> GetTotalDiscount();
        Task<double> GetTotalDueAsync();
        /// <summary>
        /// This Function tries to Make it Fast By getting the Quantity of Shopping Cart Count instead of Fetching Entire Cart then Getting the Quantity
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalItemsAsync();
        Task<double> GetTotalTaxAsync();
        /// <summary>
        /// Overrides Cart and Pushes new Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        Task PushShoppingCartAsync(List<OrderItem> cart);
        Task ReduceItemAsync(Item item);
        Task ReduceItemAsync(OrderItem item);
        Task RemoveItem(OrderItem item);
        Task RemoveItemByItemId(int itemId);
        Task<string> VerifyCanCheckoutMessage();
    }
}