using System;
using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        public string Description { get; set; }

        // One to One with User
        public int UserId { get; set; }
        public User FeedbackAuthor { get; set; }
    }
}