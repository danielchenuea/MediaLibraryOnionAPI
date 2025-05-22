using MediaLibrary.Application.Exceptions;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace MediaLibrary.Application.Features.GroupFeatures.Commands;

public class DeleteGroupCommand : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteGroupCommandHandler(IRepositoryDbContext context): IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await context.Groups.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (group == null) throw DataNotFoundException.New("Group");

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

        context.Groups.Remove(group);

        await context.SaveChangesAsync();
    }
}


