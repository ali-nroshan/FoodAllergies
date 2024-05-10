using FoodAllergies.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodAllergies.Infrastructure.Persistence.Contexts;

public class FoodAllergiesDbContext(DbContextOptions<FoodAllergiesDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergy>()
            .HasKey(a => new { a.IngredientId, a.UserId });

        modelBuilder.Entity<FoodToIngredient>()
            .HasKey(fi => new { fi.IngredientId, fi.FoodId });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodToIngredient> FoodToIngredients { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Allergy> Allergies { get; set; }
}