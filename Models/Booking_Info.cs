using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Booking_Info
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("hotel_Customer")]
        public int CustomerId { get; set; }
        public virtual Customer hotel_Customer { get; set; }
        [ForeignKey("hotel_Room")]
        public int RoomId { get; set; }
        public virtual Room hotel_Room { get; set; }

    }
}
