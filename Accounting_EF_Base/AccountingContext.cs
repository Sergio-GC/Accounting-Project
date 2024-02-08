using EF_DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Accounting_EF_Base
{
    public class AccountingContext : DbContext
    {
        // Configuration containing the connection string
        private readonly IConfiguration _configuration;

        // DbSets to generate/manage the entities in the database automatically
        public DbSet<Kid> Kids { get; set; }
        public DbSet<SiblingRelationship> Siblings { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<CalendarEntry> CalendarEntries { get; set; }

        public AccountingContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Set the relationship between Kid and SiblingRelationship right, as EF doesn't automatically know how to manage many to many links
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set id to the Id property of SiblingRelationship
            modelBuilder.Entity<SiblingRelationship>()
                .HasKey(sr => sr.Id);

            // Set Kid1 to be one to many (each SiblingRelationship corresponds to 1 Kid, but 1 Kid can have many SiblingRelationship's)
            modelBuilder.Entity<SiblingRelationship>()
                .HasOne(sr => sr.Kid1)
                .WithMany(k => k.Siblings)
                .HasForeignKey(sr => sr.KidId1)
                .OnDelete(DeleteBehavior.Cascade);

            // Do the same for Kid2
            modelBuilder.Entity<SiblingRelationship>()
                .HasOne(sr => sr.Kid2)
                .WithMany()
                .HasForeignKey(sr => sr.KidId2)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
            builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection")!);
        }
    }
}
