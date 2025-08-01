using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Models
{
    public class ProductReview
    {
        [Key]
        public int ProdReviewId { get; set; }
        [Required]
        public string? ProdReviewText { get; set; }
        [Range(1, 5, ErrorMessage = "Please select a rating between 1 and 5.")]
        public int ProdRating { get; set; }
        public DateTime ProdDateSubmitted { get; set; }
        public string? ApplicationUserId { get; set; }
        public string? UserName { get; set; }
        public int? MenuItemId { get; set; }
    }
}
