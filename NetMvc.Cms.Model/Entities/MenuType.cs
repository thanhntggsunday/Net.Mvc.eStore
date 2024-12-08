namespace NetMvc.Cms.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class MenuType : EntityBase
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        //public DateTime CreatedDate { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(20)]
        public string UpdatedBy { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
    }
}
