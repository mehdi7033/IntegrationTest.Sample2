using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    internal class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(p => p.Id);

            builder.Property(p=> p.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
