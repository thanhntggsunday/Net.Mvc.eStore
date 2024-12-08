namespace NetMvc.Cms.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Permission : EntityBase
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string GroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string FunctionID { get; set; }
    }
}
