using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace JwtService.Controllers
{
    public class JwtController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            return Ok(new List<string> {"one","two","three"});
        }
    }
}