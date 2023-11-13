using Mc2.CrudTest.Persistence.EntityFramework.Customers.EntityConfigurations;
using Mc2.CrudTest.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence.EntityFramework
{
    public class Mc2CrudTestDbContext : DbContext
    {
        public Mc2CrudTestDbContext(DbContextOptions<Mc2CrudTestDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Customer> Customers { get; set; }=null!;
    }
}
