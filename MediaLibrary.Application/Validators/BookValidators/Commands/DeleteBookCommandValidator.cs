using FluentValidation;
using MediaLibrary.Application.Features.BookFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.BookValidators.Commands;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("The Id can't be null");
    }
}
