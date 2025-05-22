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

public class DeleteVideoGameCommand : IRequest
{
    /// <summary>
    /// Id of the videogame
    /// </summary>
    public Guid Id { get; set; }
}

public class DeleteVideoGameCommandHandler(IRepositoryDbContext context) : IRequestHandler<DeleteVideoGameCommand>
{
    public async Task Handle(DeleteVideoGameCommand request, CancellationToken cancellationToken)
    {
        var videogame = await context.VideoGames.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);
        if (videogame == null) throw DataNotFoundException.New("VideoGame");

        context.VideoGames.Remove(videogame);
        await context.SaveChangesAsync();
    }
}