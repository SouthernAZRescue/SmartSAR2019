using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SSar.BC.WebCams.Core.Queries.GetAllCamerasForGroupQuery
{
    public class GetAllCamerasForGroupQueryValidator : AbstractValidator<GetAllCamerasForGroupQuery>
    {
        public GetAllCamerasForGroupQueryValidator()
        {
            RuleFor(r => r.GroupId).NotEmpty();
        }
    }
}
