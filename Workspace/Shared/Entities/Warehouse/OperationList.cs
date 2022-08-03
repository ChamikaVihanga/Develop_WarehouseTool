using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Shared.Entities.Warehouse;

namespace Workspace.Shared.Entities.Warehouse
{
    public class OperationList
    {
        public int Id { get; set;}


        /*  public int OperationDetaileId { get; set;}
          public OperationDetaile OperationDetaile { get; set;}*/

        [Required(ErrorMessage = "This field can't be empty")]
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<OperationDetaile>? OperationDetailes { get; set; }

        public List<OperationRecord>? OperationRecords { get; set; }

    }
}
