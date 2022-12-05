using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Room
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Room_No { get; set; }
        [Required]
        public string floor_No { get; set; }


    }


}
