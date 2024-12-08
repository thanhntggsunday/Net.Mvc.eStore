using System.Collections.Generic;
using NetMvc.Cms.Common;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IMenuService<T> : ICommonService<T>
    {
        List<T> GetBottomMenuAll(string cultureName, out TransactionalInformation transaction);
        List<T> GetTopMenuAll(string cultureName, out TransactionalInformation transaction);
    }
}
