using FinancialRevenues.Lookups;
using FinancialRevenues.Lookups.Seed;
using FinancialRevenues.Revenues.Entities;
using FinancialRevenues.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinancialRevenues.DbContexts;

public class FinancialRevenuesDbContext : IdentityDbContext<User, IdentityRole<long>, long>
{
    public FinancialRevenuesDbContext(DbContextOptions<FinancialRevenuesDbContext> options): base(options)
    {
    }

    public DbSet<User?> Users { get; set; }
    public DbSet<IdentityRole<int>> Roles { get; set; }
    public DbSet<Governorate> Governorates { get; set; }
    public DbSet<Revenue> Revenues { get; set; }
    public DbSet<RevenueType> RevenueTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RevenueType>()
            .HasKey(e => e.Id);
        builder.Entity<Revenue>()
            .HasKey(e => e.Id);
        builder.Entity<Governorate>()
            .HasKey(e => e.Id);
        builder.Entity<RevenueType>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        builder.Entity<Revenue>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        builder.Entity<Governorate>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        base.OnModelCreating(builder);
    }
}