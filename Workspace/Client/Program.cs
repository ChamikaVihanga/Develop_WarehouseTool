global using System.Net.Http.Json;
global using Workspace.Shared;
global using Workspace.Client.Services.ResourceFacilityService;
global using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Workspace.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Workspace.Client.Auth_Service;
using Workspace.Client.Interceptor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("ITOnly", policy => policy.RequireClaim("Department", "IT"));
});


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress =
    new Uri(builder.HostEnvironment.BaseAddress) //+ "api/"
}.EnableIntercept(sp)); // For Loader

builder.Services.AddMudServices();


builder.Services.AddLoadingBar();
builder.UseLoadingBar(); // declare construct loading bar UI.

builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<GlobalErrorHandler>();

builder.Services.AddScoped<IReFaRequestService, ReFaRequestService>();
builder.Services.AddBlazoredLocalStorage();


await builder.Build().RunAsync();
