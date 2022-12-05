using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Phone_no { get; set; }
        

    }
}
