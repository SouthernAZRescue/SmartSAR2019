using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Commands
{
    public class GetImageByIdQuery : IRequest<CamImage>
    {
        public GetImageByIdQuery(string imageUrl)
        {
            ImageUrl = imageUrl ?? throw new ArgumentNullException();
        }

        public string ImageUrl { get; private set; }

        public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, CamImage>
        {
            private IWebCamImageRetrievalService _camService;

            public GetImageByIdQueryHandler(IWebCamImageRetrievalService camService)
            {
                _camService = camService;
            }

            public async Task<CamImage> Handle(
                GetImageByIdQuery request, CancellationToken cancellationToken)
            {
                return 
                    await _camService.GetImageFromUrl(request.ImageUrl);
            }
        }
    }
}
