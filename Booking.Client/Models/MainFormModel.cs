using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorClient.Models
{
    public class MainFormModel
    {
        [Required]
        public string City { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int Seats { get; set; }

        public string Type { get; set; }
    }
}