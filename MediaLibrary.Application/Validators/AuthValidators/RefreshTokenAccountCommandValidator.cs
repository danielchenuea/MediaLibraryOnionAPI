using FluentValidation;
using MediaLibrary.Application.Features.AccountFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.AuthValidators;

public class RefreshTokenAccountCommandValidator : AbstractValidator<RefreshTokenAccountCommand>
{
    public RefreshTokenAccountCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty();
        RuleFor(x => x.RefreshToken)
            .NotEmpty();
        RuleFor(x => x.IpAddress)
            .NotEmpty();
    }
}
