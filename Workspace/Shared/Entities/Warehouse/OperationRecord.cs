using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Warehouse
{
    public class OperationRecord
    {
        public int Id { get; set; }


        // one to many relationship from OperationList
        public int OperationListId { get; set; }
        public OperationList? OperationList { get; set; }   
        //

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Achivement { get; set; }
        public string Efficiency { get; set; }
        public DateTime CreateDate { get; set; }



    }
}
