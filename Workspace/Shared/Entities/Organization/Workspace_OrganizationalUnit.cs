

namespace Workspace.Shared.Entities
{
    public class Workspace_OrganizationalUnit
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
