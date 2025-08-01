using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FeedbackText { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string? ApplicationUserId { get; set; }
        public string? UserName { get; set; }

    }
}
