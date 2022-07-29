using Microsoft.EntityFrameworkCore;
using testProjectBackend.Models;

namespace testProjectBackend.DbContext
{
    public class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {}
        
        public DbSet<User> Users { get; set; }
        public DbSet<BookMark> BookMarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}