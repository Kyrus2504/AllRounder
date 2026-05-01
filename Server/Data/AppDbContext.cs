using Microsoft.EntityFrameworkCore;
using Shared;

namespace Server.Data;





public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Meal> Meals {get; set;}
    public DbSet<Workout> Workouts {get; set;}
    public DbSet<FitnessEntry> FitnessEntries {get; set;}
}
