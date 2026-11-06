using EFCore04.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore04.Config
{
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(x => new { x.CustomerId, x.AccountNumber });
            builder.Property(x => x.OwnershipType).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.AccountStatus).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.OwnershipStartDate).HasColumnType("date");

            builder.HasOne(x => x.Customer).WithMany(c => c.CustomerAccounts)
             .HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Account).WithMany(a => a.CustomerAccounts)
             .HasForeignKey(x => x.AccountNumber).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
