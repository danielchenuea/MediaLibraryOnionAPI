using FluentValidation;
using MediaLibrary.Application.Features.AccountFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.AuthValidators;

public class ResetPasswordAccountCommandValidator : AbstractValidator<ResetPasswordAccountCommand>
{
    public ResetPasswordAccountCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.Token)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(6, 20)
            .Equal(z => z.ConfirmPassword);

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty();
    }
}
