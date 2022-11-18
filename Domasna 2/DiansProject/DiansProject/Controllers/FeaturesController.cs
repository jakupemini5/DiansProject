using DiansProject.BLL.Services.Interfaces;
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
        public async Task<IActionResult> Index()
        {
            var results = await _featureService.GetAllFeatures();
            return View(results);
        }

        public async Task<IActionResult> Details(string Id)
        {
            var result = await _featureService.GetFeatureById(Id);
            return View(result);
        }
    }
}
