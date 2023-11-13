using Mc2.CrudTest.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Numerics;

namespace Mc2.CrudTest.Persistence.EntityFramework.Customers.EntityConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(p => p.Firstname).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Lastname).IsRequired().HasMaxLength(250);
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.OwnsOne(p => p.PhoneNumber, o =>
            {
                o.Property(q => q.Number).HasColumnName("PhoneNumber").IsRequired(true).HasMaxLength(15);
            });
            builder.OwnsOne(p => p.Email, o =>
            {
                o.Property(q => q.Address).HasColumnName("Email").IsRequired(true).IsUnicode();
            });
            builder.OwnsOne(p => p.BankAccountNumber, o =>
            {
                o.Property(q => q.Number).HasColumnName("BankAccountNumber").IsRequired(true).HasMaxLength(20);
            });
            builder.HasIndex("Firstname", "Lastname", "DateOfBirth").IsUnique();

            builder.ToTable(nameof(Customer));
        }
    }
}
