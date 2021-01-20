using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin.Models
{
    public class GarageSale
    {
        [Key]
        public int GarageSaleId { get; set;}

        [Display(Name = "Building Number")]
        [Required]
        public int StreetNumber {get; set;}

        [Display(Name = "Street Name")]
        [Required]
        public string StreetName {get; set;}

        [Required]
        public string City {get; set;}

        [Required]
        public int Zipcode {get; set;}

        [Display(Name = "Start Time")]
        [Required]
        public DateTime StartTime {get; set;}

        [Display(Name = "End Time")]
        [Required]
        public DateTime EndTime {get; set;}

        public string Image {get; set;}

        public int UserId {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Relationships
        public User Seller {get; set;} // User who posted O2M
        List<GarageList> FavedBy {get; set;} // matched Favorites in User M2M
    }
}