using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.WorkspaceApp
{
    public class WsUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public Guid WsOrganizationalUnitId { get; set; }
    }
}
