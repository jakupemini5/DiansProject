using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Models
{
    public class ReviewResponseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("overallRating")]
        public int OverallRating { get; set; }

        [JsonProperty("safetyRating")]
        public int SafetyRating { get; set; }

        [JsonProperty("conditionsRating")]
        public int ConditionsRating { get; set; }
    }


}
