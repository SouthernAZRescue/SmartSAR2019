using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SSar.BC.WebCams.Core.Queries.GetCameraGroupQuery
{
    public class GetCameraGroupQueryValidator : AbstractValidator<GetCameraGroupQuery>
    {
        public GetCameraGroupQueryValidator()
        {
            RuleFor(r => r.GroupId).NotEmpty();
        }
    }
}
