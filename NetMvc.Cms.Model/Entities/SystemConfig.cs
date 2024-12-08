namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class SystemConfig : EntityBase
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string UniqueKey { get; set; }

        [Required]
        [StringLength(250)]
        public string Value { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        //public DateTime CreatedDate { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string CreatedBy { get; set; }

        //public DateTime UpdatedDate { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
