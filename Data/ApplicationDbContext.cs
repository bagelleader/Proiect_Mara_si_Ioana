using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuntiRomania.Models;


namespace MuntiRomania.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<MountainRange> MountainRanges => Set<MountainRange>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
