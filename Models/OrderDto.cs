using System.ComponentModel.DataAnnotations;

namespace SPO.Models
{
    public class OrderDto
    {
        [Required]
        public int orderId { get; set; }

        [Required, MaxLength(100)]
        public string customerName { get; set; } = "";

        [Required, MaxLength(100)]
        public string sweaterType { get; set; } = "";

        [Required]
        public int quantity { get; set; }

        [Required, MaxLength(100)]
        public string status { get; set; } = "";
    }
}
