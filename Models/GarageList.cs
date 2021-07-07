using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin.Models
{
    public class GarageList
    {
        [Key]
        public int GarageListId { get; set; }

        public int UserId { get; set; }

        public int GarageSaleId { get; set; }

        //Relationships
        public User Favoriter { get; set; }
        public GarageSale Favorite { get; set; }
    }
}