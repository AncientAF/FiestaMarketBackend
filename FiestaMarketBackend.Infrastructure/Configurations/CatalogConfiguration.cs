using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.HasKey(c => c.Id);

            //builder
            //    .HasMany(c => c.Images)
            //    .WithOne(c => c.Catalog);
            builder.OwnsMany(c => c.Images);
        }
    }
}
