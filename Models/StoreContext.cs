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

        public StoreContext(DbContextOptions<StoreContext> options)

            : base(options)

        {

        }

    }
}
