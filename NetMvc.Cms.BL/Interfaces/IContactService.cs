using NetMvc.Cms.Common;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IContactService<T> : ICommonService<T>
    {
        T GetDefaultContact(string cultureName, out TransactionalInformation transaction);
    }
}
