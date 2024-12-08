namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class MenuDto : EntityBaseDto
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Chi tiết")]
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

        [Required]
        [StringLength(50)]
        public string GroupID { get; set; }

        [StringLength(50)]
        public string ParentID { get; set; }

    }
}