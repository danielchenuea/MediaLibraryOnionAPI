using MediaLibrary.Application.Exceptions;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.BookFeatures.Queries;

public class GetBookByIdQuery : IRequest<Book>
{
    public Guid Id { get; set; }
}

public class GetBookByIdHandler(IRepositoryDbContext context) : IRequestHandler<GetBookByIdQuery, Book>
{
    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (book == null) throw DataNotFoundException.New("Book");

        return book;
    }
}
