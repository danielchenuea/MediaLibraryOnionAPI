using FluentValidation;
using MediaLibrary.Application.Features.GroupFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.GroupValidators.Commands;

public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
{
    public DeleteGroupCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
