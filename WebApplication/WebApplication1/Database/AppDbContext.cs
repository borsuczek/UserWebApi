using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    // DbContext class representing the database context
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add data to the User table
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "user1@user.com", Name = "Peter", Phone = "222 333 444" }); 
            modelBuilder.Entity<User>().HasData(new User { Id = 2, Email = "john123@jn", Name = "John", Phone = "184 726 334" });
            modelBuilder.Entity<User>().HasData(new User { Id = 3, Email = "kks@gmail.com", Name = "Kate", Phone = "646 388 374" });
            modelBuilder.Entity<User>().HasData(new User { Id = 4, Email = "ann@ann", Name = "Ann", Phone =  "289 839 884" });
        }

        public DbSet<User> Users { get; set; }
    }
}
