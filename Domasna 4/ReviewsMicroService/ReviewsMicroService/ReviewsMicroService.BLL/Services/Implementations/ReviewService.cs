using ReviewsMicroService.BLL.Services.Interfaces;
using ReviewsMicroService.DAL.Entities;
using ReviewsMicroService.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroService.BLL.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Review>> GetFeatureReviews(string featureId)
        {
            return await _reviewRepository.GetFeatureReviews(featureId);
        }

        public async Task AddFeatureReview(string featureId, Review featureReview)
        {
            await _reviewRepository.AddFeatureReview(featureId, featureReview);
        }
        
    }
}
