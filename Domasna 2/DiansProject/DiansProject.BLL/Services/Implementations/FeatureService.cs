using DiansProject.BLL.Services.Interfaces;
using DiansProject.DAL.Entities;
using DiansProject.DAL.Models;
using DiansProject.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.BLL.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<List<Feature>> GetAllFeatures(SearchParameters? searchParameters)
        {
            return await _featureRepository.GetAllFeatures(searchParameters);
        }

        public async Task<Feature> GetFeatureById(string id)
        {
            return await _featureRepository.GetFeatureById(id);
        }
    }
}
