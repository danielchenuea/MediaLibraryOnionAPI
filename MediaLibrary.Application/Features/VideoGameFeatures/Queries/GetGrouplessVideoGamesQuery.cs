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

namespace MediaLibrary.Application.Features.VideoGameFeatures.Queries;

public class GetGrouplessVideoGamesQuery : IRequest<IEnumerable<VideoGame>> { }

public class GetGrouplessVideoGamesHandler(IRepositoryDbContext context) : IRequestHandler<GetGrouplessVideoGamesQuery, IEnumerable<VideoGame>>
{
    public async Task<IEnumerable<VideoGame>> Handle(GetGrouplessVideoGamesQuery request, CancellationToken cancellationToken)
    {
        return await context.VideoGames.Where(x => x.GroupId == null).ToListAsync();
    }
}
