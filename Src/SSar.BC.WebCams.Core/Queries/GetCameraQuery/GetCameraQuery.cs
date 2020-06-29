using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Queries.GetCameraQuery
{
    public class GetCameraQuery : IRequest<Camera>
    {
        public string GroupUrlName { get; private set; }
        public string CameraUrlName { get; private set; }

        public GetCameraQuery(string groupUrlName, string cameraUrlName)
        {
            GroupUrlName = groupUrlName;
            CameraUrlName = cameraUrlName;
        }

        public class GetCameraQueryHandler : IRequestHandler<GetCameraQuery, Camera>
        {
            private readonly IWebCamCatalog _camCatalog;

            public GetCameraQueryHandler(IWebCamCatalog camCatalog)
            {
                _camCatalog = camCatalog;
            }

            public async Task<Camera> Handle(GetCameraQuery request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(
                    _camCatalog
                        .CameraGroups
                        .FirstOrDefault(g => g.UrlName == request.GroupUrlName)
                        ?.Cameras
                        .FirstOrDefault(c => c.UrlName == request.CameraUrlName)
                    ?? new Camera());
            }
        }
    }
}
