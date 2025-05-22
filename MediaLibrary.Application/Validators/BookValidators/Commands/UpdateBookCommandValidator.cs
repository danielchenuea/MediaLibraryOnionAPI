using FluentValidation;
using MediaLibrary.Application.Features.BookFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.BookValidators.Commands;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("'{PropertyName}' can't be null or empty");

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Score)
            .InclusiveBetween(0, 10);

        RuleFor(x => x.Author)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Genre)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Pages)
            .GreaterThanOrEqualTo(0);
    }
}
