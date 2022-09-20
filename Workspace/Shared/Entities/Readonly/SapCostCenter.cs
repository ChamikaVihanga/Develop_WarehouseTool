using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Readonly
{
    public class SapCostCenter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SapEmployeeId { get; set; }
    }
}
