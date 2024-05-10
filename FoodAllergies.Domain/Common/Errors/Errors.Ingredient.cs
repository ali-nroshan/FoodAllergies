using ErrorOr;

namespace FoodAllergies.Domain.Common.Errors;

public static partial class Errors
{
    public static class Ingredient
    {
        public static Error IngredientNotFound => Error.NotFound("Ingredient.NotFound");
        public static Error DuplicateIngredient => Error.Conflict("Ingredient.Duplicate");
    }
}