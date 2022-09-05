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
        public string Title { get; set; }
    }
}
