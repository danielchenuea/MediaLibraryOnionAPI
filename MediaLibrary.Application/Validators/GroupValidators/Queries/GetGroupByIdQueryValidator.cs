
using FluentValidation;
using MediaLibrary.Application.Features.GroupFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Validators.GroupValidators.Queries;

public class GetGroupByIdQueryValidator : AbstractValidator<GetGroupByIdQuery>
{
    public GetGroupByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
