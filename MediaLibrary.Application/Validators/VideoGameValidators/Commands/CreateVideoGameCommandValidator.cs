using FluentValidation;
using MediaLibrary.Application.Features.VideoGameFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.VideoGameValidators.Commands;

public class CreateVideoGameCommandValidator : AbstractValidator<CreateVideoGameCommand>
{
    public CreateVideoGameCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Score)
            .InclusiveBetween(0, 10);

        RuleFor(x => x.Publisher)
            .NotEmpty();

        RuleFor(x => x.Developer)
            .NotEmpty();

        RuleForEach(x => x.Plataforms)
            .NotEmpty();
    }
}
