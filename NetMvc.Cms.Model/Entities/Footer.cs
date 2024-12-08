namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Footer : EntityBase
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }

        //[StringLength(10)]
        //public string LanguageCode { get; set; }

        //public bool Status { get; set; }
    }
}
