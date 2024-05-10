using ErrorOr;
using FoodAllergies.Application.DTOs.Ingredients;
using MediatR;

namespace FoodAllergies.Application.Features.Ingredients.Requests.Queries;

public record GetIngredientsQuery() : IRequest<ErrorOr<IEnumerable<IngredientDto>>>;