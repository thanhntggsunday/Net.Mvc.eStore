namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class UserGroupDto : EntityBaseDto
    {
        [StringLength(20)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
    }
}