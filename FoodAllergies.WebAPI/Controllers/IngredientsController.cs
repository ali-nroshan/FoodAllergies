using FoodAllergies.Application.DTOs.Ingredients;
using FoodAllergies.Application.Features.Ingredients.Requests.Commands;
using FoodAllergies.Application.Features.Ingredients.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodAllergies.WebAPI.Controllers;

public class IngredientsController(IMediator mediator) : ApiBase
{
    [HttpGet("GetIngredients")]
    public async Task<IActionResult> GetIngredients()
    {
        var response = await mediator.Send(new GetIngredientsQuery());
        return response.Match(Ok, HandleProblems);
    }

    [HttpPost("NewIngredient")]
    public async Task<IActionResult> NewIngredient([FromBody] AddIngredientDto addIngredientDto)
    {
        var response = await mediator.Send(new AddIngredientCommand(addIngredientDto));
        return response.Match(Ok, HandleProblems);
    }
}