using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Domain.Entities;
using FoodAllergies.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FoodAllergies.Infrastructure.Persistence.Repositories;

public class FoodRepository(FoodAllergiesDbContext dbContext) : IFoodRepository
{
    public async Task AddFood(Food food)
    {
        await dbContext.Foods.AddAsync(food);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddIngredientsToFood(int foodId, int[] ingredientsId)
    {
        foreach (int ingredientId in ingredientsId)
        {
            await dbContext.FoodToIngredients.AddAsync(new FoodToIngredient(foodId, ingredientId));
        }
        await dbContext.SaveChangesAsync();
    }

    public async Task<int[]> GetFoodIngredients(int foodId)
    {
        return await dbContext.FoodToIngredients.Where(f => f.FoodId == foodId).Select(f => f.IngredientId).ToArrayAsync();
    }

    public async Task<IEnumerable<Food>> GetFoodsAsync()
    {
        return await dbContext.Foods.ToListAsync();
    }

    public async Task<bool> IsFoodExist(int foodId)
    {
        return await dbContext.Foods.AnyAsync(f => f.FoodId == foodId);
    }

    public async Task<bool> IsFoodExist(string foodName)
    {
        return await dbContext.Foods.AnyAsync(f => f.FoodName == foodName);
    }
}