﻿using CustomerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerAPI.Data
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "dbo");

            #region [ Primitive members ]
            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Created)
                .IsRequired();
            builder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(p => p.Note)
                .HasMaxLength(2000);
            builder
                .Property(p => p.Active)
                .IsRequired();
            #endregion

            #region [ Relationships members ]
            #endregion
        }
    }
}
