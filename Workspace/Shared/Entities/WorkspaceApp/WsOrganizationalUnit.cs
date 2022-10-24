using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.WorkspaceApp
{
    public class WsOrganizationalUnit
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
