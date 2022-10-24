using admin.workspace.Server.Services.ReadOnly;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace admin.workspace.Server.Controllers.ReadOnly
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SapEmployeeExtractionsController : ControllerBase
    {
        private ISapEmployeeExtraction _iSapEmployeeExtraction;
        private readonly IEnumerable<EndpointDataSource> _endpointSources;

        public SapEmployeeExtractionsController(ISapEmployeeExtraction iSapEmployeeExtraction, IEnumerable<EndpointDataSource> endpointSources)
        {
            _iSapEmployeeExtraction = iSapEmployeeExtraction;
            _endpointSources = endpointSources;
        }

        [HttpGet]
        public async Task<ActionResult<SapEmployee>> GetAllVsEmployees()

        {
            var result = await _iSapEmployeeExtraction.GetSapEmployees();
            return Ok(result);

        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SapEmployee>> GetAllVsEmployees(int id)

        {
            var result = await _iSapEmployeeExtraction.GetSapEmployees();
            return Ok(result);

        }


        [HttpGet]
        public async Task<ActionResult<SapPlant>> UpdateSapPlants()
        {
            var result = await _iSapEmployeeExtraction.GetUpdatedSapPlants();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<SapCostCenter>> UpdateSapCostCenters()
        {
            var result = await _iSapEmployeeExtraction.GetUpdatedSapCostCenters();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<SapCostCenter>> SapOrganizationalUnits()
        {
            var result = await _iSapEmployeeExtraction.GetUpdatedSapOrganizationalUnits();
            return Ok(result);
        }







        [HttpGet]
        public async Task<ActionResult> ListAllEndpoints()
        {
            var endpoints = _endpointSources
                .SelectMany(es => es.Endpoints)
                .OfType<RouteEndpoint>();
            var output = endpoints.Select(
                e =>
                {
                    var controller = e.Metadata
                        .OfType<ControllerActionDescriptor>()
                        .FirstOrDefault();
                    var action = controller != null
                        ? $"{controller.ControllerName}.{controller.ActionName}"
                        : null;
                    var controllerMethod = controller != null
                        ? $"{controller.ControllerTypeInfo.FullName}:{controller.MethodInfo.Name}"
                        : null;
                    
                    return new
                    {
                        Method = e.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods?[0],
                        Route = $"/{e.RoutePattern.RawText.TrimStart('/')}",
                        Action = action,
                        ControllerMethod = controllerMethod
                    };
                }
            );
            return Ok(output);
        }
    }
}
