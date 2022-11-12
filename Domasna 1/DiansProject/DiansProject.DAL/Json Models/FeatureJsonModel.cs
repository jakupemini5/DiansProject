using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Json_Models
{
    public class FeatureJsonModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public PropertiesJsonModel Properties { get; set; }

        [JsonProperty("geometry")]
        public GeometryJsonModel Geometry { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
