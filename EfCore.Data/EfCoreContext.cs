using EfCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; 
        }

        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=ScenarioAppData");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(b => new { b.ProductId, b.Entity, b.Year });

            });

            modelBuilder.Entity<Scenario>(p =>
            {

                p.HasKey(b => b.Id);

                p.Property(b => b.Id).IsRequired();
                p.Property(b => b.Year).IsRequired();
                p.Property(b => b.EntityCode).IsRequired();
                p.Property(b => b.Name).IsRequired();

                p.HasMany(b => b.Details)
                .WithOne()
                .HasForeignKey(c => c.ScenarioId)
                .HasConstraintName("FK_Scenario_Details");

            });

            modelBuilder.Entity<Detail>(d =>
            {
                d.HasKey(b => b.Id);

                d.Property(b => b.Id).IsRequired();
                d.Property(b => b.Description).IsRequired();

                d.Ignore(b => b.EntityCode);
                d.Ignore(b => b.Year);


                d.HasOne(b => b.Product)
                .WithMany()
                .HasForeignKey(b => new { b.ProductId, b.EntityCode, b.Year });

                //d.HasOne(b => b.Scenario)
                //.WithMany()
                //.HasForeignKey(b => b.ScenarioId);

            });
        }

    }
}
