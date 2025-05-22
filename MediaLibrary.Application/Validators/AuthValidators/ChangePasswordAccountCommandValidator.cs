using FluentValidation;
using MediaLibrary.Application.Features.AccountFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.AuthValidators;

public class ChangePasswordAccountCommandValidator : AbstractValidator<ChangePasswordAccountCommand>
{
    public ChangePasswordAccountCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.CurrentPassword)
            .NotEmpty();

        RuleFor(x => x.NewPassword)
            .Equal(y => y.ConfirmNewPassword)
            .NotEmpty();
        RuleFor(x => x.ConfirmNewPassword)
            .NotEmpty();
    }
}
