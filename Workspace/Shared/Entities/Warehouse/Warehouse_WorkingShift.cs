namespace Workspace.Shared.Entities.Warehouse
{
    public class Warehouse_WorkingShift
    {
        public int Id { get; set; }
        public string? ShiftTitle { get; set; }
        public string? ShiftDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }       
    }
}
