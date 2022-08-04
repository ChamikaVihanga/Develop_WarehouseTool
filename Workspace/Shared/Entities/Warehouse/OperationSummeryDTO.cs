using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Warehouse
{
    public class OperationSummeryDTO
    {
        [Required(ErrorMessage = "This field can't be empty")]
        public string? OperationName { get; set; }

        [Range(1, Int32.MaxValue)]
        [Required]
        public int? Target { get; set; }
        [Required]
        public int? AllocatedTime { get; set; }
        [Required]
        public string? TimePeriod { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }    
        public int? DTOid { get; set; }
    }
}
