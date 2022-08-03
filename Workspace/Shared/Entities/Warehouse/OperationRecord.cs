using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Workspace.Shared.Entities.Warehouse
{
    public class OperationRecord
    {
        public int Id { get; set; }

        //One to many
        
        public int? OperationListId { get; set; }
        public OperationList? OperationList { get; set; }

        
        public int VS_EmployeesId { get; set; }
        public VS_Employees? VS_Employees { get; set; }
        //.....

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //[Required(ErrorMessage = "")]
        public int? Achivement { get; set; }
        public int? Efficiency { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
