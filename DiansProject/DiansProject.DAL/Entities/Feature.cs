using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Entities
{
    public class Feature
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public virtual Properties Properties { get; set; }
        public virtual Geometry Geometry { get; set; }
    }
}
