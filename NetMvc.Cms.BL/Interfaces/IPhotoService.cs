using NetMvc.Cms.Common;
using System.Collections.Generic;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IPhotoService<T> : ICommonService<T>
    {
        List<T> GetAllPhotosByAlbumID(string cultureName, long albumID, out TransactionalInformation transaction);
    }
}
