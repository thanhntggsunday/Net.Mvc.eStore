using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using System.Collections.Generic;

namespace NetMvc.Cms.Portal.Models
{
    public class AlbumViewModel : TransactionalInformation
    {
        public IEnumerable<PhotoDto> PhotoList { set; get; }
        public AlbumDto Album { set; get; }
    }
}