using ErrorOr;
using MediatR;

namespace FoodAllergies.Application.Features.Users.Requests.Commands;

public record CreateUserCommand() : IRequest<ErrorOr<int>>;