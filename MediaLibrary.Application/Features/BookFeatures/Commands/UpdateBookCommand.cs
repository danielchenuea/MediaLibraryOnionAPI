using MediaLibrary.Application.Exceptions;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.BookFeatures.Commands;

public class UpdateBookCommand : IRequest
{
    /// <summary>
    /// Id of the book
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Title of the book
    /// </summary>
    /// <example>Title</example>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Score of the book
    /// </summary>
    /// <example>0</example>
    public int Score { get; set; }
    /// <summary>
    /// Author of the book
    /// </summary>
    /// <example>Author</example>
    public string Author { get; set; } = string.Empty;
    /// <summary>
    /// Genre of the book
    /// </summary>
    /// <example>Genre</example>
    public string Genre { get; set; } = string.Empty;
    /// <summary>
    /// Number of pages of the book
    /// </summary>
    /// <example>0</example>
    public int Pages { get; set; }
}

public class UpdateBookCommandHandler(IRepositoryDbContext context) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);

        if (book == null) throw DataNotFoundException.New("Book");

        book.DateEdit = DateTime.Now;
        book.Title = request.Title;
        book.Score = request.Score;
        book.Author = request.Author;
        book.Genre = request.Genre;
        book.Pages = request.Pages;

        context.Books.Update(book);
        await context.SaveChangesAsync();
    }
}