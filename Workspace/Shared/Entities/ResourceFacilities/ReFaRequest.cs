using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.ResourceFacilities
{
    /// <summary>
    /// Resourse and Facility Request
    /// </summary>
    public class ReFaRequest
    {
        public Guid Id { get; set; }

        //RequestedBy
        public Guid EmployeeId { get; set; }
        public string? RequestedFor { get; set; }
        public DateTime RequestedDate { get; set; } 
        public string? Comment { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }


        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;

    }
}
