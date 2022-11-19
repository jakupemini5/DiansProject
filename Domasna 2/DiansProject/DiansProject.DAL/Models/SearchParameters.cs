using DiansProject.DAL.Enums;
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
        public string? SearchText { get; set; }
        public ParkingType ParkingType { get; set; }
        public ParkingPaymentType PaymentType { get; set; }

        [Range(0, 5, ErrorMessage = "Enter number between 1 to 5")]
        public double? AverageOverallRating { get; set; }
        [Range(0, 5, ErrorMessage = "Enter number between 1 to 5")]
        public double? AverageSafetyRating { get; set; }
        [Range(0, 5, ErrorMessage = "Enter number between 1 to 5")]
        public double? AverageConditionsRating { get; set; }


    }
}
