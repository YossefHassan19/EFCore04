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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NationalId).HasMaxLength(14).IsRequired();
            builder.HasIndex(x => x.NationalId).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnType("date");
            builder.Property(x => x.CustomerType).HasConversion<string>().HasMaxLength(20);
        }
    }
}
