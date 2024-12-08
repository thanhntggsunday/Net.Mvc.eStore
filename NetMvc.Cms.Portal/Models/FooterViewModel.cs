using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Models
{
    public class FooterViewModel : TransactionalInformation
    {
        public FooterViewModel()
        {
                ProductCategoryDtos = new List<ProductCategoryDto>();
                BottomMenus = new List<MenuDto>();
        }
        public List<ProductCategoryDto> ProductCategoryDtos { get; set; }
        public List<MenuDto> BottomMenus { get; set; }
        public string FooterContentHtml { get; set; }
    }
}