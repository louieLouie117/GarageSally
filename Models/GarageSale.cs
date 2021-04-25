using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin.Models
{
    public class GarageSale
    {
        [Key]
        public int GarageSaleId { get; set; }

        // Date and time----------------------------
        [Display(Name = "Start Time")]

        public DateTime StartDate { get; set; }
        // [Required]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        // [Required]
        public DateTime EndTime { get; set; }


        // Description------------------------------
        public string Description { get; set; }


        // Adddress------------------------------
        [Display(Name = "Building Number")]
        // [Required]
        public int StreetNumber { get; set; }

        [Display(Name = "Street Name")]
        // [Required]
        public string StreetName { get; set; }

        // [Required]
        public string City { get; set; }

        public string State { get; set; }

        // [Required]
        public int Zipcode { get; set; }


        // other-----------------------------
        public string Image { get; set; }

        public int VisitedCount { get; set; }

        public int CheckInCount { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Relationships--------------------------------------------
        public User Seller { get; set; } // User who posted O2M
        List<GarageList> FavedBy { get; set; } // matched Favorites in User M2M
    }
}