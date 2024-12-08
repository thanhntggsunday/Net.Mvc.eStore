using System;
using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.DAL
{
    public class EntityBase
    {
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public string IsActive { get; set; }
    }
}
