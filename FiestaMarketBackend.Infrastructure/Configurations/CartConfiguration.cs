﻿using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsMany(c => c.Items, owned =>
                                        {
                                            owned.HasOne(i => i.Product).WithMany().HasForeignKey(i => i.ProductId);
                                        });
            builder.HasOne(c => c.User).WithOne(p => p.Cart).HasForeignKey<Cart>(c => c.UserId);
        }
    }
}
