using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder
                .HasMany(p => p.Images)
                .WithOne(i => i.Product);

            builder
                .HasOne(p => p.Description)
                .WithOne(d => d.Product);

            builder
                .HasOne(a => a.Category)
                .WithMany(c => c.Products);
        }
    }
}
