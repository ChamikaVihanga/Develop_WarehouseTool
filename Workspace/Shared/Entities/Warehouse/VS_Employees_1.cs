namespace Workspace.Shared.Entities.Warehouse
{
    public class VS_Employees_1
    {
        public int Id { get; set; }
        public string SapNo { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public string CostCenterID { get; set; }
        public string CostCenterName { get; set; }
        public string OrganizationalUnitID { get; set; }
        public string OrganizationalUnit { get; set; }

        public string Gender { get; set; }


        public string Address { get; set; }



        public List<ShiftGroup>? shiftGroups { get; set; }   
    }
}