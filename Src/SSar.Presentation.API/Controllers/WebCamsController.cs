using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.WebCams.Core.Queries.GetAllCameraGroupsQuery;
using SSar.BC.WebCams.Core.Queries.GetAllCamerasForGroupQuery;
using SSar.BC.WebCams.Core.Queries.GetCameraGroupQuery;
using SSar.BC.WebCams.Core.Queries.GetCameraImageQuery;
using SSar.BC.WebCams.Core.Queries.GetCameraQuery;
using SSar.BC.WebCams.Core.ValueTypes;

// using SSar.BC.WebCams.Core.Commands;

namespace SSar.Presentation.API.Controllers
{
    // IF THE API ROUTES OR METHOD SIGNATURES ARE MODIFIED THE
    // API CLIENTS MUST BE REGENERATED TO MATCH THE NEW API.
    // See the solution documentation for details on how to
    // enable automatic client generation with builds.

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

        // GET /api/webcams/groups/5
        [HttpGet("groups/{groupId}")]
        public async Task<CameraGroup> GetCameraGroup(int groupId)
        {
            return await _mediator.Send(new GetCameraGroupQuery(groupId));
        }

        // GET /api/webcams/groups/5/cameras
        [HttpGet("groups/{groupId}/cameras")]
        public async Task<IReadOnlyList<Camera>> GetAllCamerasForGroup(int groupId)
        {
            return await _mediator.Send(new GetAllCamerasForGroupQuery(groupId));
        }

        // GET /api/webcams/groups/5/cameras/3
        [HttpGet("groups/{groupId}/cameras/{cameraId}")]
        public async Task<Camera> GetCamera(int groupId, int cameraId)
        {
            return await _mediator.Send(new GetCameraQuery(groupId, cameraId));
        }

        // GET /api/webcams/groups/5/cameras/3/thumbnail
        [HttpGet("groups/{groupId}/cameras/{cameraId}/thumbnail")]
        public async Task<IActionResult> GetThumbnail(int groupId, int cameraId)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/5/cameras/3/image
        [HttpGet("groups/{groupId}/cameras/{cameraId}/image")]
        public async Task<IActionResult> GetImage([FromRoute] int groupId, [FromRoute] int cameraId)
        {
            var camImage = (await _mediator.Send(
                new GetCameraImageQuery(groupId, cameraId)));

            return File(
                camImage.ByteArray
                    ?? new byte[0],
                "image/jpeg");
        }
    }
}
