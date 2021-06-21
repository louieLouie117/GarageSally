using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class UserList
    {
        [Key]
        public int UserListId { get; set; }

        public int FollowerId { get; set;}

        public int FollowingId { get; set; }

        //Middle table: Relationships
        public User Follower { get; set; }
        public User Following {get; set; }
    }
}