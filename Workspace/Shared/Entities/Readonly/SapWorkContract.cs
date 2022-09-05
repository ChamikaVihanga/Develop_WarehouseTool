using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Readonly
{
    public class SapWorkContract
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Level { get; set; }
        public string Description { get; set; }
    }
}
