using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.WebCams.Core.Commands;
using SSar.BC.WebCams.Core.ValueTypes;

// using SSar.BC.WebCams.Core.Commands;

namespace SSar.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebCamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WebCamsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //webcams/images?groupName=cam-group&cameraName=cam-name
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] string groupName, [FromQuery] string cameraName)
        {
            var camImage = await _mediator.Send(
                new GetImageByIdQuery(
                    @"http://remote.sarci.org:19204/snap.jpeg"));

            return File(camImage.ByteArray, "image/jpeg");

            // TODO!: RESILIENCY - check for relevant errors and return
            // appropriate HTTP codes
        }
    }
}
