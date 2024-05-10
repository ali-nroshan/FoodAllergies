using FoodAllergies.Application.DTOs.Allergies;
using FoodAllergies.Application.Features.Users.Requests.Commands;
using FoodAllergies.Application.Features.Users.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodAllergies.WebAPI.Controllers
{
    public class UsersController(IMediator mediator) : ApiBase
    {
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await mediator.Send(new GetUsersQuery());
            return response.Match(Ok, HandleProblems);
        }

        [HttpGet("IsUserAllergic")]
        public async Task<IActionResult> IsUserAllergic([FromQuery] AllergyDto allergyDto)
        {
            var response = await mediator.Send(new IsUserAllergicQuery(allergyDto));
            return response.Match(success => Ok(success), HandleProblems);
        }

        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser()
        {
            var response = await mediator.Send(new CreateUserCommand());
            return response.Match(success => Ok(success), HandleProblems);
        }

        [HttpPost("AddUserAllergics")]
        public async Task<IActionResult> AddUserAllergics([FromQuery] int userId, [FromBody] int[] ingredientsId)
        {
            var response = await mediator.Send(new AddUserAllergiesCommand(new AddAllergyDto(userId, ingredientsId)));
            return response.Match(success => Ok(), HandleProblems);
        }
    }
}