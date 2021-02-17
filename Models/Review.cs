using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public int ReviewerId { get; set;} // Reviewer

        public int ReviewedId { get; set;} // Reviewed

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Relationships
        public User Reviewer { get; set; } // matches Reviews in User O2M
        public User Reviewed { get; set;} // matches UserReviews in User O2M
    }
}