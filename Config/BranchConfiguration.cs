using EFCore04.Contexts;
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
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Code).HasMaxLength(10);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();

            builder.HasOne(b => b.Manager)
             .WithOne(m => m.Branch)
             .HasForeignKey<Branch>(b => b.ManagerId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(b => b.ManagerId).IsUnique();

            builder.HasData(SeedData.Branches);

        }
    }
}
