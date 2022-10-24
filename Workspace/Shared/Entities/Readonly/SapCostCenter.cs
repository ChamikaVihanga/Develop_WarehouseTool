using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Readonly
{
    public class SapCostCenter
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Code { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; } = true;

        public Guid SapPlantId { get; set; }
        public SapPlant SapPlant { get; set; }
        public List<SapOrganizationalUnit>? OrganizationalUnits { get; set; }
    }
}
