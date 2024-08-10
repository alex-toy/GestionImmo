using GestionImmo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionImmo.Repo;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Building> BuildingDb { get; set; }
    public DbSet<Site> SiteDb { get; set; }
}