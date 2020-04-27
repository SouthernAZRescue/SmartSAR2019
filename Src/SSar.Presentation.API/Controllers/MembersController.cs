using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.MemberMgmt.Application;
using SSar.BC.MemberMgmt.Application.Queries;
using SSar.Presentation.Common;

namespace SSar.Presentation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<MemberDto> Get()
        { 
            // TODO: Convert prototype to get ID from HTTP request
            return await _mediator.Send(new GetMemberByIdQuery(1));
        }
    }
}
