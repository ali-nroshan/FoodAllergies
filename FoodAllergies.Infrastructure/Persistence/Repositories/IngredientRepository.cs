using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Domain.Entities;
using FoodAllergies.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FoodAllergies.Infrastructure.Persistence.Repositories;

public class IngredientRepository(FoodAllergiesDbContext dbContext) : IIngredientRepository
{
    public async Task AddIngredientAsync(Ingredient ingredient)
    {
        await dbContext.Ingredients.AddAsync(ingredient);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
    {
        return await dbContext.Ingredients.ToListAsync();
    }

    public async Task<bool> IsIngredientExistAsync(int ingredientId)
    {
        return await dbContext.Ingredients.AnyAsync(i => i.IngredientId == ingredientId);
    }

    public async Task<bool> IsIngredientExistAsync(string ingredientName)
    {
        return await dbContext.Ingredients.AnyAsync(i => i.IngredientName == ingredientName);
    }
}