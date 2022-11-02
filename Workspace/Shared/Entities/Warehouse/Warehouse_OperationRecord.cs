using System.ComponentModel.DataAnnotations;

namespace Workspace.Shared.Entities
{
    public class Warehouse_OperationRecord
    {
        public int Id { get; set; }

        //One to many

        public int? OperationListId { get; set; }
        public Warehouse_OperationList? OperationList { get; set; }




        public string? SAPNo { get; set; }
        //.....

        public DateTime StartTime { get; set; }

        
        public DateTime? EndTime { get; set; }

        //[Required(ErrorMessage = "")]
        public int? Achivement { get; set; }
        public int? Efficiency { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EndDate { get; set; }


    }
}
