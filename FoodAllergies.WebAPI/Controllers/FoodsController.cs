using FoodAllergies.Application.DTOs.Foods;
using FoodAllergies.Application.Features.Foods.Requests.Queries;
using FoodAllergies.Application.Features.Foods.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodAllergies.WebAPI.Controllers
{
    public class FoodsController(IMediator mediator) : ApiBase
    {
        [HttpGet("GetFoods")]
        public async Task<IActionResult> GetFoods()
        {
            var response = await mediator.Send(new GetFoodsQuery());
            return response.Match(Ok, HandleProblems);
        }

        [HttpGet("GetFoodIngredients")]
        public async Task<IActionResult> GetFoodIngredients([FromQuery] int foodId)
        {
            var response = await mediator.Send(new GetFoodIngredientsQuery(foodId));
            return response.Match(Ok, HandleProblems);
        }

        [HttpPost("CreateNewFood")]
        public async Task<IActionResult> CreateNewFood([FromBody] CreateFoodDto createFoodDto)
        {
            var response = await mediator.Send(new CreateFoodCommand(createFoodDto));
            return response.Match(Ok, HandleProblems);
        }

        [HttpPost("AddFoodIngredients")]
        public async Task<IActionResult> AddFoodIngredients([FromBody] FoodIngredientsDto foodIngredientsDto)
        {
            var response = await mediator.Send(new AddFoodIngredientsCommand(foodIngredientsDto));
            return response.Match(s => Ok(), HandleProblems);
        }
    }
}