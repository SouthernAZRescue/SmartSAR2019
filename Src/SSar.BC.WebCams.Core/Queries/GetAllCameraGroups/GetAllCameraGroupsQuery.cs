using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Queries.GetAllCameraGroups
{
    public class GetAllCameraGroupsQuery : IRequest<IReadOnlyList<CameraGroup>>
    {
        public class GetAllCameraGroupsQueryHandler : IRequestHandler<GetAllCameraGroupsQuery, IReadOnlyList<CameraGroup>>
        {
            private readonly IWebCamCatalog _webCamCatalog;

            public GetAllCameraGroupsQueryHandler(IWebCamCatalog webCamCatalog)
            {
                _webCamCatalog = webCamCatalog;
            }

            public async Task<IReadOnlyList<CameraGroup>> Handle(GetAllCameraGroupsQuery request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(
                    _webCamCatalog.CameraGroups
                    ?? new CameraGroup[0]);
            }
        }
    }
}
