using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Queries
{
    public class GetCamImageQuery : IRequest<CamImage>
    {
        public GetCamImageQuery(string groupUrlName, string cameraUrlName)
        {
            GroupUrlName = groupUrlName;
            CameraUrlName = cameraUrlName;
        }

        public string GroupUrlName { get; private set; }
        public string CameraUrlName { get; private set; }

        public class GetImageByCamNameQueryHandler : IRequestHandler<GetCamImageQuery, CamImage>
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
                GetCamImageQuery request, CancellationToken cancellationToken)
            {
                // TODO!: Remove temporary fixed name for building

                Camera camera = 
                    _camCatalog.CameraGroups
                        .FirstOrDefault(g => g.UrlName == request.GroupUrlName)
                    ?.Cameras
                        .FirstOrDefault(c => c.UrlName == request.CameraUrlName);

                // CONSIDER: Throwing exception if there is an error/null.

                if (camera == null)
                {
                    return new CamImage(new byte[0]); // Empty image
                }
                
                // TODO!: Handle NULL return

                return 
                    await _camImageService.GetImageFromUrl(camera.SourceUrl);
            }
        }
    }
}
