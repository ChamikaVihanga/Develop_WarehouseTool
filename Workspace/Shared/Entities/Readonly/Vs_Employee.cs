using System.ComponentModel.DataAnnotations;

namespace Workspace.Shared.Entities.Readonly
{
    public class Vs_Employee
    {

        //[SAPNo][varchar] (5) NOT NULL,
        [Key]
        public string SAPNo { get; set; }

        //[EPFNo] [varchar] (6) NULL,
        public string EPFNo { get; set; }

        //[RFID][varchar] (8) NULL,
        public string RFID { get; set; }

        //[SysUserID][varchar] (20) NULL,
        public string SysUserID { get; set; }

        //[Salutation][varchar] (5) NULL,
        public string Salutation { get; set; }

        //[Initials][varchar] (20) NULL,
        public string Initials { get; set; }

        //[LastName][varchar] (50) NULL,
        public string LastName { get; set; }

        //[FullName][text] NULL,
        public string FullName { get; set; }

        //[WorkContract][varchar] (50) NULL,
        public string WorkContract { get; set; }

        //[EmpLevel][int] NULL,
        public int EmpLevel { get; set; }

        //[CostCenterID][varchar] (6) NULL,
        public string CostCenterID { get; set; }

        //[CostCenterName][varchar] (30) NULL,
        public string CostCenterName { get; set; }

        //[OrganizationalUnitID][varchar] (100) NULL,
        public string OrganizationalUnitID { get; set; }

        //[OrganizationalUnit][varchar] (40) NULL,
        public string OrganizationalUnit { get; set; }

        //[Position][text] NULL,
        public string Position { get; set; }

        //[JoinDate][datetime] NULL,
        public DateTime JoinDate { get; set; }

        //[Gender][varchar] (6) NULL,
        public string Gender { get; set; }

        //[NickName][varchar] (30) NULL,
        public string NickName { get; set; }

        //[BirthDay][datetime] NULL,
        public DateTime BirthDay { get; set; }

        //[MaritalStatus][varchar] (7) NULL,
        public string MaritalStatus { get; set; }

        //[Religion][text] NULL,
        public string Religion { get; set; }

        //[CountryCode][varchar] (4) NULL,
        public string CountryCode { get; set; }

        //[Address][text] NULL,
        public string Address { get; set; }

        //[Location][text] NULL,
        public string Location { get; set; }

        //[EmployeeStatus][varchar] (30) NULL
        public string EmployeeStatus { get; set; }

    }
}
