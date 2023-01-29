using Microsoft.AspNetCore.Mvc;

namespace ReviewsMicroService.Controllers
{
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public async Task<IActionResult> GetReviews(string featureId)
        {

            return Ok();
        }
    }
}
