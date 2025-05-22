using FluentValidation;
using MediaLibrary.Application.Features.VideoGameFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.VideoGameValidators.Commands;

public class DeleteVideoGameCommandValidator : AbstractValidator<DeleteVideoGameCommand>
{
    public DeleteVideoGameCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
