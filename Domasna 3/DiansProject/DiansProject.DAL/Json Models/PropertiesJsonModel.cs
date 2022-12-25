using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Json_Models
{
    public class PropertiesJsonModel
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("access")]
        public string Access { get; set; }

        [JsonProperty("amenity")]
        public string Amenity { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("parking")]
        public string Parking { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name:en")]
        public string NameEn { get; set; }

        [JsonProperty("capacity")]
        public string Capacity { get; set; }

        [JsonProperty("wheelchair")]
        public string Wheelchair { get; set; }

        [JsonProperty("bicycle_parking")]
        public string BicycleParking { get; set; }

        [JsonProperty("covered")]
        public string Covered { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }
    }
}
