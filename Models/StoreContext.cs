using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Models
{
    public class StoreContext : DbContext

    {

        public DbSet<Phone> Products { get; set; }
        public DbSet<Brend> Brends { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)

            : base(options)

        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "admin" });

            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "user" });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "admin@admin.admin", Password = "qwerty123", RoleId = 1 });

        }

    }
}
