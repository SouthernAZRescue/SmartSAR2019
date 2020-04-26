using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSar.Presentation.Common;

namespace SSar.Presentation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        [HttpGet]
        public MemberRow Get()
        {
            return 
                new MemberRow()
                {
                    FirstName = "Frodo", 
                    MiddleName = "Alfred", 
                    LastName = "Baggins", 
                    Nickname = "Fro"
                };
        }
    }
}
