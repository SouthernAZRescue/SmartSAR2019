using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList;
using SSar.BC.UserMgmt.Application.Roles.Queries;

namespace SSar.Presentation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<RolesListVm> GetAll()
        {
            return await _mediator.Send(new GetRolesListQuery());
        }
    }
}
