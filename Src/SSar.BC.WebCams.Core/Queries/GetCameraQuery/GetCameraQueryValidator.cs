using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;

namespace SSar.BC.WebCams.Core.Queries.GetCameraQuery
{
    public class GetCameraQueryValidator : AbstractValidator<GetCameraQuery>
    {
        public GetCameraQueryValidator()
        {
            RuleFor(r => r.GroupId).NotEmpty();
            RuleFor(r => r.CameraId).NotEmpty();
        }
    }
}
