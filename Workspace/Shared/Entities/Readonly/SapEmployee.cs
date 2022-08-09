using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Readonly
{
    public class SapEmployee
    {
        public Guid Id { get; set; }
        public int SapNo { get; set; }
        public int EpfNo { get; set; }
        public int Rfid { get; set; }
        public string LogonId { get; set; }
        public string Salutaion { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Position { get; set; }
        public Guid WorkContractId { get; set; }
        public Guid OrganizationalUnitId { get; set; }
        public Guid PlantInfoId { get; set; }
        public DateTime JoinDate { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string EmployeeStatus { get; set; }
        public string Source { get; set; }

    }
}
