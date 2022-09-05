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
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
