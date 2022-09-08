using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.Data;
using Org.Models;
using System.Threading.Tasks;
using System;

namespace Org.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public AuthenticateController(ApplicationDBContext context )
        {
            _context = context;
        }
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody]Authenticate model)
        {
            return null;
        }
    }
}
