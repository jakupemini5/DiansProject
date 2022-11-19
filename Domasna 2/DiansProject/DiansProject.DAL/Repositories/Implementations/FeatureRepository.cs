using DiansProject.DAL.Data;
using DiansProject.DAL.Entities;
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


            return await query.ToListAsync();
        }

        public async Task<Feature> GetFeatureById(string id)
        {
            return await _databaseContext.Features.FirstOrDefaultAsync(feature => feature.Id == id);
        }


    }
}
