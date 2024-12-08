namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Album : EntityBase
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int? Order { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //[StringLength(20)]
        //public string CreatedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        //public bool? Status { get; set; }

        //[StringLength(10)]
        //public string LanguageCode { get; set; }
    }
}
