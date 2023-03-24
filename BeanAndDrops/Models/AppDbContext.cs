using BeanAndDrops.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeanAndDrops.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public virtual DbSet<Product> products { get; set; }

        public virtual DbSet<Category> category { get; set; }


        //public virtual DbSet<Customer> customer { get; set; }

        //public virtual DbSet<Order> order { get; set; }

    }
}
