using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.Features.Users.Requests.Commands;
using FoodAllergies.Domain.Entities;
using MediatR;

namespace FoodAllergies.Application.Features.Users.Handlers.Commands;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, ErrorOr<int>>
{
    public async Task<ErrorOr<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        int userId = await userRepository.AddUserAsync(new User());
        return userId;
    }
}