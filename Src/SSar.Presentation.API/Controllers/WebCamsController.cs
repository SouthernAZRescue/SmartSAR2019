﻿using System;
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
        public async Task<IReadOnlyList<Camera>> GetAllCamerasForGroup(string groupUrlName)
        {
            return await _mediator.Send(new GetAllCamerasForGroupQuery(groupUrlName));
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north
        [HttpGet("groups/{groupId}/cameras/{cameraId}")]
        public async Task<Camera> GetCamera(int groupId, int cameraId)
        {
            return await _mediator.Send(new GetCameraQuery(groupId, cameraId));
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north/thumbnail
        [HttpGet("groups/{groupUrlName}/cameras/{cameraUrlName}/thumbnail")]
        public async Task<IActionResult> GetThumbnail(string groupUrlName, string cameraUrlName)
        {
            throw new NotImplementedException();
        }

        // GET /api/webcams/groups/sara-house/cameras/roof-north/image
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
