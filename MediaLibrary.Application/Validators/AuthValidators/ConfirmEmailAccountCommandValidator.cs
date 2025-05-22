using FluentValidation;
using MediaLibrary.Application.Features.AccountFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.AuthValidators;

public class ConfirmEmailAccountCommandValidator : AbstractValidator<ConfirmEmailAccountCommand>
{
    public ConfirmEmailAccountCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();

        RuleFor(x => x.Code).NotEmpty();
    }
}
