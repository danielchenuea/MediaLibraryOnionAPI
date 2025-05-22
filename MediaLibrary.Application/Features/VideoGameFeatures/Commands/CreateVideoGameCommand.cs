using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.VideoGameFeatures.Commands;

public class CreateVideoGameCommand : IRequest
{
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

public class CreateVideoGameCommandHandler(IRepositoryDbContext context) : IRequestHandler<CreateVideoGameCommand>
{
    public async Task Handle(CreateVideoGameCommand request, CancellationToken cancellationToken)
    {
        var videogame = new VideoGame()
        {
            Id = Guid.NewGuid(),
            DateInsert = DateTime.Now,
            DateEdit = DateTime.Now,
            Title = request.Title,
            Score = request.Score,
            Publisher = request.Publisher,
            Developer = request.Developer,
            Plataforms = request.Plataforms
        };

        await context.VideoGames.AddAsync(videogame, cancellationToken);
        await context.SaveChangesAsync();
    }
}