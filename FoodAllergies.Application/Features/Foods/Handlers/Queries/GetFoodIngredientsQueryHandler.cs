using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.DTOs.Foods;
using FoodAllergies.Application.Features.Foods.Requests.Queries;
using FoodAllergies.Domain.Common.Errors;
using MediatR;

namespace FoodAllergies.Application.Features.Foods.Handlers.Queries;

public class GetFoodIngredientsQueryHandler(IFoodRepository foodRepository) : IRequestHandler<GetFoodIngredientsQuery, ErrorOr<FoodIngredientsDto>>
{
    public async Task<ErrorOr<FoodIngredientsDto>> Handle(GetFoodIngredientsQuery request, CancellationToken cancellationToken)
    {
        if (!await foodRepository.IsFoodExist(request.FoodId))
            return Errors.Food.FoodNotFound;

        var foodIngredients = await foodRepository.GetFoodIngredients(request.FoodId);

        return new FoodIngredientsDto(request.FoodId, foodIngredients);
    }
}