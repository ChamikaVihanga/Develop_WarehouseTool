using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.DataTransferLayer;

namespace Workspace.Server.Controllers.UserLogin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public UserLoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<string> Login(dto.UserLogin userLogin)
        {
            string token = await _loginService.Login(userLogin.UserName, userLogin.Password);
            return token;
        }
    }
}
