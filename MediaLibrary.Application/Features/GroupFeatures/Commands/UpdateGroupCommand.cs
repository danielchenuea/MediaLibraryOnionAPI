using MediaLibrary.Application.Exceptions;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Application.Features.GroupFeatures.Commands;

public class UpdateGroupCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IEnumerable<Guid> Books { get; set; } = Enumerable.Empty<Guid>();
    public IEnumerable<Guid> VideoGames { get; set; } = Enumerable.Empty<Guid>();
}

public class UpdateGroupCommandHandler(IRepositoryDbContext context): IRequestHandler<UpdateGroupCommand>
{
    public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await context.Groups.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken);

        if (group == null) throw DataNotFoundException.New("Book");

        group.Id = request.Id;
        group.DateEdit = DateTime.Now;
        group.GroupTitle = request.Title;
        group.Description = request.Description;
        
        context.Groups.Update(group);

        var books = context.Books.Where(x => x.GroupId == group.Id);
        if (books.Any())
        {
            await books.ExecuteUpdateAsync(s => s.SetProperty(a => a.GroupId, b => null), cancellationToken);
        }
        var videogames = context.VideoGames.Where(x => x.GroupId == group.Id);
        if (videogames.Any())
        {
            await videogames.ExecuteUpdateAsync(s => s.SetProperty(a => a.GroupId, b => null), cancellationToken);
        }

        if (request.Books.Any())
        {
            await context.Books
                .Where(x => request.Books.Contains(x.Id))
                .ExecuteUpdateAsync(s => s.SetProperty(a => a.GroupId, b => group.Id), cancellationToken);
        }
        if (request.VideoGames.Any())
        {
            await context.VideoGames
                .Where(x => request.VideoGames.Contains(x.Id))
                .ExecuteUpdateAsync(s => s.SetProperty(a => a.GroupId, b => group.Id), cancellationToken);
        }

        await context.SaveChangesAsync();
    }
}


