using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.Features.Foods.Requests.Commands;
using FoodAllergies.Domain.Common.Errors;
using MediatR;

namespace FoodAllergies.Application.Features.Foods.Handlers.Commands;

public class AddFoodIngredientsCommandHandler(IFoodRepository foodRepository, IIngredientRepository ingredientRepository) : IRequestHandler<AddFoodIngredientsCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(AddFoodIngredientsCommand request, CancellationToken cancellationToken)
    {
        if (!await foodRepository.IsFoodExist(request.FoodIngredientsDto.FoodId))
            return Errors.Food.FoodNotFound;

        foreach (int ingredientId in request.FoodIngredientsDto.IngredientsId)
        {
            if (!await ingredientRepository.IsIngredientExistAsync(ingredientId))
                return Errors.Ingredient.IngredientNotFound;
        }

        if (request.FoodIngredientsDto.IngredientsId.Length != 0)
            await foodRepository.AddIngredientsToFood(request.FoodIngredientsDto.FoodId, request.FoodIngredientsDto.IngredientsId);

        return Unit.Value;
    }
}