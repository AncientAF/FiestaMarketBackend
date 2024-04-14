using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Infrastructure.Authentication;
using FiestaMarketBackend.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FiestaMarketBackend.Infrastructure
{
    public class FiestaDbContext : DbContext
    {
        private readonly IOptions<AuthOptions> _AuthOptions;

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public FiestaDbContext(DbContextOptions<FiestaDbContext> options, IOptions<AuthOptions> authOptions)
            : base(options)
        {
            _AuthOptions = authOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CatalogConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            ////modelBuilder.ApplyConfiguration(new ImageConfiguration());
            //modelBuilder.ApplyConfiguration(new NewsConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //modelBuilder.ApplyConfiguration(new CartConfiguration());
            //modelBuilder.ApplyConfiguration(new FavoriteConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FiestaDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_AuthOptions.Value));

            base.OnModelCreating(modelBuilder);
        }
    }
}
