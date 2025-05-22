using FluentValidation;
using MediaLibrary.Application.Features.AccountFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.AuthValidators;

public class RevokeTokenAccountCommandValidator : AbstractValidator<RevokeTokenAccountCommand>
{
    public RevokeTokenAccountCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();
    }
}
