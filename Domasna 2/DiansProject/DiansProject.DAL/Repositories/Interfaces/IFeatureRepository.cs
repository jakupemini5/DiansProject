using DiansProject.DAL.Entities;
using DiansProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Repositories.Interfaces
{
    public interface IFeatureRepository
    {
        Task<List<Feature>> GetAllFeatures(SearchParameters? searchParameters);
        Task<Feature> GetFeatureById(string id);
    }
}
