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
    public class MemberMgmtController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberMgmtController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<MemberMgmtVm> Get()
        { 
            return await _mediator.Send(new GetMemberMgmtVmQuery());
        }
    }
}
