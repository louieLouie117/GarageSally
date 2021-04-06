using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin.Models
{
    public enum AccountType { Buyer, Seller }
    public class User
    {
        [Key]
        public int UserId { get; set; }

        // Value comes from enum defined above, enum type is referenced like a class
        // Values are Zero indexed so base datatype is "int" in DB
        public AccountType AccountType { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name cannot be empty")]
        [MinLength(2, ErrorMessage = "First name is too short")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name cannot be empty")]
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

        // Will not be mapped to your users table!
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        [Display(Name = "Building Number")]
        // [Required]
        public int StreetNumber { get; set; }

        // [DefaultValue("n/a")]
        [Display(Name = "Street Name")]
        // [Required]
        public string StreetName { get; set; }

        // [Required]
        // [DefaultValue("n/a")]
        public string City { get; set; }

        // [Required]
        public int Zipcode { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePic { get; set; }

        [NotMapped]
        public IFormFile files { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Relationships
        [InverseProperty("Follower")]
        List<UserList> Following { get; set; } // who the user is following M2M (other end of vvv)

        [InverseProperty("Following")]
        List<UserList> Followers { get; set; } // who is following the user M2M (other end of ^^^)
        List<GarageList> Favorites { get; set; } // matches list of FavedBy in GarageSale M2M FIX!!!!
        List<GarageSale> GarageSales { get; set; } //matches Creator in GarageSale O2M

        [InverseProperty("Reviewer")]
        List<Review> Reviews { get; set; } // list of Reviews made O2M

        [InverseProperty("Reviewed")]
        List<Review> UserReviews { get; set; } // list of Reviews left O2M
    }
}