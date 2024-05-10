namespace FoodAllergies.Application.DTOs.Allergies;

public record AddAllergyDto(int UserId, int[] IngredientsId);