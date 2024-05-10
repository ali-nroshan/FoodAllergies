using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.DTOs.Ingredients;
using FoodAllergies.Application.Features.Ingredients.Requests.Commands;
using FoodAllergies.Domain.Common.Errors;
using FoodAllergies.Domain.Entities;
using Mapster;
using MediatR;

namespace FoodAllergies.Application.Features.Ingredients.Handlers.Commands
{
    public class AddIngredientCommandHandler(IIngredientRepository ingredientRepository) : IRequestHandler<AddIngredientCommand, ErrorOr<IngredientDto>>
    {
        public async Task<ErrorOr<IngredientDto>> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
            if (await ingredientRepository.IsIngredientExistAsync(request.AddIngredientDto.IngredientName))
                return Errors.Ingredient.DuplicateIngredient;

            Ingredient newIngredient = new(request.AddIngredientDto.IngredientName);

            await ingredientRepository.AddIngredientAsync(newIngredient);

            return newIngredient.Adapt<IngredientDto>();
        }
    }
}