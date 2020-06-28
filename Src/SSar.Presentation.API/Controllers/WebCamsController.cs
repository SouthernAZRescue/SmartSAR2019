using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.WebCams.Core.Queries.GetAllCameraGroupsQuery;
using SSar.BC.WebCams.Core.Queries.GetCamImageQuery;
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
        [HttpGet("groups/{groupName}")]
        public async Task<CameraGroup> GetGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/sara-house/cameras
        [HttpGet("groups/{groupName}/cameras")]
        public async Task<IActionResult> GetCameras(string groupName)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north
        [HttpGet("groups/{groupName}/cameras/{cameraName}")]
        public async Task<IActionResult> GetCamera(string groupName, string cameraName)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north/thumbnail
        [HttpGet("groups/{groupName}/cameras/{cameraName}/thumbnail")]
        public async Task<IActionResult> GetThumbnail(string groupName, string cameraName)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north/image
        [HttpGet("groups/{groupName}/cameras/{cameraName}/image")]
        public async Task<IActionResult> GetImage([FromRoute] string groupName, [FromRoute] string cameraName)
        {
            var camImage = (await _mediator.Send(
                new GetCamImageQuery(groupName, cameraName)));

            return File(
                camImage.ByteArray
                    ?? new byte[0],
                "image/jpeg");
        }
    }
}
