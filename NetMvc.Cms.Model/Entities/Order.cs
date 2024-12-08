using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Model.Entities
{
    public class Order : EntityBase
    {
        public long ID { get; set; }

        [Required]
        [StringLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [StringLength(256)]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerMobile { get; set; }

        [Required]
        [StringLength(256)]
        public string CustomerMessage { get; set; }

        [StringLength(256)]
        public string PaymentMethod { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //public string CreatedBy { get; set; }

        public string PaymentStatus { get; set; }

        //public bool? Status { get; set; }

        public decimal? Total { get; set; }
    }
}