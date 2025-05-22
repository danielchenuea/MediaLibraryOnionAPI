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

public class CloneBookCommand : IRequest
{
    /// <summary>
    /// Id of the book
    /// </summary>
    public Guid Id { get; set; }
}

public class CloneBookCommandHandler(IRepositoryDbContext context) : IRequestHandler<CloneBookCommand>
{
    public async Task Handle(CloneBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);

        if (book == null) throw DataNotFoundException.New("Book");

        book.Id = Guid.NewGuid();
        book.DateInsert = DateTime.Now;
        book.DateEdit = DateTime.Now;

        await context.Books.AddAsync(book, cancellationToken);
        await context.SaveChangesAsync();
    }
}