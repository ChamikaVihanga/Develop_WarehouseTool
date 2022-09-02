using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.WorkspaceApp
{
    public class WsFeature
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FeatureCode { get; set; }
        public string Uri { get; set; }
        public bool IsActive { get; set; }
    }
}
