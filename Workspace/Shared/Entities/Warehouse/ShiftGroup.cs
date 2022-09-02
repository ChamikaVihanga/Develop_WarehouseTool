namespace Workspace.Shared.Entities.Warehouse
{
    public class ShiftGroup
    {
        public int Id { get; set; }
        public string? GroupTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //one to many
        public int WorkingShiftId { get; set; }
        public WorkingShifts? WorkingShifts { get; set; }

        public List<VS_Employees_1>? VS_Employees { get; set; }
    }
}
