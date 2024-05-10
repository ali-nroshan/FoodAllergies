using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.DTOs.Ingredients;
using FoodAllergies.Application.Features.Ingredients.Requests.Queries;
using Mapster;
using MediatR;

namespace FoodAllergies.Application.Features.Ingredients.Handlers.Queries
{
    public class GetIngredientsQueryHandler(IIngredientRepository ingredientRepository) : IRequestHandler<GetIngredientsQuery, ErrorOr<IEnumerable<IngredientDto>>>
    {
        public async Task<ErrorOr<IEnumerable<IngredientDto>>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
        {
            var ingredients = await ingredientRepository.GetIngredientsAsync();
            return ingredients.Adapt<List<IngredientDto>>();
        }
    }
}