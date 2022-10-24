using ApprovalPath_Utils.Services.ApprovalDocuementService;
using ApprovalPath_Utils.Services.ApprovalJobManagerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalPath_Utils.ApprovalPathService
{
    public interface IApprovalPathService : IApprovalDocuementService, IApprovalJobManagerService
    {

    }
}
