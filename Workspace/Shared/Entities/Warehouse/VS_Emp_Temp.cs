using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Warehouse
{
    public class VS_Emp_Temp
    {
        public int Id { get; set; }
        public string SapNo { get; set; }
        public string FullName { get; set; }
        public string OrganizationalUnit { get; set; }
        public string Position { get; set; }
        public string OrganizationalUnitID { get; set; }
        public string CostCenterID { get; set; }
        public string CostCenterName { get; set; }
        public string NickName { get; set; }
    }
}
