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
        Task<int> GetTotalItemsAsync();
        Task<double> GetTotalTaxAsync();
        Task ReduceItemAsync(Item item);
        Task ReduceItemAsync(OrderItem item);
        Task RemoveItem(OrderItem item);
        Task RemoveItemByItemId(int itemId);
        Task<string> VerifyCanCheckoutMessage();
    }
}