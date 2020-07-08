using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Queries.GetCameraImage
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

        public class GetCameraImageQueryHandler : IRequestHandler<GetCameraImageQuery, CameraImage>
        {
            private readonly IWebCamCatalog _camCatalog;
            private readonly IWebCamImageRetrievalService _camImageService;

            public GetCameraImageQueryHandler(
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
                        .FirstOrDefault(g => g.GroupId == request.GroupId)
                    ?.Cameras
                        .FirstOrDefault(c => c.CameraId == request.CameraId);

                // TODO!: Throw CameraNotFoundException if appropriate

                if (camera == null)
                {
                    return new CameraImage(new byte[0]); // Empty image
                }
                
                // TODO!: Handle NULL return

                return 
                    await _camImageService.GetImageFromUrl(camera.ImageSourceUrl)
                    ?? new CameraImage(new byte[0]);
            }
        }
    }
}
