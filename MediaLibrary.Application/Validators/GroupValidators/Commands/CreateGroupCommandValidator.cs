using FluentValidation;
using MediaLibrary.Application.Features.GroupFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.GroupValidators.Commands;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleForEach(x => x.Books)
            .NotEmpty();

        RuleForEach(x => x.VideoGames)
            .NotEmpty();
    }
}
