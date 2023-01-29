using DiansProject.BLL.Services.Interfaces;
using DiansProject.DAL.Entities;
using DiansProject.DAL.Models;
using DiansProject.DAL.Repositories.Interfaces;
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
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Review>> GetFeatureReviews(string featureId)
        {
            string numberPartFeatureId = featureId.Substring(featureId.LastIndexOf("/") + 1);

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7251/api/Reviews/" + numberPartFeatureId);

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

        public async Task AddFeatureReview(ReviewRequestDTO featureReview)
        {
            var client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(featureReview), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7251/api/Reviews", content);

            if (response.IsSuccessStatusCode)
            {

            }

            //await _reviewRepository.AddFeatureReview(featureId, featureReview);
        }
        
    }
}
