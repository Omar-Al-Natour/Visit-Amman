using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public string? MapLinkIFrame { get; set; }
        public string Image { get; set; }
        [Range(1,1000,ErrorMessage ="The price should be between 1JD and 1000JD")]
        public double Price { get; set; }
        [Display(Name="SubCategry")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; } 
        public Category Category { get; set; }
    }
}
