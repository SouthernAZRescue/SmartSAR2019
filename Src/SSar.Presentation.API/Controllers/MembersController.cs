using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSar.BC.MemberMgmt.Application;
using SSar.BC.MemberMgmt.Domain.Aggregates;
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
        public async Task<MemberRow> Get()
        { 
            var member = await _mediator.Send(new GetMemberByIdCommand(Guid.NewGuid()));
            return new MemberRow(member.Name.First, member.Name.Middle, member.Name.Last, member.Name.Nickname);
        }
    }
}
