using ErrorOr;

namespace FoodAllergies.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error UserNotFound => Error.NotFound("User.NotFound");
    }
}