namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Contact : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }
      
    }
}
