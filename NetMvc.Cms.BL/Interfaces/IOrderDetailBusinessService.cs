using System.Linq;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IOrderDetailBusinessService
    {
        OrderDetailsDto GetOrderDetail(out TransactionalInformation transaction, params object[] id);

        IQueryable<OrderDetailsDto> GetAllOrderDetails(out TransactionalInformation transaction);
    }
}