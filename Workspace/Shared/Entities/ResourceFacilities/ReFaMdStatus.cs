using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ResourceFacilities
{
    public class ReFaMdStatus
    {
        public Guid Id { get; set; }
        public bool Approval { get; set; }
        public string ApprovedBy { get; set; }
        public int ApprovedQty { get; set; }
        public string Comment { get; set; }
        public bool ApprovedDate { get; set; }
        public bool IsCancel { get; set; }

    }
}
