using AppointmentBooking.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<SalesManager> SalesManagers { get; set; }
    public DbSet<Slot> Slots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SalesManager>(entity =>
        {
            entity.ToTable("sales_managers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Languages).HasColumnName("languages");
            entity.Property(e => e.Products).HasColumnName("products");
            entity.Property(e => e.CustomerRatings).HasColumnName("customer_ratings"); 
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.ToTable("slots");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StartDate).HasColumnName("start_date")
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); ;
            entity.Property(e => e.EndDate).HasColumnName("end_date")
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); ;
            entity.Property(e => e.Booked).HasColumnName("booked");
            entity.Property(e => e.SalesManagerId).HasColumnName("sales_manager_id");
        });
    }

}