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

namespace MediaLibrary.Application.Features.VideoGameFeatures.Commands;

public class CloneVideoGameCommand : IRequest
{
    public Guid Id { get; set; }
}

public class CloneVideoGameCommandHandler(IRepositoryDbContext context) : IRequestHandler<CloneVideoGameCommand>
{
    public async Task Handle(CloneVideoGameCommand request, CancellationToken cancellationToken)
    {
        var videogame = await context.VideoGames.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);

        if (videogame == null) throw DataNotFoundException.New("VideoGame");

        videogame.Id = Guid.NewGuid();
        videogame.DateInsert = DateTime.Now;
        videogame.DateEdit = DateTime.Now;

        await context.VideoGames.AddAsync(videogame, cancellationToken);
        await context.SaveChangesAsync();
    }
}