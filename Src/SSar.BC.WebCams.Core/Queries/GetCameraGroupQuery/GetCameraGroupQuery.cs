using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Queries.GetCameraGroupQuery
{
    public class GetCameraGroupQuery : IRequest<CameraGroup>
    {
        public int GroupId { get; set; }

        public GetCameraGroupQuery(int groupId)
        {
            GroupId = groupId;
        }

        public class GetCameraGroupQueryHandler 
            : IRequestHandler<GetCameraGroupQuery, CameraGroup>
        {
            private readonly IWebCamCatalog _webCamCatalog;

            public GetCameraGroupQueryHandler(IWebCamCatalog webCamCatalog)
            {
                _webCamCatalog = webCamCatalog;
            }

            public async Task<CameraGroup> Handle(
                GetCameraGroupQuery request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(
                    _webCamCatalog
                        .CameraGroups
                            .FirstOrDefault(g => g.GroupId == request.GroupId)
                    ?? new CameraGroup());
            }
        }
    }
}
