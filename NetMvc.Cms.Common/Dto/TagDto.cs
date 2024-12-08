namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class TagDto : EntityBaseDto
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

      
        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDefault { get; set; }
    }
}