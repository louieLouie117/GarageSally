using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        public string Description { get; set; }

        // Relationships
        public int UserId { get; set; } // O2O with User
        public User FeedbackAuthor { get; set; }
    }
}