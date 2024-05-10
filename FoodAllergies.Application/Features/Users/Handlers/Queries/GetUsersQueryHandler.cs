using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.DTOs.Users;
using FoodAllergies.Application.Features.Users.Requests.Queries;
using Mapster;
using MediatR;

namespace FoodAllergies.Application.Features.Users.Handlers.Queries;

public class GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, ErrorOr<IEnumerable<UserDto>>>
{
    public async Task<ErrorOr<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return (await userRepository.GetUsersAsync()).Adapt<List<UserDto>>();
    }
}