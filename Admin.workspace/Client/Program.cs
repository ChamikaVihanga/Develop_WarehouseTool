global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
using MudBlazor.Services;

using admin.workspace.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using admin.workspace.Client.Interceptor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();


builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<InterceptorServiceGlobal>();

builder.Services.AddHttpClient("for InterceptorServiceGlobal", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress =
    new Uri(builder.HostEnvironment.BaseAddress)
}.EnableIntercept(sp));



builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("ITOnly", policy => policy.RequireClaim("Department", "IT"));

});

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
