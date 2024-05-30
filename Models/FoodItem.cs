using System;
using System.ComponentModel.DataAnnotations;

namespace CS5227_A1_ABDUL36302.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public string Category { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Image is Required")]
        public string ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
