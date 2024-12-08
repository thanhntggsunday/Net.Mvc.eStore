using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Models
{
    public class NewsListViewModel : TransactionalInformation
    {
        public IEnumerable<NewsDto> NewsList { set; get; }
        public CategoryDto Category { set; get; }
    }
}