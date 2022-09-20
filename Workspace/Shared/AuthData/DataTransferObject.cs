using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Shared.AuthData
{
    public class DataTransferObject
    {
        public class ClaimDTO
        {
            public int ClaimId { get; set; }
            public string ClaimName { get; set; }

        }
        public class ClaimValueDTO
        {
            public int? ClaimId { get; set; }
            public int? ValueId { get; set; }
            public int? RequirementId { get; set; }
            public string? newClaimName { get; set; }
            public List<string>? Values { get; set; }
        }
        public class ClaimValue<T>
        {
            public T? Claim { get; set; }
            public T? Value { get; set; }
        }
        public class ClaimValues
        {
            public string? username { get; set; }
            public int? ClaimId { get; set; }
            public string? claimName { get; set; }
            public int? ValueId { get; set; }
            public string? Value { get; set; }
        }
        public class TransferAdGroups
        {
            public Guid AdGroupGuid { get; set; }
            public int EndPointId { get; set; }
        }

    }
}
