using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> option): base(option) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
