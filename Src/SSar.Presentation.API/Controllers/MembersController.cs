using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSar.BC.MemberMgmt.Application.Queries;

namespace SSar.Presentation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MembersController
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IQueryable<MemberDto>> Get()
        {
            return await _mediator.Send(new GetMembersQuery());
        }

        [HttpGet("{id}")]
        public async Task<MemberDto> Get(int id)
        {
            return await _mediator.Send(new GetMemberByIdQuery() {EntityId = id});
        }

        [HttpPost]
        public async Task<int> Post([FromBody] MemberDto member)
        {
            return await _mediator.Send(new AddMemberQuery(member));
        }

        [HttpPut]
        public async Task Put([FromBody] MemberDto member)
        {
            return await _mediator.Send(new UpdateMemberQuery(member));
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            return await _mediator.Send(new DeleteMemberQuery(id));
        }
    }
}
