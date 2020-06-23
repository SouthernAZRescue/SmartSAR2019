using System;
using System.Text.RegularExpressions;
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
            private IWebCamImageRetrievalService _camService;

            public GetImageByCamNameQueryHandler(IWebCamImageRetrievalService camService)
            {
                _camService = camService;
            }

            public async Task<CamImage> Handle(
                GetImageByCamNameQuery request, CancellationToken cancellationToken)
            {
                // TODO!: Remove temporary fixed name for building

                return 
                    await _camService.GetImageFromUrl(@"http://remote.sarci.org:19204/snap.jpeg");
            }
        }
    }
}
