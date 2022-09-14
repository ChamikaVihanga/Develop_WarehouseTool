using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workspace.Shared.Entities.Readonly
{
    /// <summary>
    /// Do not change anything in this class... Thank you...
    /// </summary>
    public class Vs_Employee
    {
        [Key]
        [Column(TypeName = "varchar(5)")]
        public string? SAPNo { get; set; }
        [Column(TypeName = "varchar(6)")]
        public string? EPFNo { get; set; }
        [Column(TypeName = "varchar(8)")]
        public string? RFID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? SysUserID { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string? Salutation { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Initials { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? LastName { get; set; }
        //[FullName][text] NULL,
        public string? FullName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? WorkContract { get; set; }
        public int? EmpLevel { get; set; }
        [Column(TypeName = "varchar(6)")]
        public string? CostCenterID { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string? CostCenterName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? OrganizationalUnitID { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string? OrganizationalUnit { get; set; }
        //[Position][text] NULL,
        public string Position { get; set; }
        public DateTime? JoinDate { get; set; }
        [Column(TypeName = "varchar(6)")]
        public string? Gender { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string? NickName { get; set; }
        public DateTime? BirthDay { get; set; }
        [Column(TypeName = "varchar(7)")]
        public string? MaritalStatus { get; set; }
        //[Religion][text] NULL,
        public string Religion { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string? CountryCode { get; set; }
        //[Address][text] NULL,
        public string Address { get; set; }
        //[Location][text] NULL,
        public string Location { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string? EmployeeStatus { get; set; }
    }
}
