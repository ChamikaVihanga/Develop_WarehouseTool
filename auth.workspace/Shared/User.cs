using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty; 

        public List<Guid?>? AdGroups { get; set; } 
        public string RefreshToken { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
