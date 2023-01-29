using System.ComponentModel.DataAnnotations;

namespace DiansProject.DAL.Models
{
    public class ReviewRequestDTO
    {
        [Required]
        public string FeatureId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Enter number between 1 to 5")]
        public int OverallRating { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Enter number between 1 to 5")]
        public int SafetyRating { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Enter number between 1 to 5")]
        public int ConditionsRating { get; set; }
    }
}
