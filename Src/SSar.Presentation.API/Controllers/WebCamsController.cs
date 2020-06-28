using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.WebCams.Core.Queries.GetAllCameraGroupsQuery;
using SSar.BC.WebCams.Core.Queries.GetCameraGroupQuery;
using SSar.BC.WebCams.Core.Queries.GetCameraImageQuery;
using SSar.BC.WebCams.Core.ValueTypes;

// using SSar.BC.WebCams.Core.Commands;

namespace SSar.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebCamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WebCamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // TODO!: RESILIENCY - check for relevant errors and return correct HTTP codes

        // GET /api/webcams/groups
        [HttpGet("groups")]
        public async Task<IReadOnlyList<CameraGroup>> GetGroups()
        {
            return await _mediator.Send(new GetAllCameraGroupsQuery());
        }

        // GET /api/webcams/groups/sara-house
        [HttpGet("groups/{groupUrlName}")]
        public async Task<CameraGroup> GetGroup(string groupUrlName)
        {
            return await _mediator.Send(new GetCameraGroupQuery(groupUrlName));
        }

        // GET /api/webcams/groups/sara-house/cameras
        [HttpGet("groups/{groupUrlName}/cameras")]
        public async Task<IActionResult> GetCameras(string groupUrlName)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north
        [HttpGet("groups/{groupUrlName}/cameras/{cameraUrlName}")]
        public async Task<IActionResult> GetCamera(string groupUrlName, string cameraUrlName)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north/thumbnail
        [HttpGet("groups/{groupUrlName}/cameras/{cameraUrlName}/thumbnail")]
        public async Task<IActionResult> GetThumbnail(string groupUrlName, string cameraUrlName)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north/image
        [HttpGet("groups/{groupUrlName}/cameras/{cameraUrlName}/image")]
        public async Task<IActionResult> GetImage([FromRoute] string groupUrlName, [FromRoute] string cameraUrlName)
        {
            var camImage = (await _mediator.Send(
                new GetCameraImageQuery(groupUrlName, cameraUrlName)));

            return File(
                camImage.ByteArray
                    ?? new byte[0],
                "image/jpeg");
        }
    }
}
