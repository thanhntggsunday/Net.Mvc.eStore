using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Models
{
    public class ProductViewModel : TransactionalInformation
    {
        public ProductViewModel()
        {
            ProductDetail = new ProductDto();
            NewProducts = new List<ProductDto>();
            Category = new ProductCategoryDto();
            RelatedProducts = new List<ProductDto>();
        }

        public ProductDto ProductDetail { set; get; }
        public IEnumerable<ProductDto> NewProducts { set; get; }
        public ProductCategoryDto Category { set; get; }
        public IEnumerable<ProductDto> RelatedProducts { set; get; }
    }
}