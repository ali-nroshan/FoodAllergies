using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Domain.Entities;
using FoodAllergies.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FoodAllergies.Infrastructure.Persistence.Repositories;

public class UserRepository(FoodAllergiesDbContext dbContext) : IUserRepository
{
    public async Task<int> AddUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();

        return user.UserId;
    }

    public async Task<bool> IsUserExistAsync(int userId)
    {
        return await dbContext.Users.AnyAsync(u => u.UserId == userId);
    }

    public async Task AddUserAllergiesAsync(int userId, params int[] ingredientsId)
    {
        foreach (int ingredientId in ingredientsId)
            await dbContext.Allergies.AddAsync(new Allergy(userId, ingredientId));

        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsUserAllergicToFoodAsync(int userId, int foodId)
    {
        string query = $"SELECT TOP 1 a.UserId, fi.FoodId as IngredientId FROM Allergies as a JOIN FoodToIngredients as fi ON a.IngredientId = fi.IngredientId AND a.UserId = {userId} AND fi.FoodId = {foodId}";
        var result = await dbContext.Allergies.FromSqlRaw(query).AnyAsync();
        return result;
    }

    public async Task AddUserAllergyAsync(int userId, int ingredientId)
    {
        await dbContext.Allergies.AddAsync(new Allergy(userId, ingredientId));
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await dbContext.Users.ToListAsync();
    }
}