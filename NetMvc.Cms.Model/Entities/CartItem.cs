using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetMvc.Cms.Model.Entities
{
    public class CartItem : EntityBase
    {
        public int CartItemId { get; set; }

        [Required]
        public string CartId { get; set; }

        public long ProductId { get; set; }

        public int Count { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }
    }
}
