using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.DAL;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class ShoppingCartBusinessService : IShoppingCartBusinessService
    {
        public string ShoppingCartId { get; set; }


        /// <summary>
        /// The GetCart
        /// </summary>
        /// <param name="ShoppingCartId">The ShoppingCartId<see cref="string"/></param>
        /// <returns>The <see cref="ShoppingCartBusinessService"/></returns>
        public static ShoppingCartBusinessService GetCart(string ShoppingCartId)
        {
            var cart = new ShoppingCartBusinessService();
            cart.ShoppingCartId = ShoppingCartId;
            return cart;
        }

        public void AddToCart(ProductDto dto)
        {
            using (var context = new NetMvcDbContext())
            {
                var cartitems = context.CartItems.Where(o => o.CartId == ShoppingCartId && o.ProductId == dto.ID);

                if (!cartitems.Any())
                {
                    var cartItem = new CartItem();

                    cartItem.CartId = ShoppingCartId;
                    cartItem.ProductId = dto.ID;
                    cartItem.Count = 1;
                    cartItem.DateCreated = DateTime.Now;

                    context.CartItems.Add(cartItem);
                    context.SaveChanges();
                }
                else
                {
                    var item = cartitems.FirstOrDefault();
                    item.Count = item.Count + 1;

                    context.Entry(item).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public void EmptyCart()
        {
            using (var context = new NetMvcDbContext())
            {
                var cartitems = context.CartItems.Where(o => o.CartId == ShoppingCartId).ToList();

                for (int i = 0; i < cartitems.Count(); i++)
                {
                    var item = cartitems[i];
                    context.CartItems.Remove(item);
                }


                context.SaveChanges();
            }
        }

        public List<CartItemDto> GetCartItems()
        {
            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from c in context.CartItems
                    join p in context.Products on c.ProductId equals p.ID
                    select new CartItemDto()
                    {
                       CartId = c.CartId,
                       Count = c.Count,
                       CreatedDate = c.CreatedDate,
                       ProductId = c.ProductId,
                       CartItemId = c.CartItemId,
                       Price = p.Price.Value,
                       ProductImage = p.Images,
                       ProductName = p.Title
                    };

                var result = queryable.Where(x=>x.CartId == ShoppingCartId).ToList();
               
                return result;
            }
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            var cartItems = GetCartItems();
            int count = 0;

            foreach (var item in cartItems)
            {
                count += item.Count;
            }
            // Return 0 if all entries are null
            return count;
        }

        public decimal GetTotalPrice()
        {
            // Multiply album price by count of that album to get
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            var cartItems = GetCartItems();
            decimal total = 0;

            foreach (var item in cartItems)
            {
                total += item.Count * item.Price;
            }

            return total;
        }

        public void MigrateCart(string userName)
        {
            throw new Exception("Not implement method [MigrateCart]!");
        }

        public int RemoveFromCart(int id)
        {
            int itemCount = 0;

            using (var context = new NetMvcDbContext())
            {
                var cartitems = context.CartItems.Where(o => o.CartId == ShoppingCartId && o.CartItemId == id);

                if (cartitems.Any())
                {
                    var item = cartitems.FirstOrDefault();

                    if (item.Count > 1)
                    {
                        item.Count--;
                        itemCount = item.Count;

                        context.Entry(item).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        context.CartItems.Remove(item);
                        context.SaveChanges();
                    }

                }
                
            }

            return itemCount;
        }

        public bool SaveUpdateCart(int id, int count)
        {
            using (var context = new NetMvcDbContext())
            {
                var cartitems = context.CartItems.Where(o => o.CartItemId == id);

                if (cartitems.Any())
                {
                    var item = cartitems.FirstOrDefault();

                    if (count <= 0)
                    {
                        context.CartItems.Remove(item);
                    }
                    else
                    {
                        item.Count = count;
                        context.Entry(item).State = EntityState.Modified;
                    }
                    
                    context.SaveChanges();
                }

            }

            return true;
        }
    }
}
