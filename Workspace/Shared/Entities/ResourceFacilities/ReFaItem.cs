using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ResourceFacilities
{
    public class ReFaItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Uom { get; set; }
        public bool IsActive { get; set; } = true;



    }
}
