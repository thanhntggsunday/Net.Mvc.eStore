namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class FeedbackDto : EntityBaseDto
    {
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Công ty")]
        public string Company { get; set; }

        [StringLength(150)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        
        [StringLength(100)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Nội dung")]
        public string Message { get; set; }

     
        public bool IsReaded { get; set; }
    }
}