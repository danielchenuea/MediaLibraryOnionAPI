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

public class UpdateReadingCommand : IRequest
{
    public Guid Id { get; set; }
    public bool IsReading { get; set; }
}

public class UpdateReadingCommandHandler(IRepositoryDbContext context) : IRequestHandler<UpdateReadingCommand>
{
    public async Task Handle(UpdateReadingCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (book == null) throw DataNotFoundException.New("Book");

        book.IsReading = request.IsReading;

        await context.SaveChangesAsync();
    }
}
