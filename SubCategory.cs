
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
