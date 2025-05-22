using FluentValidation;
using MediaLibrary.Application.Features.GroupFeatures.Queries;
using MediaLibrary.Application.Features.VideoGameFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.VideoGameValidators.Commands;

public class CloneVideoGameCommandValidator : AbstractValidator<CloneVideoGameCommand>
{
    public CloneVideoGameCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
