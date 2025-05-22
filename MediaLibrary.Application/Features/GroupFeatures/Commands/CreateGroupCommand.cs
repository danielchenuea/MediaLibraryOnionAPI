using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Application.Features.GroupFeatures.Commands;

public class CreateGroupCommand : IRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IEnumerable<Guid> Books { get; set; } = Enumerable.Empty<Guid>();
    public IEnumerable<Guid> VideoGames { get; set; } = Enumerable.Empty<Guid>();
}

public class CreateGroupCommandHandler(IRepositoryDbContext context): IRequestHandler<CreateGroupCommand>
{
    public async Task Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        Guid newGuid = Guid.NewGuid();

        var group = new Group()
        {
            Id = newGuid,
            DateInsert = DateTime.Now,
            DateEdit = DateTime.Now,
            GroupTitle = request.Title,
            Description = request.Description
        };
        await context.Groups.AddAsync(group, cancellationToken);

        if (request.Books.Any())
        {
            await context.Books
                .Where(x => request.Books.Contains(x.Id))
                .ExecuteUpdateAsync(s => s.SetProperty(a => a.GroupId, b => newGuid), cancellationToken);
        }
        if (request.VideoGames.Any())
        {
            await context.VideoGames
                .Where(x => request.VideoGames.Contains(x.Id))
                .ExecuteUpdateAsync(s => s.SetProperty(a => a.GroupId, b => newGuid), cancellationToken);
        }

        await context.SaveChangesAsync();
    }
}


