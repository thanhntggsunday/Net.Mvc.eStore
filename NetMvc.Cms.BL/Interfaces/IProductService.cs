using System.Collections.Generic;
using NetMvc.Cms.Common;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IProductService<T> : ICommonService<T>, IBaseService
    {
        List<T> GetTopList(string cultureName, out TransactionalInformation transaction);
        List<T> GetProductByCateIdPaging(string cultureName, long cateID, int currentPageNumber, int pageSize,
            out TransactionalInformation transaction);

        List<T> GetRelatedProducts(string cultureName, long cateID, out TransactionalInformation transaction);
        List<T> SearchProducts(string cultureName, string keyWords, int currentPageNumber, int pageSize,
            out TransactionalInformation transaction);

        List<T> GetDataTablePaging(string cultureName, int itemsSkipCount, int pageSize,
            out TransactionalInformation transaction);
    }
}
