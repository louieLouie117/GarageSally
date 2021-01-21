using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin.Models
{
    public class UserList
    {
        [Key]
        public int UserListId { get; set; }

        public int UserId { get; set;} // Follower

        public int UserId2 { get; set; } // Following

        //Relationships
        public User Follower { get; set; }
        public User Following {get; set; }
    }
}