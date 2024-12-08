namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public  class SystemConfigDto : EntityBaseDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ảnh")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string UniqueKey { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Value")]
        public string Value { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(50)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}