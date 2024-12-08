using NetMvc.Cms.Common;
using System.Collections.Generic;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface ICommonService<T>
    {
        List<T> GetAll(string cultureName, out TransactionalInformation transaction);

        List<T> GetDataPaging(string cultureName, int currentPageNumber, int pageSize,
            out TransactionalInformation transaction);

        T GetItemByID(object id, out TransactionalInformation transaction);

        T Create(T entity, out TransactionalInformation transaction);
        void Update(T entity, out TransactionalInformation transaction);
        void Delete(T entity, out TransactionalInformation transaction);
    }
}