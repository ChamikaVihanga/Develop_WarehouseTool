using System.ComponentModel.DataAnnotations;

namespace Workspace.Shared.Entities.WorkspaceApp
{
    public class WsDomain
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
