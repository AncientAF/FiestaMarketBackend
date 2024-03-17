using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder
                .HasOne(c => c.ParentCategory)
                .WithMany(p => p.SubCategories);
            builder
                .HasMany(p => p.SubCategories)
                .WithOne(c => c.ParentCategory);
        }
    }
}
