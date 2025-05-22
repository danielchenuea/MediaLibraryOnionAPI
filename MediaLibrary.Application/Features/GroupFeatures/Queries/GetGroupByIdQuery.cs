using MediaLibrary.Application.Exceptions;
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

public class GetGroupByIdQuery : IRequest<Group>
{
    public Guid Id { get; set; }
}

public class GetGroupByIdQueryHandler(IRepositoryDbContext context) : IRequestHandler<GetGroupByIdQuery, Group>
{
    public async Task<Group> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var group = await context.Groups
            .Include(x => x.Books)
            .Include(x => x.VideoGames)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (group == null) throw DataNotFoundException.New("Group");

        return group;
    }
}
