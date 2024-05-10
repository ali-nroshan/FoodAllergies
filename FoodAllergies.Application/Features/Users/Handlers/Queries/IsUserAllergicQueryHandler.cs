using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.Features.Users.Requests.Queries;
using FoodAllergies.Domain.Common.Errors;
using MediatR;

namespace FoodAllergies.Application.Features.Users.Handlers.Queries;

public class IsUserAllergicQueryHandler(IUserRepository userRepository) : IRequestHandler<IsUserAllergicQuery, ErrorOr<bool>>
{
    public async Task<ErrorOr<bool>> Handle(IsUserAllergicQuery request, CancellationToken cancellationToken)
    {
        if (request.AllergyDto.UserId < 1 || request.AllergyDto.FoodId < 1)
            return Errors.User.UserNotFound;

        return await userRepository.IsUserAllergicToFoodAsync(request.AllergyDto.UserId, request.AllergyDto.FoodId);
    }
}