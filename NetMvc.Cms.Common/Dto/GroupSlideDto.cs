namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class GroupSlideDto : EntityBaseDto
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
    }
}