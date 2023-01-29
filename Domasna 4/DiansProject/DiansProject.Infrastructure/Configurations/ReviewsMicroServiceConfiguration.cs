using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.Infrastructure.Configurations
{
    public class ReviewsMicroServiceConfiguration
    {
        public string BaseUrl { get; set; }
        public string GetReviewsEndpoint { get; set; }
        public string PostReviewEndpoint { get; set; }
    }
}
