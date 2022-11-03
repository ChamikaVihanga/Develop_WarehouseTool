using ApprovalPath_Utils.Services.ApprovalConfigurationManagerService;
using ApprovalPath_Utils.Services.ApprovalConfigurationService;
using ApprovalPath_Utils.Services.ApprovalJobManagerService;
using ApprovalPath_Utils.Services.DefinitionValueService;
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
        private readonly IApprovalConfigurationManagerService _approvalConfigurationManagerService;
        private readonly IDefinitionValueService _definitionValueService;
        public APD_ConfigurationController(IApprovalConfigurationService approvalConfigurationService, IApprovalConfigurationManagerService approvalConfigurationManagerService, IDefinitionValueService definitionValueService)
        {
            _approvalConfigurationService = approvalConfigurationService;
            _approvalConfigurationManagerService = approvalConfigurationManagerService; 
            _definitionValueService = definitionValueService;
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

        [HttpPost]
        public async Task<DefinitionValues> testConf(Guid? defValId, List<ApprovalConfigurations> approvalConfigurations)
        {
            return await _definitionValueService.SetConfiguration(defValId, approvalConfigurations);

        }




    }
}
