using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.Warehouse;

namespace Workspace.Shared.Entities.Warehouse
{
    public class VS_Employees
    {
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FullName { get; set; }

        public string OrganizationalUnit { get; set; }

        public string Gender { get; set; }


        public string Address { get; set; }

        //relation
        public List<OperationRecord>? OperationRecords { get; set; }
    }
}