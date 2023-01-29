using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroService.DAL.Entities
{
    public class Properties
    {
        public string Id { get; set; }
        public string? Access { get; set; }
        public string? Amenity { get; set; }
        public string? Fee { get; set; }
        public string? Parking { get; set; }
        public int? Level { get; set; }
        public string? Name { get; set; }
        public string? NameEn { get; set; }
        public int? Capacity { get; set; }
        public string? Wheelchair { get; set; }
        public string? BicycleParking { get; set; }
        public string? Covered { get; set; }
        public string? Operator { get; set; }
    }
}
