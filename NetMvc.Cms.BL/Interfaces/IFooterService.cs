using NetMvc.Cms.Common;
using System;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IFooterService<T> : ICommonService<T>
    {
        String GetDefaultFooter(string cultureName, out TransactionalInformation transaction);
    }
}
