using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ResourceFacilities
{
    public class ReFaFinanceStatus
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int IssuedQty { get; set; }
        public decimal TotalPrice { get; set; }

        //Collected By
        public Guid EmployeeId { get; set; }

        //public int IssuedQty { get; set; }
        public string Comment { get; set; }
        public bool Collected { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsCancel { get; set; }
    }
}
