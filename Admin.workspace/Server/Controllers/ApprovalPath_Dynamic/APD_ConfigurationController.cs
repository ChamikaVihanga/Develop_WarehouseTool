using ApprovalPath_Utils.Services.ApprovalConfigurationService;
using ApprovalPath_Utils.Services.ApprovalJobManagerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class APD_ConfigurationController : ControllerBase
    {
        private readonly IApprovalConfigurationService _approvalConfigurationService;
        public APD_ConfigurationController(IApprovalConfigurationService approvalConfigurationService)
        {
            _approvalConfigurationService = approvalConfigurationService;
        }

        [HttpGet]
        public async Task<List<ApprovalConfigurations>> GetApprovalConfigurations()
        {
            var result = await _approvalConfigurationService.GetApprovalConfigurationsAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> CreateConfiguration(ApprovalConfigurations approvalConfigurations)
        {
            try
            {
                var test = await _approvalConfigurationService.CreateConfig(approvalConfigurations);
       
                return Ok(test);
            }
            catch
            {
                return BadRequest();
            }
        }

        


    }
}
