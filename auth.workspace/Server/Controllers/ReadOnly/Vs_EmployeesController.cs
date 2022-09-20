using admin.workspace.Server.Services.ReadOnly;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace admin.workspace.Server.Controllers.ReadOnly
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class Vs_EmployeesController : ControllerBase
    {
        private IEmployeeService _iEmployeeService;

        public Vs_EmployeesController(IEmployeeService iEmployeeService)
        {
            _iEmployeeService = iEmployeeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Vs_Employee>>> GetAllVsEmployees()
        {
            var result = await _iEmployeeService.GetAllVsEmployees();
            return Ok(result);
        }
    }
}
