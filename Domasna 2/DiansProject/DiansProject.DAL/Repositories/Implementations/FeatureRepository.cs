using DiansProject.DAL.Data;
using DiansProject.DAL.Entities;
using DiansProject.DAL.Enums;
using DiansProject.DAL.Models;
using DiansProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Repositories.Implementations
{
    public class FeatureRepository : IFeatureRepository 
    {
        private readonly DatabaseContext _databaseContext;

        public FeatureRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<List<Feature>> GetAllFeatures(SearchParameters? searchParameters)
        {
            IQueryable<Feature> query = _databaseContext.Features;

            if (searchParameters == null)
                return await query.ToListAsync();

            if (searchParameters.CapacityCount > 0)
                query = query.Where(feature => feature.Properties.Capacity!=null && 
                feature.Properties.Capacity > searchParameters.CapacityCount);
            if ( !string.IsNullOrEmpty(searchParameters.SearchText))
                query = query.Where(feature => !string.IsNullOrEmpty(feature.Properties.Name) && feature.Properties.Name.Contains(searchParameters.SearchText));
            if(searchParameters.ParkingType != ParkingType.NotSpecified)
            {
                if (searchParameters.ParkingType == ParkingType.CarParking)
                    query = query.Where(feature => !string.IsNullOrEmpty(feature.Properties.Amenity) && feature.Properties.Amenity.Equals("PARKING"));
                else
                    query = query.Where(feature => !string.IsNullOrEmpty(feature.Properties.Amenity) && feature.Properties.Amenity.Equals("BICYCLE_PARKING"));
            }
            if (searchParameters.PaymentType != ParkingPaymentType.NotSpecified)
            {
                if (searchParameters.PaymentType == ParkingPaymentType.Free)
                    query = query.Where(feature => !string.IsNullOrEmpty(feature.Properties.Fee) && feature.Properties.Fee.Equals("no"));
                else
                    query = query.Where(feature => !string.IsNullOrEmpty(feature.Properties.Fee) && feature.Properties.Fee.Equals("yes"));
            }

            if (searchParameters.AverageOverallRating != null)
                query = query.Where(feature => feature.Reviews.Count > 0 && feature.Reviews.Average(review => review.OverallRating) > searchParameters.AverageOverallRating);

            if (searchParameters.AverageSafetyRating != null)
                query = query.Where(feature => feature.Reviews.Count > 0 && feature.Reviews.Average(review => review.SafetyRating) > searchParameters.AverageSafetyRating);

            if (searchParameters.AverageConditionsRating != null)
                query = query.Where(feature => feature.Reviews.Count > 0 && feature.Reviews.Average(review => review.ConditionsRating) > searchParameters.AverageConditionsRating);



            return await query.ToListAsync();
        }

        public async Task<Feature> GetFeatureById(string id)
        {
            return await _databaseContext.Features.FirstOrDefaultAsync(feature => feature.Id == id);
        }


    }
}
