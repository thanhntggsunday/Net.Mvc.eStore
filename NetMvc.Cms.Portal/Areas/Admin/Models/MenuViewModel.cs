using System.Collections.Generic;
using NetMvc.Cms.Common;

namespace NetMvc.Cms.Portal.Areas.Admin.Models
{
    public class MenuViewModel : TransactionalInformation
    {
       public string MenuId { get; set; }
       public string Text { get; set; }
       public string Link { get; set; }
       public string Target { set; get; }
       public string CssClass { set; get; }
       public List<MenuViewModel> Children { get; set; }
    }
}