using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SSar.BC.WebCams.Core.Queries.GetCamImageQuery
{
    public class GetCamImageQueryValidator : AbstractValidator<GetCamImageQuery>
    {
        public GetCamImageQueryValidator()
        {
            RuleFor(r => r.GroupUrlName).NotEmpty();
            RuleFor(r => r.CameraUrlName).NotEmpty();
        }
    }
}
