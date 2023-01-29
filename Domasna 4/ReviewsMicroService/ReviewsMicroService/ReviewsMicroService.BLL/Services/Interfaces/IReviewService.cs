using ReviewsMicroService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroService.BLL.Services.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetFeatureReviews(string featureId);
        Task AddFeatureReview(string featureId, Review featureReview);
    }
}
