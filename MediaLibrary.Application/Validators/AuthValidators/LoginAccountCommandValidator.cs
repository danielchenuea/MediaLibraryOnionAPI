using FluentValidation;
using MediaLibrary.Application.Features.AccountFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.AuthValidators;

public class LoginAccountCommandValidator : AbstractValidator<LoginAccountCommand>
{
    public LoginAccountCommandValidator()
    {

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("'{PropertyName}' can't be null or empty");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("'{PropertyName}' can't be null or empty");

    }
}
