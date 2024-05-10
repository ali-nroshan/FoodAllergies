using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.DTOs.Foods;
using FoodAllergies.Application.Features.Foods.Requests.Commands;
using FoodAllergies.Domain.Common.Errors;
using FoodAllergies.Domain.Entities;
using Mapster;
using MediatR;

namespace FoodAllergies.Application.Features.Foods.Handlers.Commands;

public class CreateFoodCommandHandler(IFoodRepository foodRepository) : IRequestHandler<CreateFoodCommand, ErrorOr<FoodDto>>
{
    public async Task<ErrorOr<FoodDto>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
        if (await foodRepository.IsFoodExist(request.CreateFoodDto.FoodName))
            return Errors.Food.DuplicateFood;

        var food = new Food(request.CreateFoodDto.FoodName);
        await foodRepository.AddFood(food);

        return food.Adapt<FoodDto>();
    }
}