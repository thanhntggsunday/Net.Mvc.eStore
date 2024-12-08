namespace NetMvc.Cms.Common.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserActivityLogDto : EntityBaseDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ActionName { get; set; }

        public DateTime ActionDate { get; set; }

        [Required]
        [StringLength(50)]
        public string IPAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string SessionID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
    }
}