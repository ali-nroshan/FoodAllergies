using ErrorOr;
using FoodAllergies.Application.DTOs.Foods;
using MediatR;

namespace FoodAllergies.Application.Features.Foods.Requests.Commands;
public record AddFoodIngredientsCommand(FoodIngredientsDto FoodIngredientsDto) : IRequest<ErrorOr<Unit>>;