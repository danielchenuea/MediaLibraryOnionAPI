

using MediaLibrary.Application.Features.GroupFeatures.Commands;
using MediaLibrary.Application.Features.GroupFeatures.Queries;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MediaLibrary.API.Controllers;

/// <summary>
/// Api Controlling the groups
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class GroupsApiController : ControllerBase
{
    public IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    /// <summary>
    /// Retrieves a list of groups
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(Group), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAll()
    {
        var groups = await Mediator.Send(new GetAllGroupsQuery());

        return Ok(groups);
    }

    /// <summary>
    /// Retrieves a specific group
    /// </summary>
    /// <param name="id">Id of the group</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Group), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var group = await Mediator.Send(new GetGroupByIdQuery { Id = id });

        if (group == null) return NotFound();

        return Ok(group);
    }

    /// <summary>
    /// Creates a new group
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(CreateGroupCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Updates a group
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Update(Guid id, UpdateGroupCommand command)
    {
        if (id != command.Id) return BadRequest();

        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes a group
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteGroupCommand { Id = id });
        return NoContent();
    }
}
