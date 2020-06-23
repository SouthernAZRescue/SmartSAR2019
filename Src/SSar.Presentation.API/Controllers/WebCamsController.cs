using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Routing;

namespace SSar.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebCamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WebCamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var imageFromFile = System.IO.File.OpenRead("g:\\tmp\\c\\c (25).jpg");



            using (HttpClient httpClient = new HttpClient())
            {
                Byte[] imageFromWeb = await httpClient.GetByteArrayAsync(@"http://remote.sarci.org:19204/snap.jpeg");

                return File(imageFromWeb, "image/jpeg");

            }
        }



        ///// <summary>
        ///// Get a list of all members with basic properties for a quick reference table.
        ///// </summary>
        ///// <returns></returns>
        ///// <response code="200"></response>
        //[HttpGet]
        //public async Task<MembersListVm> GetAll()
        //{
        //    return await _mediator.Send(new GetMembersListQuery());
        //}

        //[HttpGet("{id}")]
        //public async Task<MemberLookupDto> Get(int id)
        //{
        //    return await _mediator.Send(new GetMemberDetailQuery() { EntityId = id });
        //}

        //[HttpPost]
        //public async Task<ActionResult<int>> Post([FromBody] CreateMemberCommand command)
        //{
        //    return await _mediator.Send(command);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id, [FromBody] UpdateMemberCommand command)
        //{
        //    if (id != command.EntityId)
        //    {
        //        return BadRequest();
        //    }

        //    await _mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await _mediator.Send(new DeleteMemberCommand() { EntityId = id });

        //    return NoContent();
        //}
    }
}
