using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Readonly
{
    public class SapPlant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Code { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; } = true;
        public List<SapCostCenter> SapCostCenters { get; set; }
    }
}
