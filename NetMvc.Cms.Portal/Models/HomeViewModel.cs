using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Models
{
    public class HomeViewModel : TransactionalInformation
    {
        public HomeViewModel()
        {
                SlideDtos = new List<SlideDto>();
                TopNewsDtos = new List<NewsDto>();
                TopProductDtos = new List<ProductDto>();
        }
        public List<SlideDto> SlideDtos { get; set; }

        public List<NewsDto> TopNewsDtos { get; set; }

        public List<ProductDto> TopProductDtos { get; set; }
    }
}