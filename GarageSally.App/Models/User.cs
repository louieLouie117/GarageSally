using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin.Models
{
    public enum AccountType { Buyer = 0, Seller = 1, Admin = 2 }

    public enum SubscriptionStatus { Free = 0, Active = 1, Suspended = 2, Canceled = 3 }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(AccountType))]
        public AccountType AccountType { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(SubscriptionStatus))]
        public SubscriptionStatus SubscriptionStatus { get; set; }


        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "First name is too short")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Last name is too short")]
        public string LastName { get; set; }

        // [Display(Name = "Username")]
        // [Required(ErrorMessage = "Username cannot be empty")]
        // [MinLength(2, ErrorMessage = "Username is too short")]
        // public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        [Display(Name = "Building Number")]
        public string StreetNumber { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePic { get; set; }

        [NotMapped]
        public IFormFile files { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Relationships
        [InverseProperty("Follower")]
        List<UserList> Following { get; set; } //M2M with List<UserList> Followers

        [InverseProperty("Following")]
        List<UserList> Followers { get; set; } // M2M with List<UserList> Following

        List<GarageList> Favorites { get; set; } // M2M with GarageSale FavedBy
        List<GarageSale> GarageSales { get; set; } // O2M with GarageSale Creator

        [InverseProperty("Reviewer")]
        List<Review> Reviews { get; set; } // O2M with Reviews, given

        [InverseProperty("Reviewed")]
        List<Review> UserReviews { get; set; } // O2M with Reviews, received

        public Feedback FeedbackMessage { get; set; }  // O2O with Feedback
    }
}