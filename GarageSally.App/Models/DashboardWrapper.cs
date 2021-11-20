namespace UserLogin.Models
{
    public class DashboardWrapper
    {
        public User User { get; set; }

        public LoginUser LoginUser { get; set; }

        public GarageSale GarageSale { get; set; }

        public User AccountType { get; set; }
    }
}