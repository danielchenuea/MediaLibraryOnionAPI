using FluentValidation;
using MediaLibrary.Application.Features.AccountFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.AuthValidators;

public class ForgotPasswordAccountCommandValidator : AbstractValidator<ForgotPasswordAccountCommand>
{
    public ForgotPasswordAccountCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();

        RuleFor(x => x.Origin).NotEmpty();
    }
}
