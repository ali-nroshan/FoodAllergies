using ErrorOr;
using FoodAllergies.Application.DTOs.Allergies;
using MediatR;

namespace FoodAllergies.Application.Features.Users.Requests.Queries;

public record IsUserAllergicQuery(AllergyDto AllergyDto) : IRequest<ErrorOr<bool>>;