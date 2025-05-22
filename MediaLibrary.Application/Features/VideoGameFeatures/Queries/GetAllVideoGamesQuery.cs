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

public class GetAllVideoGamesQuery : IRequest<IEnumerable<VideoGame>>
{
}

public class GetAllVideoGamesQueryHandler(IRepositoryDbContext context) : IRequestHandler<GetAllVideoGamesQuery, IEnumerable<VideoGame>>
{
    public async Task<IEnumerable<VideoGame>> Handle(GetAllVideoGamesQuery request, CancellationToken cancellationToken)
    {
        var videogameList = await context.VideoGames.ToListAsync(cancellationToken);
        return videogameList.AsReadOnly();
    }
}
