using NetMvc.Cms.BL.Extensions;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.DAL;
using NetMvc.Cms.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NetMvc.Cms.Common.Utilities;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class OrderBusinessService : IOrderBusinessService
    {
        public OrderDto CreateOrder(OrderDto dto, string userName, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            ShoppingCartBusinessService shoppingCartBusinessService = ShoppingCartBusinessService.GetCart(userName);

            using (var context = new NetMvcDbContext())
            {
                var item = new Order();
                item.Clone(dto);

                context.Orders.Add(item);
                context.SaveChanges();

                CreateOrderDetail(item, shoppingCartBusinessService);

                dto.ID = item.ID;
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return dto;
        }

        public List<OrderDto> GetAll(out TransactionalInformation transaction)
        {
            var resutl = new List<OrderDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Orders.AsQueryable().OrderByDescending(x => x.CreatedDate);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new OrderDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public OrderDto GetOrder(object id, out TransactionalInformation transaction, out List<OrderDetailsDto> orderDetailDTOs)
        {
            orderDetailDTOs = new List<OrderDetailsDto>();
            transaction = new TransactionalInformation();
            OrderDto orderDto = new OrderDto();
            var orderId = Int64.Parse(id.ToString());

            using (var context = new NetMvcDbContext())
            {
                var od = context.Orders.Find(orderId);

                orderDto.Clone(od);

                var orderDetailsQuery = context.OrderDetails.Where(o => o.OrderID == orderId);

                var queryable =
                    from o in orderDetailsQuery
                    join p in context.Products on o.ProductID equals p.ID
                    select new OrderDetailsDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        LanguageCode = o.LanguageCode,
                        Quantitty = o.Quantitty,
                        Status = o.Status,
                        OrderID = o.OrderID,
                        StrStatus = o.StrStatus,
                        ProductID = p.ID,
                        ProductName = p.Title
                    };

                orderDetailDTOs = queryable.ToList();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return orderDto;
        }

        public List<OrderDto> GetOrdersByPaging(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out TransactionalInformation transaction)
        {
            var resutl = new List<OrderDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Orders.AsQueryable().OrderBy(x => x.ID);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new OrderDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void UpdateOrder(OrderDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Orders.FirstOrDefault(x => x.ID == dto.ID);
                // item.Clone(obj);
                item.StrStatus = dto.StrStatus;
                item.PaymentStatus = dto.PaymentStatus;
                
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        private long CreateOrderDetail(Order order, ShoppingCartBusinessService shoppingCartBusinessService)
        {
            var cartItems = shoppingCartBusinessService.GetCartItems();
            // Iterate over the items in the cart, adding the order details for each
            using (var context = new NetMvcDbContext())
            {
                foreach (var item in cartItems)
                {
                    var od = new OrderDetail
                    {
                        OrderID = order.ID,
                        ProductID = (int)item.ProductId,
                        Quantitty = item.Count
                    };

                    context.OrderDetails.Add(od);
                }

                // Set the order's total to the orderTotal count
                order.Total = shoppingCartBusinessService.GetTotalPrice();

                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }

            // Set the order's total to the orderTotal count
            order.Total = shoppingCartBusinessService.GetTotalPrice();

            // Empty the shopping cart
            shoppingCartBusinessService.EmptyCart();
            // Return the OrderId as the confirmation number
            return order.ID;
        }

        public List<OrderDto> GetAllOrdersByEmail(string email, out TransactionalInformation transaction)
        {
            var resutl = new List<OrderDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Orders.AsQueryable()
                    .Where(x => x.CustomerEmail == email).OrderBy(x => x.ID);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new OrderDto();
                    item.Clone(x);
                    resutl.Add(item);
                }
                
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<OrderDto> GetOrdersByEmailPaging(
            string email,
            int currentPageNumber, int pageSize, string sortExpression, 
            string sortDirection, out TransactionalInformation transaction)
        {
            var resutl = new List<OrderDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Orders.AsQueryable()
                    .Where(x => x.CustomerEmail == email).OrderBy(x => x.ID);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new OrderDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<OrderDto> GetDataTablePaging(string cultureName, int itemsSkipCount, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<OrderDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Orders.AsQueryable().OrderBy(x => x.ID);

                var items = queryable.Skip(itemsSkipCount).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new OrderDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public long GetCount(out TransactionalInformation transaction)
        {
            var resutl = 0;
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                resutl = context.Orders.AsQueryable().Count();
               
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }
    }
}