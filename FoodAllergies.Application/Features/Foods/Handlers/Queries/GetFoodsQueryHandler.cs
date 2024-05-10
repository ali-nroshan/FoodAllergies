using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.DTOs.Foods;
using FoodAllergies.Application.Features.Foods.Requests.Queries;
using Mapster;
using MediatR;

namespace FoodAllergies.Application.Features.Foods.Handlers.Queries;

public class GetFoodsQueryHandler(IFoodRepository foodRepository) : IRequestHandler<GetFoodsQuery, ErrorOr<IEnumerable<FoodDto>>>
{
    public async Task<ErrorOr<IEnumerable<FoodDto>>> Handle(GetFoodsQuery request, CancellationToken cancellationToken)
    {
        return (await foodRepository.GetFoodsAsync()).Adapt<List<FoodDto>>();
    }
}