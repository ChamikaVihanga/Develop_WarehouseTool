using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.Entities.Readonly
{
    public class SapEmployee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int SapNo { get; set; }
        public int? EpfNo { get; set; }
        public int? Rfid { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? LogonId { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? Salutaion { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string? Initials { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? LastName { get; set; }
        public string? FullName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? NickName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Position { get; set; }
        public Guid? WorkContractId { get; set; }

        //public Guid? OrganizationalUnitId { get; set; }
        //public Guid? PlantInfoId { get; set; }
        public DateTime? JoinDate { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? MaritalStatus { get; set; }
        public string? Address { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Location { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? EmployeeStatus { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Source { get; set; }
        public bool IsActive { get; set; } = true;


        public Guid SapOrganizationalUnitId { get; set; }
        public SapOrganizationalUnit SapOrganizationalUnit { get; set; }

        public Guid SapPlantId { get; set; }
        public SapPlant SapPlant { get; set; }

        public Guid SapWorkContractId { get; set; }
        public SapWorkContract SapWorkContract { get; set; }

    }
}
