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

            //builder.HasOne(u => u.Cart).WithOne(c => c.User).HasForeignKey<Cart>(c => c.UserId);
            //builder.HasOne(u => u.Favorite).WithOne(f => f.User).HasForeignKey<Favorite>(c => c.UserId);

            builder.HasOne(u => u.Cart).WithOne(c => c.User);
            builder.HasOne(u => u.Favorite).WithOne(f => f.User);

            builder.OwnsMany(u => u.Addresses).WithOwner().HasForeignKey(a => a.UserId);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasMany(u => u.Roles).WithMany(r => r.Users);
        }
    }
}
