using MediaLibrary.Application.Exceptions;
using MediaLibrary.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.BookFeatures.Commands;

public class UpdateFavoriteCommand : IRequest
{
    public Guid Id { get; set; }
    public bool Favorite { get; set; }
}

public class UpdateFavoriteCommandHandler(IRepositoryDbContext context) : IRequestHandler<UpdateFavoriteCommand>
{
    public async Task Handle(UpdateFavoriteCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (book == null) throw DataNotFoundException.New("Book");

        book.Favorite = request.Favorite;

        await context.SaveChangesAsync();
    }
}
