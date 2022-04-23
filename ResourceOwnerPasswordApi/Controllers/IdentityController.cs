using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResourceOwnerPasswordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IdentityController : ControllerBase
    {
        [HttpGet("getUserClaims")]
        //[Authorize]
        [Authorize(Roles = "admin")]
        public IActionResult GetUserClaims()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
