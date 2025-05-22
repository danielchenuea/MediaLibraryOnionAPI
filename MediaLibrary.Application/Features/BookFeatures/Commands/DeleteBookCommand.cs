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

public class DeleteBookCommand : IRequest
{
    /// <summary>
    /// Id of the book
    /// </summary>
    public Guid Id { get; set; }
}

public class DeleteBookCommandHandler(IRepositoryDbContext context) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);
        if (book == null) throw DataNotFoundException.New("Book");

        context.Books.Remove(book);
        await context.SaveChangesAsync();
    }
}