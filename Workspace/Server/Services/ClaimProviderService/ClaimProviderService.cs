using System.Net.Http.Headers;
using Workspace.Shared.AuthData;

namespace Workspace.Server.Services.ClaimProviderService
{

    public class ClaimProviderService : IClaimProviderService
    {
        public async Task<List<AuthenticationClaimRequirement>?> GetClaims(string path, string method)
        {
            string authURI = "http://auth.workspace.vsag.ch";

            var http = new HttpClient();
            http.BaseAddress = new Uri(authURI);
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await http.GetFromJsonAsync<AuthenticationClaimRequirement[]>($"api/ClaimFilter?path={path}&&method={method}");

            if (response == null)
            {
                return null;
            }
            else
            {
                return response.ToList();
            }

        }

       
    }

}
