using System.Collections.Generic;
using NetMvc.Cms.Common;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface INewsService<T> : ICommonService<T>
    {
        List<T> GetDataByCategoryIdPaging(string cultureName, long cateID, int currentPageNumber, int pageSize,
            out TransactionalInformation transaction);
        List<T> GetTopList(string cultureName, out TransactionalInformation transaction);
        List<T> GetRelatedNewses(string cultureName, long cateID, out TransactionalInformation transaction);
        List<T> GetDataTablePaging(string cultureName, int itemsSkipCount, int pageSize,
            out TransactionalInformation transaction);
    }
}
