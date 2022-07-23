using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ResourceFacilities;

namespace Workspace.Server.Controllers.ResourceFacilities
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReFaRequestsController : ControllerBase
    {

        private readonly IReFaRequestService _iReFaRequestService;

        public ReFaRequestsController(IReFaRequestService reFaRequestService)
        {
            _iReFaRequestService = reFaRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ReFaRequest>>>> GetReFaRequests()
        {
            var result = await _iReFaRequestService.GetReFaRequestsAsync();
            return Ok(result);
        }

        [HttpGet("{reFaRequestId}")]
        public async Task<ActionResult<ServiceResponse<ReFaRequest>>> GetReFaRequest(Guid reFaRequestId)
        {
            var result = await _iReFaRequestService.GetReFaRequestAsync(reFaRequestId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ReFaRequest>>> CreateReFaRequest(ReFaRequest reFaRequest)
        {
            var result = await _iReFaRequestService.CreateReFaRequest(reFaRequest);
            return Ok(result);
        }
    }
}
