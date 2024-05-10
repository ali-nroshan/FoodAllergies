namespace FoodAllergies.Domain.Entities;

public record Ingredient(string IngredientName)
{
    public int IngredientId { get; init; }
}