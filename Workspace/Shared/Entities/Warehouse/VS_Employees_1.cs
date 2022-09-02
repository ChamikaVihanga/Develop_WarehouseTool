namespace Workspace.Shared.Entities.Warehouse
{
    public class VS_Employees_1

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