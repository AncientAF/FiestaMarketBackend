using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            //builder
            //    .HasOne(i => i.ProductId)
            //    .WithMany(p => p.Images);
            //builder
            //    .HasOne(i => i.CatalogId)
            //    .WithMany(c => c.Images);
        }
    }
}
