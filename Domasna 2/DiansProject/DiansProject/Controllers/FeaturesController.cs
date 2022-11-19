using DiansProject.BLL.Services.Interfaces;
using DiansProject.DAL.Models;
using DiansProject.Models;
using DiansProject.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DiansProject.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IActionResult> Index(FeatureModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(new FeatureModel() { Features=new List<FeatureResponseDTO>(), SearchParameters=new SearchParameters()});
            }

            if(model.SearchParameters!=null)
            {
                TempData["searchParameters.SearchText"] = model.SearchParameters.SearchText;
                TempData["searchParameters.CapacityCount"] = model.SearchParameters.CapacityCount;
            }
            

            var results = await _featureService.GetAllFeatures(model.SearchParameters);

            var featureResponseDto = results.Select(x => new FeatureResponseDTO()
            {
                Id = x.Id,
                Geometry = x.Geometry,
                Properties = x.Properties,
                Reviews = x.Reviews,
                Type = x.Type,
                AverageConditionsRating = x.Reviews.Count != 0 ? x.Reviews.Average(review => review.ConditionsRating) : 0,
                AverageOverallRating = x.Reviews.Count != 0 ? x.Reviews.Average(review => review.OverallRating) : 0,
                AverageSafetyRating = x.Reviews.Count != 0 ? x.Reviews.Average(review => review.SafetyRating) : 0,

            }).ToList();


            var returnResult = new FeatureModel()
            {
                SearchParameters = model.SearchParameters,
                Features = featureResponseDto
            };

            return View(returnResult);
        }

        public async Task<IActionResult> Details(string Id)
        {
            var result = await _featureService.GetFeatureById(Id);
            return View(result);
        }
    }
}
