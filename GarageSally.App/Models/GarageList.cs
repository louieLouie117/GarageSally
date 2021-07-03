using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class GarageList
    {
        [Key]
        public int GarageListId { get; set; }

        public int UserId { get; set; }

        public int GarageSaleId { get; set; }

        // Middle table: Relationships
        public User Favoriter { get; set; }
        public GarageSale Favorite { get; set; }
    }
}