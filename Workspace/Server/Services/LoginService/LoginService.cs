using System.Net.Http;
using System.Net.Http.Headers;
using Workspace.Shared.DataTransferLayer;

namespace Workspace.Server.Services.LoginService
{
    public class LoginService : ILoginService
    {
        public async Task<string> Login(string username, string password)
        {
            dto.UserLogin userLoginDTO = new dto.UserLogin();
            userLoginDTO.UserName = username;
            userLoginDTO.Password = password;

            string authURI = "http://auth.workspace.vsag.ch";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(authURI);
                httpClient.DefaultRequestHeaders.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.PostAsJsonAsync<dto.UserLogin>("api/Authentication/Login-User", userLoginDTO);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return string.Empty;
                }

            }
        }
    }

}
