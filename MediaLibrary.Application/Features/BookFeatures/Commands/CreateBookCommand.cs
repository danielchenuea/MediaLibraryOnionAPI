using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.BookFeatures.Commands;

public class CreateBookCommand : IRequest
{
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

public class CreateBookCommandHandler(IRepositoryDbContext context) : IRequestHandler<CreateBookCommand>
{
    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book()
        {
            Id = Guid.NewGuid(),
            DateInsert = DateTime.Now,
            DateEdit = DateTime.Now,
            Title = request.Title,
            Score = request.Score,
            Author = request.Author,
            Genre = request.Genre,
            Pages = request.Pages
        };
        await context.Books.AddAsync(book, cancellationToken);
        await context.SaveChangesAsync();
    }
}