using Microsoft.EntityFrameworkCore;

namespace UserLogin.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<GarageSale> GarageSales { get; set; }
        public DbSet<Review> Reviews { get; set; }

        // Middle table
        public DbSet<UserList> UserLists { get; set; }
        public DbSet<GarageList>  GarageLists { get; set; }
    }
}
