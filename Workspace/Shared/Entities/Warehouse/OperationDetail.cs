namespace Workspace.Shared.Entities.Warehouse
{
    public class OperationDetail
    {
        public int Id { get; set; }

        //one to many relationship from OperationList 
        public int OperationListId { get; set; }
        public OperationList? OperationList { get; set; }
        public DateTime EffectiveDate { get; set; }

        //[Required]
        public int? Target { get; set; }
        public int? TimeSpan { get; set; }
        public string? TimePeriod { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string? OrganizationUnit { get; set; }
    }
}
