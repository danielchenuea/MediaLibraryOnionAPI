

using MediaLibrary.Application.Features.BookFeatures.Queries;
using MediaLibrary.Application.Features.VideoGameFeatures.Commands;
using MediaLibrary.Application.Features.VideoGameFeatures.Queries;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MediaLibrary.API.Controllers;

/// <summary>
/// Api Controlling the videogames
/// </summary>
[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class VideoGamesApiController : ControllerBase
{
    public IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    /// <summary>
    /// Retrieves a list of videogames
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(VideoGame), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAll()
    {
        var videogames = await Mediator.Send(new GetAllVideoGamesQuery());

        return Ok(videogames);
    }

    /// <summary>
    /// Retrieves a specific videogame
    /// </summary>
    /// <param name="id">Id of the videogame</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(VideoGame), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var videogame = await Mediator.Send(new GetVideoGameByIdQuery { Id = id });

        if (videogame == null) return NotFound();

        return Ok(videogame);
    }

    /// <summary>
    /// Retrieves a list of video games without a group
    /// </summary>
    /// <returns></returns>
    [HttpGet("Group")]
    [ProducesResponseType(typeof(VideoGame), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Group()
    {
        var videogame = await Mediator.Send(new GetGrouplessVideoGamesQuery());

        return Ok(videogame);
    }

    /// <summary>
    /// Creates a new videogame
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(CreateVideoGameCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Clones a videogame
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("Clone/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Clone(Guid id)
    {
        await Mediator.Send(new CloneVideoGameCommand { Id = id });
        return NoContent();
    }

    /// <summary>
    /// Updates a videogame
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Update(Guid id, UpdateVideoGameCommand command)
    {
        if (id != command.Id) return BadRequest();

        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes a videogame
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteVideoGameCommand { Id = id });
        return NoContent();
    }
}
