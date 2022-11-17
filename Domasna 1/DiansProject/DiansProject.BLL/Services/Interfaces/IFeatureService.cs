using DiansProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.BLL.Services.Interfaces
{
    public interface IFeatureService
    {
        Task<List<Feature>> GetAllFeatures();
        Task<Feature> GetFeatureById(string id);
    }
}
