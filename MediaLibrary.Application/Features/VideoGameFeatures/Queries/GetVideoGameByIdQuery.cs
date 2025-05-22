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

public class GetVideoGameByIdQuery : IRequest<VideoGame>
{
    public Guid Id { get; set; }
}

public class GetVideoGameByIdHandler(IRepositoryDbContext context) : IRequestHandler<GetVideoGameByIdQuery, VideoGame>
{
    public async Task<VideoGame> Handle(GetVideoGameByIdQuery request, CancellationToken cancellationToken)
    {
        var videogame = await context.VideoGames.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (videogame == null) throw DataNotFoundException.New("VideoGame");

        return videogame;
    }
}
