using FitnessApp.Core.ResourceAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace FitnessApp.Core.ResourceAccess.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<UserLoginActivityModel> UserLoginActivities { get; set; }
    }
}
