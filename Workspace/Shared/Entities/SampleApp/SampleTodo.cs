using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.SampleApp
{
    public class SampleTodo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
