namespace Workspace.Shared.Entities
{
    public class Warehouse_OperationList
    {
        public int Id { get; set; }
        public string? Name { get; set; } = "Not set";
        public bool IsActive { get; set; }
        public List<Warehouse_OperationRecord>? Warehouse_OperationRecords { get; set; }
        public List<Warehouse_OperationDetail>? Warehouse_OperationDetails { get; set; }
    }
}
