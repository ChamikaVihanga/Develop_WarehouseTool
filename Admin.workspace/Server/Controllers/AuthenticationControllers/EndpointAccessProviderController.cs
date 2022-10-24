using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace admin.workspace.Server.Controllers.AuthenticationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointAccessProviderController : ControllerBase
    {

        [HttpGet]
        public async Task AccessProvider()
        {
            
            
        }
    }
}
