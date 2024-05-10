using ErrorOr;
using FoodAllergies.Application.DTOs.Ingredients;
using MediatR;

namespace FoodAllergies.Application.Features.Ingredients.Requests.Commands;

public record AddIngredientCommand(AddIngredientDto AddIngredientDto) : IRequest<ErrorOr<IngredientDto>>;