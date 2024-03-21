using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Orders).WithOne(o => o.User);

            builder.HasOne(u => u.Cart);
            builder.HasOne(u => u.Favorite);

            builder.OwnsMany(u => u.Addresses);

        }
    }
}
