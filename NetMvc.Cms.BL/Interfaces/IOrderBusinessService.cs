using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IOrderBusinessService
    {
        OrderDto CreateOrder(OrderDto obj, string userName, out TransactionalInformation transaction);

        void UpdateOrder(OrderDto obj, out TransactionalInformation transaction);

        OrderDto GetOrder(object id, out TransactionalInformation transaction, out List<OrderDetailsDto> orderDetailDTOs);

        // void DeleteOrder(object id, out TransactionalInformation transaction);

        List<OrderDto> GetOrdersByPaging(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out TransactionalInformation transaction);

        List<OrderDto> GetOrdersByEmailPaging(string email, int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out TransactionalInformation transaction);
        List<OrderDto> GetAll(out TransactionalInformation transaction);
        List<OrderDto> GetAllOrdersByEmail(string email, out TransactionalInformation transaction);

        List<OrderDto> GetDataTablePaging(string cultureName, int itemsSkipCount, int pageSize,
            out TransactionalInformation transaction);
        long GetCount(out TransactionalInformation transaction);
    }
}