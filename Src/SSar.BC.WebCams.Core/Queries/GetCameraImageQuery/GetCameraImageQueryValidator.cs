using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SSar.BC.WebCams.Core.Queries.GetCameraImageQuery
{
    public class GetCameraImageQueryValidator : AbstractValidator<GetCameraImageQuery>
    {
        public GetCameraImageQueryValidator()
        {
            RuleFor(r => r.GroupId).NotEmpty();
            RuleFor(r => r.CameraId).NotEmpty();
        }
    }
}
