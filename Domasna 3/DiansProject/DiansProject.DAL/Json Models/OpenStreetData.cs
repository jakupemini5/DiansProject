using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Json_Models
{
    public class OpenStreetData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("generator")]
        public string Generator { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("features")]
        public List<FeatureJsonModel> Features { get; set; }
    }
}
