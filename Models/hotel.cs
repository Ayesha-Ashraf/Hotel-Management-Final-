using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string URl { get; set; }
        [Required]
        public int Price { get; set; }
        [ForeignKey("hotel_Customer")]
        public int CustomerId { get; set; }
        public virtual Customer hotel_Customer { get; set; }
    }
}
