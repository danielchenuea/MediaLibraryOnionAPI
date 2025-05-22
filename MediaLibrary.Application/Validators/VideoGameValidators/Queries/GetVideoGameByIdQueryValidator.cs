using FluentValidation;
using MediaLibrary.Application.Features.VideoGameFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.VideoGameValidators.Queries;

public class GetVideoGameByIdQueryValidator : AbstractValidator<GetVideoGameByIdQuery>
{
    public GetVideoGameByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
