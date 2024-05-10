using FoodAllergies.Domain.Entities;

namespace FoodAllergies.Application.Contracts.Persistence;

public interface IFoodRepository
{
    Task<bool> IsFoodExist(int foodId);
    Task<int[]> GetFoodIngredients(int foodId);
    Task AddFood(Food food);
    Task<bool> IsFoodExist(string foodName);
    Task AddIngredientsToFood(int foodId, int[] ingredientsId);
    Task<IEnumerable<Food>> GetFoodsAsync();
}