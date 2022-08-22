using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sample.workspace.Server.Services;
using Workspace.Shared.Entities.SampleApp;

namespace sample.workspace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleTodoController : ControllerBase
    {
        private readonly ISampleTodoService _sampleTodoService;

        public SampleTodoController(ISampleTodoService sampleTodoService)
        {
            _sampleTodoService = sampleTodoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SampleTodo>>> GetAllSampleTodos()
        {
            var result = await _sampleTodoService.GetAllTodos();
            return Ok(result);
        }
    }
}
