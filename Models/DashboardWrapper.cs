using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UserLogin.Models
{
    public class DashboardWrapper
    {
        public User User { get; set; }
        public LoginUser LoginUser { get; set; }

        public GarageSale GarageSale { get; set; }


    }
}