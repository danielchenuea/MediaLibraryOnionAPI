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

public class UpdateVideoGameCommand : IRequest
{
    /// <summary>
    /// Id of the videogame
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Title of the videogame
    /// </summary>
    /// <example>Title</example>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Score of the videogame
    /// </summary>
    /// <example>0</example>
    public int Score { get; set; }
    /// <summary>
    /// Publisher of the videogame
    /// </summary>
    /// <example>Title</example>
    public string Publisher { get; set; } = string.Empty;
    /// <summary>
    /// Developer of the videogame
    /// </summary>
    /// <example>0</example>
    public string Developer { get; set; } = string.Empty;
    /// <summary>
    /// Plataforms of the videogame
    /// </summary>
    /// <example>Author</example>
    public IList<string> Plataforms { get; set; } = new List<string>();
}

public class UpdateVideoGameCommandHandler(IRepositoryDbContext context) : IRequestHandler<UpdateVideoGameCommand>
{
    public async Task Handle(UpdateVideoGameCommand request, CancellationToken cancellationToken)
    {
        var videogame = await context.VideoGames.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);

        if (videogame == null) throw DataNotFoundException.New("VideoGame");

        videogame.DateEdit = DateTime.Now;
        videogame.Title = request.Title;
        videogame.Score = request.Score;
        videogame.Publisher = request.Publisher;
        videogame.Developer = request.Developer;
        videogame.Plataforms = request.Plataforms;

        context.VideoGames.Update(videogame);
        await context.SaveChangesAsync();
    }
}