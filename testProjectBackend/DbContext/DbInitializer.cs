using System;
using Microsoft.EntityFrameworkCore;
using testProjectBackend.Models;

namespace testProjectBackend.DbContext
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<User>().HasData(new User { Id =  Guid.NewGuid(), Email = "demo@gmail.com", Password = "Test123!" });
        }
    }
}