using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroService.DAL.Entities
{
    public class Review
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Enter number between 1 to 5")]
        public int OverallRating { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Enter number between 1 to 5")]
        public int SafetyRating { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Enter number between 1 to 5")]
        public int ConditionsRating { get; set; }
    }
}
