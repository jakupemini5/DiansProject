using System.ComponentModel.DataAnnotations;

namespace ReviewsMicroService.Models
{
    public class ReviewRequestDTO
    {
        [Required]
        public string FeatureId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int OverallRating { get; set; }
        [Required]
        public int SafetyRating { get; set; }
        [Required]
        public int ConditionsRating { get; set; }
    }
}
