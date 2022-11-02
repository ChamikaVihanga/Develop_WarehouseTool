using System.ComponentModel.DataAnnotations;

namespace Workspace.Shared.Entities
{
    public class Warehouse_OperationSummeryDTO
    {
        [Required(ErrorMessage = "This field can't be empty")]
        public string? OperationName { get; set; }

        [Range(1, Int32.MaxValue)]
        [Required]
        public int? Target { get; set; }

        [Range(1, Int32.MaxValue)]
        [Required]
        public int? AllocatedTime { get; set; }
        [Required]
        public string? TimePeriod { get; set; }
        
        public DateTime EffectiveDate { get; set; }
        [Required]
        public string? OrganizationUnit { get; set; }
        public int? DTOid { get; set; }
    }
}
