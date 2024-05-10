using FoodAllergies.Domain.Entities;

namespace FoodAllergies.Application.Contracts.Persistence;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<bool> IsUserExistAsync(int userId);
    Task<int> AddUserAsync(User user);
    Task AddUserAllergiesAsync(int userId, params int[] ingredientsId);
    Task<bool> IsUserAllergicToFoodAsync(int userId, int foodId);
    Task AddUserAllergyAsync(int userId, int ingredientId); 
    Task SaveChangesAsync();
}