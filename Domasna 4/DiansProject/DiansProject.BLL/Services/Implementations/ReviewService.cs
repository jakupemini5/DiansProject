using DiansProject.BLL.Services.Interfaces;
using DiansProject.DAL.Entities;
using DiansProject.DAL.Models;
using DiansProject.DAL.Repositories.Interfaces;
using DiansProject.Infrastructure.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.BLL.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly ReviewsMicroServiceConfiguration _reviewsConfiguration;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository,
            ReviewsMicroServiceConfiguration reviewsMicroServiceConfiguration)
        {
            _reviewRepository = reviewRepository;
            _reviewsConfiguration = reviewsMicroServiceConfiguration;
        }

        public async Task<List<Review>> GetFeatureReviews(string featureId)
        {
            string numberPartFeatureId = featureId.Substring(featureId.LastIndexOf("/") + 1);

            using (var client = new HttpClient())
            {
                var url = _reviewsConfiguration.BaseUrl + _reviewsConfiguration.GetReviewsEndpoint + numberPartFeatureId;
                var response = await client.GetAsync(url);

                List<Review> reviews = new List<Review>();
                List<ReviewResponseModel> reviewResponseModels = new();
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    reviewResponseModels = JsonConvert.DeserializeObject<List<ReviewResponseModel>>(result);
                }
                reviews = reviewResponseModels.Select(response => new Review()
                {
                    Id = response.Id,
                    ConditionsRating = response.ConditionsRating,
                    Date = response.Date,
                    Description = response.Description,
                    OverallRating = response.OverallRating,
                    SafetyRating = response.SafetyRating,
                }).ToList();
                return reviews;
            }
                
        }

        public async Task AddFeatureReview(ReviewRequestDTO featureReview)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(featureReview), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_reviewsConfiguration.BaseUrl + _reviewsConfiguration.PostReviewEndpoint, content);
            }
        }
        
    }
}
