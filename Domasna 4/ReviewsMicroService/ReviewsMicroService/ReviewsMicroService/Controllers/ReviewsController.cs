using Microsoft.AspNetCore.Mvc;
using ReviewsMicroService.BLL.Services.Interfaces;
using ReviewsMicroService.DAL.Entities;
using ReviewsMicroService.Models;

namespace ReviewsMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet("{featureId}")]
        public async Task<IActionResult> GetReviews(string featureId)
        {
            var result = await _reviewService.GetFeatureReviews(featureId);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ReviewRequestDTO model)
        {
            Review review = new Review()
            {
                ConditionsRating = model.ConditionsRating,
                Description = model.Description,
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                OverallRating = model.OverallRating,
                SafetyRating = model.SafetyRating,

            };
            await _reviewService.AddFeatureReview(model.FeatureId, review);
            return NoContent();
        }
    }
}
