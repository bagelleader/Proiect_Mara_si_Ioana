using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Models;



namespace MuntiRomania.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<MountainRange> MountainRanges => Set<MountainRange>();
    public DbSet<Trail> Trails => Set<Trail>();
    public DbSet<PointOfInterest> PointsOfInterest => Set<PointOfInterest>();
    public DbSet<TrailPoint> TrailPoints => Set<TrailPoint>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TrailPoint>()
            .HasKey(tp => new { tp.TrailId, tp.PointOfInterestId });

        builder.Entity<TrailPoint>()
            .HasOne(tp => tp.Trail)
            .WithMany(t => t.TrailPoints)
            .HasForeignKey(tp => tp.TrailId);

        builder.Entity<TrailPoint>()
            .HasOne(tp => tp.PointOfInterest)
            .WithMany(p => p.TrailPoints)
            .HasForeignKey(tp => tp.PointOfInterestId);
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
