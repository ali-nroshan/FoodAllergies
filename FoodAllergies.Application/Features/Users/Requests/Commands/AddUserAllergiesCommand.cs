using ErrorOr;
using FoodAllergies.Application.DTOs.Allergies;
using MediatR;

namespace FoodAllergies.Application.Features.Users.Requests.Commands;

public record AddUserAllergiesCommand(AddAllergyDto AddAllergyDto) : IRequest<ErrorOr<Unit>>;