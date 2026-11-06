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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.AccountNumber);
            builder.Property(x => x.AccountNumber).HasMaxLength(20);
            builder.Property(x => x.CurrentBalance).HasColumnType("decimal(18,2)");
            builder.Property(x => x.AccountType).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.OpeningDate).HasColumnType("date");

            builder.HasOne(a => a.Branch)
             .WithMany(b => b.Accounts)
             .HasForeignKey(a => a.BranchCode)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
