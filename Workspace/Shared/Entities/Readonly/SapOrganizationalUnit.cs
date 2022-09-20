using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Readonly
{
    public class SapOrganizationalUnit
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SapCostCenterId { get; set; }
    }
}
