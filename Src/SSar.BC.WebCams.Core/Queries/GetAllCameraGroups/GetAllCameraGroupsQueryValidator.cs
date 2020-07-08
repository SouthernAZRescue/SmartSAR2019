using FluentValidation;

namespace SSar.BC.WebCams.Core.Queries.GetAllCameraGroups
{
    public class GetAllCameraGroupsQueryValidator : AbstractValidator<GetAllCameraGroupsQuery>
    {
        public GetAllCameraGroupsQueryValidator()
        {
            // No parameters to test at this time
        }
    }
}
