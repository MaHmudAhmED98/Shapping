using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shapping.Model;
using System.Reflection.Emit;

namespace Shapping.Model
{
    public class ShapingContext : IdentityDbContext<AppUser>
    {
        public ShapingContext(DbContextOptions<ShapingContext> options) : base(options)
        {

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<City> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Governorate> Governorates {  get; set; }
        public DbSet<City> Cities {  get; set; }
        public DbSet<SpecialPrice> SpecialPrices {  get; set; }
        public DbSet<Weight> Weights {  get; set; }
        public DbSet<Marchant> Marchants {  get; set; }


        public DbSet<ScreenPermission> ScreenPermissions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<AppUser>()
            //    .HasDiscriminator<string>("UserType")
            //    .HasValue<Marchant>("Merchant")
            //    .HasValue<Representative>("Representative");
            builder.Entity<Order>()
               .HasOne(o => o.Governorate)
               .WithMany(g => g.Orders)
               .HasForeignKey(o => o.GovernorateId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>()
                   .HasOne<Order>()
                   .WithMany(c => c.Products)
                   .HasForeignKey(e => e.Id);
            builder.Entity<Branches>()
              .HasMany(b => b.Orders).WithOne(c => c.Branches)
              .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<SpecialPrice>()
               .HasOne(s => s.Governorate)
               .WithMany(g => g.SpecialPrices)
               .HasForeignKey(s => s.GovernorateId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
