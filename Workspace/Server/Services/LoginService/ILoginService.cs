namespace Workspace.Server.Services.LoginService
{
    public interface ILoginService
    {
        Task<string> Login(string username, string password);
    }
}
