namespace Workspace.Shared.Entities
{
    public class Workspace_User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid WsOrganizationalUnitId { get; set; }
    }
}
