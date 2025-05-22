using FluentValidation;
using MediaLibrary.Application.Features.BookFeatures.Commands;

namespace MediaLibrary.Application.Validators.BookValidators.Commands;

/// <summary>
/// 
/// </summary>
public class CloneBookCommandValidator : AbstractValidator<CloneBookCommand>
{
    /// <summary>
    /// </summary>
    public CloneBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("The Id can't be null");
    }
}
