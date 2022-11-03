using ApprovalPath_Utils.Services.ApprovalDestinationPathsService;
using ApprovalPath_Utils.Services.ApprovalDocuementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace ApprovalPath_Utils.Services.ApprovalConfigurationManagerService
{
    public class ApprovalConfigurationManagerService : IApprovalConfigurationManagerService
    {
        private readonly IApprovalDestinationPathsService _destinationPathsService;
        private readonly IApprovalDocuementService _approvalDocuementService;
        public ApprovalConfigurationManagerService(IApprovalDestinationPathsService approvalDestinationPathsService, IApprovalDocuementService approvalDocuementService)
        {
            _destinationPathsService = approvalDestinationPathsService;
            _approvalDocuementService = approvalDocuementService;
        }

        public async Task<List<ApprovalConfigurations>> setConfigs(List<ApprovalConfigurations> configs)
        {
            return await MergeConfigurations(configs);

        }

        private async Task<List<ApprovalConfigurations>> MergeConfigurations(List<ApprovalConfigurations> configs)
        {
            List<ApprovalConfigurations>? newConfigs = new List<ApprovalConfigurations>();
            foreach (ApprovalConfigurations config in configs)
            {
                ApprovalConfigurations tempConf = new ApprovalConfigurations();
                tempConf.ApprovalConfigurationId = Guid.NewGuid();
                List<ApprovalDestinations> approvalDestinations = new List<ApprovalDestinations>();
                foreach (var destination in config.ApprovalDestinations)
                {
                    var newDestination = await _destinationPathsService.createDestination(destination);
                    approvalDestinations.Add(newDestination);
                }
                tempConf.ApprovalDestinations = approvalDestinations;


                List<ApprovalDocuments> approvalDocuments = new List<ApprovalDocuments>();  

                ApprovalConfigurations? MatchingConf = newConfigs.Where(a => a.ApprovalDestinations.OrderBy(a => a.ApprovalDestinationId).SequenceEqual(tempConf.ApprovalDestinations.OrderBy(a => a.ApprovalDestinationId))).FirstOrDefault();
                if(MatchingConf != null)
                {
                    
                    foreach(var doc in config.ApprovalDocuments)
                    {
                        approvalDocuments.Add(await _approvalDocuementService.AddApprovalDocument(doc));
                    }
                    approvalDocuments.AddRange(MatchingConf.ApprovalDocuments);

                    MatchingConf.ApprovalDocuments = approvalDocuments;
                    newConfigs.Remove(newConfigs.Where(a => a.ApprovalConfigurationId == MatchingConf.ApprovalConfigurationId).FirstOrDefault());
                    newConfigs.Add(MatchingConf);
                }
                else
                {
                    foreach (var doc in config.ApprovalDocuments)
                    {

                        approvalDocuments.Add(await _approvalDocuementService.AddApprovalDocument(doc));


                    }
                    tempConf.ApprovalConfigurationId = Guid.NewGuid();
                    tempConf.ApprovalDocuments = approvalDocuments;
                    newConfigs.Add(tempConf);
                }
            }
            return newConfigs;
        }
    }
}
