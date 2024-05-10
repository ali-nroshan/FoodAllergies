namespace FoodAllergies.Domain.Entities;

public record Food(string FoodName)
{
    public int FoodId { get; init; }
}