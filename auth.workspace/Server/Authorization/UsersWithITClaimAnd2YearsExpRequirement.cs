﻿using Microsoft.AspNetCore.Authorization;

namespace admin.workspace.Server.Authorization
{
    public class UsersWithITClaimAnd2YearsExpRequirement : IAuthorizationRequirement
    {
        public UsersWithITClaimAnd2YearsExpRequirement(int years0)
        {
            years = years0;
        }
        public int years { get; set; }
    }
}
