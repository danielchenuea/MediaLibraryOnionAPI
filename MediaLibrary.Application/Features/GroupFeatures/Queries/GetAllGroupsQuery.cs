using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.GroupFeatures.Queries;

public class GetAllGroupsQuery : IRequest<IEnumerable<Group>>
{
}

public class GetAllGroupsQueryHandler(IRepositoryDbContext context) : IRequestHandler<GetAllGroupsQuery, IEnumerable<Group>>
{
    public async Task<IEnumerable<Group>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
    {
        return await context.Groups
            .Include(x => x.Books)
            .Include(x => x.VideoGames)
            .ToListAsync(cancellationToken);
    }
}
