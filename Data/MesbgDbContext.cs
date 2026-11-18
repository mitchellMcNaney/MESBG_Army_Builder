using Microsoft.EntityFrameworkCore;
using Mesbg.Api.Models;

namespace Mesbg.Api.Data;
public class MesbgDbContext : DbContext
{
    public MesbgDbContext(DbContextOptions<MesbgDbContext> options) : base(options)
    {
    }

    public DbSet<Unit> Unit {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Unit>().ToTable("unit");
    }
}     