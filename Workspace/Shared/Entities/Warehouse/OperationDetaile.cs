#nullable disable

namespace Workspace.Shared.Entities.Warehouse
{
    public class OperationDetaile
    {

        public int Id { get; set; }
        //one to many
        public int OperationListId { get; set; }
        public OperationList OperationList { get; set; }
        //..
        public DateTime EffectiveDate { get; set; }
        public int Target { get; set; }
        public int TimeSpan { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }

        /*public List<OperationList> operationLists { get; set; }*/



    }
}
