using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.MemberMgmt.Application;
using SSar.BC.MemberMgmt.Application.Members.Commands.CreateMemberCommand;
using SSar.BC.MemberMgmt.Application.Members.Commands.DeleteMemberCommand;
using SSar.BC.MemberMgmt.Application.Members.Commands.UpdateMemberCommand;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMemberDetails;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList;

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
        public async Task<MembersListVm> GetAll()
        {
            return await _mediator.Send(new GetMembersListQuery());
        }

        [HttpGet("{id}")]
        public async Task<MemberLookupDto> Get(int id)
        {
            return await _mediator.Send(new GetMemberDetailQuery() {EntityId = id});
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateMemberCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateMemberCommand command)
        {
            if (id != command.EntityId)
            {
                return BadRequest();
            }
            
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteMemberCommand(){EntityId = id});

            return NoContent();
        }
    }
}
