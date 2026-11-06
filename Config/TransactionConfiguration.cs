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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.TransactionNumber);
            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Note).HasMaxLength(250);
            builder.Property(x => x.TransactionType).HasConversion<string>().HasMaxLength(20);

            builder.HasOne(t => t.Account).WithMany(a => a.Transactions)
             .HasForeignKey(t => t.AccountNumber).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
