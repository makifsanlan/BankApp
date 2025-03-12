using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable("CorporateCustomers");

        builder.HasKey(c => c.Id);
       

        builder.Property(c => c.CompanyName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.TaxNumber).HasMaxLength(10).IsRequired();
        builder.Property(c => c.TaxOffice).HasMaxLength(50).IsRequired();
        builder.Property(c => c.CompanyRegistrationNumber).HasMaxLength(50).IsRequired();
        builder.Property(c => c.AuthorizedPersonName).HasMaxLength(100).IsRequired();

        builder.HasIndex(c => c.TaxNumber).IsUnique();
        builder.HasIndex(c => c.CompanyRegistrationNumber).IsUnique();

       
    }
} 