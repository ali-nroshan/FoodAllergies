using ErrorOr;
using FoodAllergies.Application.Contracts.Persistence;
using FoodAllergies.Application.Features.Users.Requests.Commands;
using FoodAllergies.Domain.Common.Errors;
using MediatR;

namespace FoodAllergies.Application.Features.Users.Handlers.Commands;

public class AddUserAllergiesCommandHandler(IUserRepository userRepository) : IRequestHandler<AddUserAllergiesCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(AddUserAllergiesCommand request, CancellationToken cancellationToken)
    {
        if (request.AddAllergyDto.UserId < 1)
            return Errors.User.UserNotFound;

        foreach (int ingredientId in request.AddAllergyDto.IngredientsId)
        {
            if (ingredientId < 1) continue;

            await userRepository.AddUserAllergyAsync(request.AddAllergyDto.UserId, ingredientId);
        }

        await userRepository.SaveChangesAsync();
        return Unit.Value;
    }
}