using FluentValidation;
using MediaLibrary.Application.Features.BookFeatures.Commands;
using MediaLibrary.Application.Features.BookFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.BookValidators.Commands;

public class GetBookByIdCommandValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("'{PropertyName}' can't be null or empty");
    }
}
