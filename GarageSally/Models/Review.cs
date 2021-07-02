using System;
using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public int ReviewerId { get; set;}

        public int ReviewedId { get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Relationships
        public User Reviewer { get; set; } // O2M with User Reviews
        public User Reviewed { get; set;} // O2M with User UserReviews
    }
}