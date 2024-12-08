namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class PhotoDto : EntityBaseDto
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }


        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Images { get; set; }

        public long AlbumID { get; set; }

        [StringLength(250)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

     
    }
}