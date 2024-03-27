using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.OwnsOne(o => o.Address);

            //builder.OwnsMany(o => o.Items, owned =>
            //                            {
            //                                owned.HasOne<Product>().WithMany().HasForeignKey(o => o.ProductId);
            //                            });

            builder.OwnsMany(o => o.Items);

            builder.HasOne(o => o.User).WithMany(u => u.Orders);
        }
    }
}
