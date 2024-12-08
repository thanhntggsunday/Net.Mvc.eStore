using System;
using NetMvc.Cms.Common;

namespace NetMvc.Cms.Portal.Areas.Admin.Models
{
    public class CategoryViewModel : TransactionalInformation
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public int? Order { set; get; }
        public bool? Status { set; get; }
        public DateTime? CreatedDate { set; get; }
    }
}