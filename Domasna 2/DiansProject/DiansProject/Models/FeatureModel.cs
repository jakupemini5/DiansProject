using DiansProject.DAL.Entities;
using DiansProject.DAL.Models;
using DiansProject.Models.DTOs;

namespace DiansProject.Models
{
    public class FeatureModel
    {
        public SearchParameters? SearchParameters { get; set; }
        public List<FeatureResponseDTO>? Features { get; set; }
        
    }
}
