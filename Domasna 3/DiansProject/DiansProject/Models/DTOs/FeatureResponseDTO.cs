using DiansProject.DAL.Entities;

namespace DiansProject.Models.DTOs
{
    public class FeatureResponseDTO
    {
        public string Id { get; set; }
        public string? Type { get; set; }
        public virtual Properties Properties { get; set; }
        public virtual Geometry Geometry { get; set; }
        public virtual List<Review> Reviews { get; set; }

        public double AverageOverallRating { get; set; }
        public double AverageSafetyRating { get; set; }
        public double AverageConditionsRating { get; set; }
    }
}
