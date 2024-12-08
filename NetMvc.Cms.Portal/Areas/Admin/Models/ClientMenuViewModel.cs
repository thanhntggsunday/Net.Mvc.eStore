using System;
using NetMvc.Cms.Common;

namespace NetMvc.Cms.Portal.Areas.Admin.Models
{
    public class ClientMenuViewModel : TransactionalInformation
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public int Order { set; get; }
        public bool IsLocked { set; get; }
        public DateTime? CreatedDate { set; get; }
    }
}