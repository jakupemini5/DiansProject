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
    public class FeatureRepository : IFeatureRepository 
    {
        private readonly DatabaseContext _databaseContext;

        public FeatureRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<List<Feature>> GetAllFeatures()
        {
            return await _databaseContext.Features.ToListAsync();
        }

        public async Task<Feature> GetFeatureById(string id)
        {
            return await _databaseContext.Features.FirstOrDefaultAsync(feature => feature.Id == id);
        }


    }
}
