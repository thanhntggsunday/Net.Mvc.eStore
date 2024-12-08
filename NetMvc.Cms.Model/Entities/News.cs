namespace NetMvc.Cms.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Newses")]
    public partial class News : EntityBase
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        //public int Status { get; set; }

        //public DateTime CreatedDate { get; set; }

        //[Required]
        //[StringLength(10)]
        //public string CreatedBy { get; set; }

        //public DateTime? UpdatedDate { get; set; }

        //[StringLength(10)]
        //public string UpdatedBy { get; set; }

        public DateTime? PublishedDate { get; set; }

        [StringLength(50)]
        public string RelatedNewses { get; set; }

        public long CategoryID { get; set; }

        public int ViewCount { get; set; }

        [StringLength(50)]
        public string Source { get; set; }

        public DateTime? UpTopNew { get; set; }

        public DateTime? UpTopHot { get; set; }

        //[StringLength(10)]
        //public string LanguageCode { get; set; }
    }
}
