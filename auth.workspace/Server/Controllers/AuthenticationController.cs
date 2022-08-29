using auth.workspace.Server.Utils;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.DirectoryServices.AccountManagement;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;



namespace auth.workspace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly WorkspaceDbContext _context;
        public AuthenticationController(IConfiguration Config, WorkspaceDbContext context)
        {
            _context = context;
            _configuration = Config;
        }
        [HttpPost("Login-User")]
        public async Task<ActionResult<string>> Login(UserLoginDTO request)
        {
            bool validation = false;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "VSAG.CH", "lkittrainee01", "Sl@987654321"))
            {
                validation = context.ValidateCredentials(request.UserName, request.Password);
                UserPrincipal adUser = UserPrincipal.FindByIdentity(context, request.UserName);
                if (adUser != null)
                {
                    user.DisplayName = adUser.DisplayName;


                    PrincipalSearchResult<Principal> userGroups = adUser.GetAuthorizationGroups();
                    if (userGroups != null)
                    {
                        List<Guid?> guids = new List<Guid?>();
                        foreach (var group in userGroups)
                        {
                            guids.Add(group.Guid);
                        }
                        user.AdGroups = guids;
                    }

                }

            }

            if (validation)
            {
                user.Name = request.UserName;

                string jwt = await CreateToken(user);
                var refreshToken = GenerateRefreshToken();
                SetRefreshToken(refreshToken);

                return jwt;
            }

            return Ok("Invalid Credentials");
        }

     
        //Modify the 
        //add token validation
        [HttpPost("refresh-Token")]
        public async Task<ActionResult<string>> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = await CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);
            return token;
        }



        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(1),
                Created = DateTime.Now
            };
            return refreshToken;
        }
        private void SetRefreshToken(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
            };
            Response.Cookies.Append("RefreshToken", refreshToken.Token, cookieOptions);
            user.RefreshToken = refreshToken.Token;
            user.TokenCreated = refreshToken.Created;
            user.TokenExpires = refreshToken.Expires;
        }

        private async Task<string> CreateToken(User user)
        {

            List<DataTransferObject.ClaimValue<string>>? claimValues = await getUserClaims(user.Name);
            List<Claim>? claims = new List<Claim>();
            if (claimValues?.Count > 0)
            {
                foreach (var claim in claimValues)
                {
                    claims.Add(new Claim(claim.Claim, claim.Value));
                }
            }


            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim("DisplayName", user.DisplayName));
            if (user.AdGroups != null)
            {
                foreach (var guid in user.AdGroups)
                {
                    if (guid is not null)
                    {
                        claims.Add(new Claim("ActiveDirectoryGroups", guid.Value.ToString()));

                    }
                }
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenKey").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "VSAG",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private async Task<List<DataTransferObject.ClaimValue<string>>?> getUserClaims(string username)
        {
            var userClaims = _context.AuthenticationUserClaimsHolders.Where(x => x.UserName == username)
                .Include(a => a.authenticationClaimValues)
                .ThenInclude(b => b.AuthenticationClaim).ToList();

            if (userClaims.Count > 0)
            {
                var user = userClaims.Last();
                List<DataTransferObject.ClaimValue<string>> claimValues = new List<DataTransferObject.ClaimValue<string>>();

                if (user.authenticationClaimValues?.Count > 0)
                {
                    foreach (var claimValue in user.authenticationClaimValues)
                    {
                        claimValues.Add(new DataTransferObject.ClaimValue<string> { Claim = claimValue.AuthenticationClaim?.Claim, Value = claimValue.Value });
                    }
                    return claimValues;
                }
            }


            return null;

        }


    }

}
