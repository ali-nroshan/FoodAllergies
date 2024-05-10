using ErrorOr;
using FoodAllergies.Application.DTOs.Users;
using MediatR;

namespace FoodAllergies.Application.Features.Users.Requests.Queries;

public record GetUsersQuery() : IRequest<ErrorOr<IEnumerable<UserDto>>>;