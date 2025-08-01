using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Write down category name")]
        public string? Name { get; set; }
        [Display(Name = "Choose your display order")]
        [Range(1, 100, ErrorMessage = "Display Order must be inside this range 1-100")]
        public int DisplayOrder { get; set; }
        public string? AddBy { get; set; }
        public DateTime? AddDate { get; set; }
        public string? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? Status { get; set; }

    }
}
