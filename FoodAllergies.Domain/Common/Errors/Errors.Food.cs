using ErrorOr;

namespace FoodAllergies.Domain.Common.Errors;

public static partial class Errors
{
    public static class Food
    {
        public static Error FoodNotFound => Error.NotFound("Food.NotFound");
        public static Error DuplicateFood => Error.Conflict("Food.Duplicate");
    }
}