namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public  class AlbumDto : EntityBaseDto
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int? Order { get; set; }


        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        
    }
}