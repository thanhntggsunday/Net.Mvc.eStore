namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Function : EntityBase
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        public string Text { get; set; }

        [Required]
        [StringLength(250)]
        public string Link { get; set; }

        [Required]
        [StringLength(10)]
        public string Target { get; set; }

        public int Order { get; set; }

        [StringLength(50)]
        public string CssClass { get; set; }

        public bool IsLocked { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(50)]
        public string ParentID { get; set; }

        //public DateTime CreatedDate { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string CreatedBy { get; set; }

        //    public DateTime? UpdatedDate { get; set; }

        //    [StringLength(20)]
        //    public string UpdatedBy { get; set; }
    }
}
