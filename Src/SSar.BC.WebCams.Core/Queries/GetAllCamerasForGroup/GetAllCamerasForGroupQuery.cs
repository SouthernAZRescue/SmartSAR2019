using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Queries.GetAllCamerasForGroup
{
    public class GetAllCamerasForGroupQuery : IRequest<IReadOnlyList<Camera>>
    {
        public int GroupId { get; set; }

        public GetAllCamerasForGroupQuery(int groupId)
        {
            GroupId = groupId;
        }

        public class GetAllCamerasForGroupQueryHandler : IRequestHandler<GetAllCamerasForGroupQuery, IReadOnlyList<Camera>>
        {
            private readonly IWebCamCatalog _webCameraCatalog;

            public GetAllCamerasForGroupQueryHandler(IWebCamCatalog webCameraCatalog)
            {
                _webCameraCatalog = webCameraCatalog;
            }

            public async Task<IReadOnlyList<Camera>> Handle(GetAllCamerasForGroupQuery request, CancellationToken cancellationToken)
            {

                var cameras = _webCameraCatalog
                    .CameraGroups.FirstOrDefault(g => g.GroupId == request.GroupId)
                    ?.Cameras;

                           return await Task.FromResult(cameras);
            }
        }
    }
}
