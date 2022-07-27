using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Warehouse
{
    public class OperationList
    {
        public int ID { get; set; }
        public string? Name { get; set; } = "Not set";
        public bool IsActive { get; set; }

        public List<OperationRecord>? OperationRecords { get; set; }
        public List<OperationDetail>? OperationDetails { get; set; } 


    }

}
