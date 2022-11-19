using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Models
{
    public class SearchParameters
    {
        [Range(0, 1000, ErrorMessage = "Enter number between 0 to 1000")]
        public int? CapacityCount { get; set; }
        [Required]
        public string? SearchText { get; set; }

    }
}
