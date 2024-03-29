﻿using DiansProject.BLL.Services.Interfaces;
using DiansProject.DAL.Entities;
using DiansProject.DAL.Models;
using DiansProject.DAL.Repositories.Interfaces;
using DiansProject.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DiansProject.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public async Task<IActionResult> Index(string featureId)
        {
            var result = await _reviewService.GetFeatureReviews(featureId);
            TempData["FeatureId"] = featureId;
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create(string featureId)
        {
            TempData["FeatureId"] = featureId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewRequestDTO model)
        {
            await _reviewService.AddFeatureReview(model);
            return RedirectToAction("Index",new { featureId=model.FeatureId});
        }


    }
}
