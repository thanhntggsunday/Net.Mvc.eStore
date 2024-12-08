using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Models
{
    public class NewsDetailViewModel : TransactionalInformation
    {
        public NewsDetailViewModel()
        {
            HotNewses = new List<NewsDto>();
            RelatedNewses = new List<NewsDto>();
            NewsDetail = new NewsDto();
            Category = new CategoryDto();
            Tags = new List<TagDto>();
        }
        public IEnumerable<NewsDto> HotNewses { set; get; }
        public IEnumerable<NewsDto> RelatedNewses { set; get; }
        public NewsDto NewsDetail { set; get; }
        public CategoryDto Category { set; get; }
        public IEnumerable<TagDto> Tags { set; get; }
    }
}