

using Asp.Versioning;
using MediaLibrary.Application.Features.BookFeatures.Commands;
using MediaLibrary.Application.Features.BookFeatures.Queries;
using MediaLibrary.Application.Implementations;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MediaLibrary.API.Controllers;

/// <summary>
/// Api Controlling the books
/// </summary>
[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class BooksApiController : ControllerBase
{
    public IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    /// <summary>
    /// Retrieves a list of books
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> GetAll()
    {
        var books = await Mediator.Send(new GetAllBooksQuery());

        return Ok(books);
    }

    /// <summary>
    /// Retrieves a specific book
    /// </summary>
    /// <param name="id">Id of the book</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var book = await Mediator.Send(new GetBookByIdQuery { Id = id });

        if (book == null) return NotFound();

        return Ok(book);
    }

    /// <summary>
    /// Retrieves a list of books without a group
    /// </summary>
    /// <returns></returns>
    [HttpGet("Group")]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Group()
    {
        var book = await Mediator.Send(new GetGrouplessBooksQuery());

        return Ok(book);
    }

    /// <summary>
    /// Creates a new book
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Clones a book
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("Clone/{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Clone(Guid id)
    {
        await Mediator.Send(new CloneBookCommand { Id = id });
        return NoContent();
    }

    /// <summary>
    /// Updates a book
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Update(Guid id, UpdateBookCommand command)
    {
        if (id != command.Id) return BadRequest();

        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Tag a book as reading
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("Reading")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> ReadingBook(Guid id)
    {
        await Mediator.Send(new UpdateReadingCommand() { Id = id, IsReading = true });
        return NoContent();
    }
    /// <summary>
    /// Untag a book as reading
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("Unreading")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> UnreadingBook(Guid id)
    {
        await Mediator.Send(new UpdateReadingCommand() { Id = id, IsReading = false });
        return NoContent();
    }

    /// <summary>
    /// Tag a book as Favorite
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("Favorite")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> FavoriteBook(Guid id)
    {
        await Mediator.Send(new UpdateFavoriteCommand() { Id = id, Favorite = true });
        return NoContent();
    }
    /// <summary>
    /// Untag a book as Favorite
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("Unfavorite")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> UnfavoriteBook(Guid id)
    {
        await Mediator.Send(new UpdateFavoriteCommand() { Id = id, Favorite = false });
        return NoContent();
    }

    /// <summary>
    /// Deletes a book
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteBookCommand { Id = id });
        return NoContent();
    }
}
