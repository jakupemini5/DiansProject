using DiansProject.DAL.Data;
using DiansProject.DAL.Entities;
using DiansProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ReviewRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<List<Review>> GetFeatureReviews(string featureId)
        {
            var feature = await _databaseContext.Features.FirstOrDefaultAsync(feature => feature.Id == featureId);
            if(feature == null)
            {
                return null;
            }
            return feature.Reviews.OrderByDescending(x => x.Date).ToList();
        }

        public async Task AddFeatureReview(string featureId, Review review)
        {
            var result = await _databaseContext.Features.FirstOrDefaultAsync(feature => feature.Id == featureId);
            if (result == null)
                return ;
            result.Reviews.Add(review);

            await _databaseContext.SaveChangesAsync();

        }
    }
}
