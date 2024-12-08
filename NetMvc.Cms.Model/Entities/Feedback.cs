namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Feedback : EntityBase
    {
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        //public DateTime CreatedDate { get; set; }

        public bool IsReaded { get; set; }
    }
}
