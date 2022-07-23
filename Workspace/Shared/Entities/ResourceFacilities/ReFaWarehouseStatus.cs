using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ResourceFacilities
{
    public class ReFaWarehouseStatus
    {
        public Guid Id { get; set; }
        public string IssuedBy { get; set; }
        public int IssuedQty { get; set; }
        public string Comment { get; set; }
        public bool Issued { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsCancel { get; set; }
    }
}
