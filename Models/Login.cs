using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class LoginUser
    {
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}