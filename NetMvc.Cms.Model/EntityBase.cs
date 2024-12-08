using System;
using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Model
{
    public class EntityBase
    {
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        // public string IsActive { get; set; }
        public string StrStatus { get; set; }

        public bool? Status { get; set; }
      
        // [Required]
        [StringLength(10)]
        public string LanguageCode { get; set; }
    }
}
