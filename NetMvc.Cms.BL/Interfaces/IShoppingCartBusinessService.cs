using System.Collections.Generic;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IShoppingCartBusinessService 
    {
        string ShoppingCartId { get; set; }

        void AddToCart(ProductDto product);

        void EmptyCart();

        List<CartItemDto> GetCartItems();

        int GetCount();

        decimal GetTotalPrice();

        void MigrateCart(string userName);

        int RemoveFromCart(int id);

        bool SaveUpdateCart(int id, int count);
    }
}