using ErrorOr;
using FoodAllergies.Application.DTOs.Foods;
using MediatR;

namespace FoodAllergies.Application.Features.Foods.Requests.Queries;

public record GetFoodsQuery() : IRequest<ErrorOr<IEnumerable<FoodDto>>>;