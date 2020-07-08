using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SSar.BC.WebCams.Core.Queries.GetCameraGroup
{
    public class GetCameraGroupQueryValidator : AbstractValidator<GetCameraGroupQuery>
    {
        public GetCameraGroupQueryValidator()
        {
            RuleFor(r => r.GroupId).NotEmpty();
        }
    }
}
