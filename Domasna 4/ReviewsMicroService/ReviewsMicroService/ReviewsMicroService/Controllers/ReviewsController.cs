using Microsoft.AspNetCore.Mvc;
using ReviewsMicroService.BLL.Services.Interfaces;

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
            return Ok(await _reviewService.GetFeatureReviews(featureId));
        }
    }
}
