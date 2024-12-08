using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Models
{
    public class ProductListViewModel : TransactionalInformation
    {
        public IEnumerable<ProductDto> ProductList { set; get; }
        public ProductCategoryDto Category { set; get; }
    }
}