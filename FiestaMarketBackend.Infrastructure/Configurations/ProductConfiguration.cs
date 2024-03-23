﻿using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            //builder
            //    .HasMany(p => p.Images)
            //    .WithOne(i => i.ProductId);
            builder.OwnsMany(p => p.Images);


            //builder
            //    .HasOne(p => p.DescriptionId)
            //    .WithOne(d => d.ProductId);
            builder.OwnsOne(p => p.Description);

            builder
                .HasOne(a => a.Category);
        }
    }
}
