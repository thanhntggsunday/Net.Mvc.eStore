namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Photo : EntityBase
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        public long AlbumID { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //[StringLength(50)]
        //public string CreatedBy { get; set; }

        //public bool? Status { get; set; }
    }
}
