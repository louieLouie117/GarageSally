using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class GarageSale
    {
        [Key]
        public int GarageSaleId { get; set; }

        [Display(Name = "Start Time")]

        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        [Display(Name = "Building Number")]
        public string StreetNumber { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }

        public string County { get; set; }

        public string Image { get; set; }

        public int VisitedCount { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Relationships
        public User Seller { get; set; } // O2M with User
        List<GarageList> FavedBy { get; set; } // M2M with User
    }
}