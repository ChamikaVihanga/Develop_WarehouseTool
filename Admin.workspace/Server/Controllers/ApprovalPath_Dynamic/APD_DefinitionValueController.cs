using ApprovalPath_Utils.Services.DefinitionValueService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class APD_DefinitionValueController : ControllerBase
    {
        private readonly IDefinitionValueService _definitionValueService;

        public APD_DefinitionValueController(IDefinitionValueService definitionValueService)
        {
            _definitionValueService = definitionValueService;
        }

        [HttpGet]
        public async Task<DefinitionValues> GetApprovalDefinitions(Guid? id)
        {
            return await _definitionValueService.GetApprovalDefinitions(id);
        }
    }
}
