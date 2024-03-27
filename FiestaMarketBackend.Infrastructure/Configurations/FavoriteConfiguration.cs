using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasMany(f => f.Products).WithMany(p => p.Favorites);
            builder.HasOne(f => f.User).WithOne(p => p.Favorite).HasForeignKey<Favorite>(f => f.UserId);
        }
    }
}
