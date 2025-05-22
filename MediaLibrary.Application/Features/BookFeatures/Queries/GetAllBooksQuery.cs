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

public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
{
}

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
{
    private readonly IRepositoryDbContext context;

    public GetAllBooksQueryHandler(IRepositoryDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var bookList = await context.Books.ToListAsync(cancellationToken);
        return bookList.AsReadOnly();
    }
}
