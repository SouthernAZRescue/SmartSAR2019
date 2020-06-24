using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Commands
{
    public class GetImageByCamNameQuery : IRequest<CamImage>
    {
        public GetImageByCamNameQuery(string groupName, string cameraName)
        {
            GroupName = groupName;
            CameraName = cameraName;
        }

        public string GroupName { get; private set; }
        public string CameraName { get; private set; }

        public class GetImageByCamNameQueryHandler : IRequestHandler<GetImageByCamNameQuery, CamImage>
        {
            private readonly IWebCamCatalog _camCatalog;
            private readonly IWebCamImageRetrievalService _camImageService;

            public GetImageByCamNameQueryHandler(
                IWebCamCatalog camCatalog, IWebCamImageRetrievalService camImageService)
            {
                _camCatalog = camCatalog;
                _camImageService = camImageService;
            }

            public async Task<CamImage> Handle(
                GetImageByCamNameQuery request, CancellationToken cancellationToken)
            {
                // TODO!: Remove temporary fixed name for building

                CameraGroup cameraGroup = _camCatalog.CameraGroups
                        .FirstOrDefault(g => g.UrlName == request.GroupName);

                Camera camera = _camCatalog.Cameras
                    .FirstOrDefault(c => c.UrlName == request.CameraName);

                return 
                    await _camImageService.GetImageFromUrl(@"http://remote.sarci.org:19204/snap.jpeg");
            }
        }
    }
}
