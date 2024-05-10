using FoodAllergies.Domain.Entities;

namespace FoodAllergies.Application.Contracts.Persistence;

public interface IIngredientRepository
{
    Task<bool> IsIngredientExistAsync(int ingredientId);
    Task<bool> IsIngredientExistAsync(string ingredientName);
    Task AddIngredientAsync(Ingredient ingredient);
    Task<IEnumerable<Ingredient>> GetIngredientsAsync();
}