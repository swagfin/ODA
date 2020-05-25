using Blazored.SessionStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using ODA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ODA.Services.Implementations
{
    public class JSCartService : ICartService
    {
        private ISessionStorageService StorageService { get; }
        public IEncryptionAlgorithimService EncryptService { get; }
        private string USER_CART_ENCRYPTION_KEY { get; }
        public JSCartService(IConfiguration configuration, ISessionStorageService storage, IEncryptionAlgorithimService encryptionAlgorithim)
        {
            StorageService = storage;
            EncryptService = encryptionAlgorithim;
            USER_CART_ENCRYPTION_KEY = configuration["EncryptionKeys:CartKey"];
        }

        public async Task<List<OrderItem>> GetShoppingListAsync()
        {
            List<OrderItem> cart = null;
            try
            {
                //Handle Exception
                string cartEncrypted = await StorageService.GetItemAsync<string>(ODAConstants.shoppingCart.ToString());
                if (!string.IsNullOrWhiteSpace(cartEncrypted))
                {
                    //Proceed by Decrpting if string has somthing
                    string cartDecrypted = EncryptService.Decrypt(cartEncrypted, USER_CART_ENCRYPTION_KEY);
                    cart = JsonConvert.DeserializeObject<List<OrderItem>>(cartDecrypted);
                }
                //Proceed
                if (cart == null)
                {
                    cart = new List<OrderItem>();
                    await EmptyShoppingCartAsync();
                }
            }
            catch (Exception)
            {
                await EmptyShoppingCartAsync();
            }

            return await Task.FromResult(cart);
        }


        public async Task PushShoppingCartAsync(List<OrderItem> cart)
        {
            if (cart == null)
                cart = new List<OrderItem>();
            //Serialize to string
            string cartString = JsonConvert.SerializeObject(cart);
            //Encrypt string
            string encryptedCart = EncryptService.Encrypt(cartString, this.USER_CART_ENCRYPTION_KEY);
            //Save thate storage
            //Set Cart Items to Reduce latent Time
            await StorageService.SetItemAsync(ODAConstants.shoppingCartItems.ToString(), cart.Sum(x => x.Quantity));
            await StorageService.SetItemAsync(ODAConstants.shoppingCart.ToString(), encryptedCart);
        }
        public Task EmptyShoppingCartAsync()
        {
            return PushShoppingCartAsync(new List<OrderItem>());
        }



        public async Task AddItemAsync(OrderItem item)
        {
            List<OrderItem> Cart = await GetShoppingListAsync();
            //Check Item Being Added is of Another Restaurant
            //Clear If its from another Restaurant
            if (Cart != null && Cart.FirstOrDefault(x => x.OrderRestaurantId == item.OrderRestaurantId) == null)
                Cart = new List<OrderItem>();
            //Proceed
            var existItem = Cart.FirstOrDefault(x => x.ItemId == item.ItemId);
            if (existItem != null && string.IsNullOrEmpty(item.ItemNote))
            {
                existItem.Quantity += 1;
                existItem.Rate = item.Rate;
                existItem.Tax = item.Tax * existItem.Quantity;
                existItem.TotalCost = item.Rate * existItem.Quantity;
            }
            else
                Cart.Add(item);

            //Push Update
            await PushShoppingCartAsync(Cart);
        }

        public async Task ReduceItemAsync(OrderItem item)
        {
            List<OrderItem> Cart = await GetShoppingListAsync();
            var existItem = Cart.FirstOrDefault(x => x.ItemId == item.ItemId);
            if (existItem != null && string.IsNullOrEmpty(existItem.ItemNote))
            {
                //Check if Already Less or Equan to One
                if (existItem.Quantity <= 1)
                    Cart.Remove(existItem);
                else
                {
                    existItem.Quantity = (existItem.Quantity - 1);
                    existItem.Rate = item.Rate;
                    existItem.Tax = existItem.Tax * (existItem.Quantity - 1);
                    existItem.TotalCost = item.Rate * (existItem.Quantity - 1);
                }
            }
            //Push Update
            await PushShoppingCartAsync(Cart);
        }

        public Task AddItemAsync(Item item, int Quantity = 1)
        {
            //Proceeed
            OrderItem newItem = new OrderItem
            {
                OrderRestaurantId = item.RestaurantId,
                WaitTimeInMin = item.WaitTimeInMin,
                ItemBarcode = item.ItemBarcode,
                ItemId = item.ItemId,
                Quantity = Quantity,
                Rate = item.SellingPrice,
                ItemName = item.ItemName,
                TotalCost = item.SellingPrice * Quantity
            };
            return AddItemAsync(newItem);
        }
        public async Task ReduceItemAsync(Item item)
        {
            List<OrderItem> Cart = await GetShoppingListAsync();
            var existItem = Cart.FirstOrDefault(x => x.ItemId == item.ItemId);
            if (existItem != null && string.IsNullOrEmpty(existItem.ItemNote))
            {
                //Check if Already Less or Equan to One
                if (existItem.Quantity <= 1)
                    Cart.Remove(existItem);
                else
                {
                    existItem.Quantity = (existItem.Quantity - 1);
                    existItem.Rate = item.SellingPrice;
                    existItem.Tax = existItem.Tax * (existItem.Quantity - 1);
                    existItem.TotalCost = item.SellingPrice * (existItem.Quantity - 1);
                }
            }
            //Push Update
            await PushShoppingCartAsync(Cart);
        }


        public async Task RemoveItem(OrderItem item)
        {
            List<OrderItem> Cart = await GetShoppingListAsync();
            var existItem = Cart.FirstOrDefault(x => x.ItemId == item.ItemId);
            if (existItem != null)
                Cart.Remove(existItem);
            //Push Update
            await PushShoppingCartAsync(Cart);
        }

        public async Task<double> GetTotalDueAsync()
        {
            List<OrderItem> Cart = await GetShoppingListAsync();
            return Cart.Sum(x => x.TotalCost);
        }
        public async Task<double> GetSubTotal()
        {
            var totalDue = await GetTotalDueAsync();
            var totalTax = await GetTotalTaxAsync();
            return totalDue - totalTax;
        }

        public async Task<double> GetTotalDiscount()
        {
            List<OrderItem> Cart = await GetShoppingListAsync();
            return Cart.Sum(x => x.Discount);
        }

        public async Task<double> GetTotalTaxAsync()
        {
            List<OrderItem> Cart = await GetShoppingListAsync();
            return Cart.Sum(x => x.Tax);
        }

        /// <summary>
        /// This Function tries to Make it Fast By getting the Quantity of Shopping Cart Count instead of Fetching Entire Cart then Getting the Quantity
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalItemsAsync()
        {
            try
            {
                int count = await StorageService.GetItemAsync<int>(ODAConstants.shoppingCartItems.ToString());
                return count;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public async Task<string> VerifyCanCheckoutMessage()
        {
            var totalItems = await GetTotalItemsAsync();
            if (totalItems < 1)
                return ("No Items added In Shopping Cart");
            //Verify Item
            List<OrderItem> allItems = await GetShoppingListAsync();
            foreach (var item in allItems)
            {
                if (item.Quantity < 1)
                    return ($"Quantity of {item.ItemName} can not be less than 1");
                if (item.Rate < 0)
                    return ($"Rate of {item.ItemName} can not be less than 0");
            }
            //If All Tests passed
            return null;
        }


        public async Task RemoveItemByItemId(int itemId)
        {
            List<OrderItem> Cart = await GetShoppingListAsync();
            var existItem = Cart.FirstOrDefault(x => x.ItemId == itemId);
            if (existItem != null && string.IsNullOrEmpty(existItem.ItemNote))
                Cart.Remove(existItem);
            //Push Update
            await PushShoppingCartAsync(Cart);
        }


    }
}
