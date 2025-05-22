using FluentValidation;
using MediaLibrary.Application.Features.BookFeatures.Commands;

namespace MediaLibrary.Application.Validators.BookValidators.Commands;

/// <summary>
/// 
/// </summary>
public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    /// <summary>
    /// </summary>
    public CreateBookCommandValidator()
    {
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
