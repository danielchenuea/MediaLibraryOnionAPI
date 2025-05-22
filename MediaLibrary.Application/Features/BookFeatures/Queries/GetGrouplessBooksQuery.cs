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

public class GetGrouplessBooksQuery : IRequest<IEnumerable<Book>>
{
}

public class GetGrouplessBooksQueryHandler(IRepositoryDbContext context) : IRequestHandler<GetGrouplessBooksQuery, IEnumerable<Book>>
{
    public async Task<IEnumerable<Book>> Handle(GetGrouplessBooksQuery request, CancellationToken cancellationToken)
    {
        return await context.Books.Where(x => x.IsReading == false).ToListAsync();
    }
}
