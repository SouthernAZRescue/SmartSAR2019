using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Queries.GetCameraImageQuery
{
    public class GetCameraImageQuery : IRequest<CameraImage>
    {
        public GetCameraImageQuery(int groupId, int cameraId)
        {
            GroupId = groupId;
            CameraId = cameraId;
        }

        public int GroupId { get; private set; }
        public int CameraId { get; private set; }

        public class GetImageByCamNameQueryHandler : IRequestHandler<GetCameraImageQuery, CameraImage>
        {
            private readonly IWebCamCatalog _camCatalog;
            private readonly IWebCamImageRetrievalService _camImageService;

            public GetImageByCamNameQueryHandler(
                IWebCamCatalog camCatalog, IWebCamImageRetrievalService camImageService)
            {
                _camCatalog = camCatalog;
                _camImageService = camImageService;
            }

            public async Task<CameraImage> Handle(
                GetCameraImageQuery request, CancellationToken cancellationToken)
            {
                // TODO!: Remove temporary fixed name for building

                Camera camera = 
                    _camCatalog.CameraGroups
                        .FirstOrDefault(g => g.Id == request.GroupId)
                    ?.Cameras
                        .FirstOrDefault(c => c.Id == request.CameraId);

                // CONSIDER: Throwing exception if there is an error/null.

                if (camera == null)
                {
                    return new CameraImage(new byte[0]); // Empty image
                }
                
                // TODO!: Handle NULL return

                return 
                    await _camImageService.GetImageFromUrl(camera.SourceUrl);
            }
        }
    }
}
