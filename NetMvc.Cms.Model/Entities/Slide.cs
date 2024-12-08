namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Slide : EntityBase
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [Required]
        [StringLength(250)]
        public string Images { get; set; }

        public int Order { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupID { get; set; }

        // public bool Status { get; set; }
    }
}
