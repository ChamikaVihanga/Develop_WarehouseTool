global using Microsoft.EntityFrameworkCore;


global using DataAccessLayer;

global using Workspace.Shared;
global using Workspace.Shared.Entities.Readonly;
global using Workspace.Shared.AuthData;


global using admin.workspace.Server.Authorization;
global using Microsoft.AspNetCore.Authorization;
global using admin.workspace.Server.Authorization.Handlers;
global using admin.workspace.Server.Authorization.DataProviderInterfaces;
global using admin.workspace.Server.Authorization.DataProviders;


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;

using System.Text.Json;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});


// Add services to the container.
builder.Services.AddDbContext<WorkspaceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//Adding JWT authorization services to application
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:TokenKey").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };
    });


//Register service to access URI
builder.Services.AddHttpContextAccessor();

List<string> PoliciesList = new List<string>();
PoliciesList.Add("VSPolicy");

//Register application policies for authorizaiton
builder.Services.AddAuthorization(options =>
{
    


    foreach (string policy in PoliciesList)
    {
        string name = policy;
        options.AddPolicy(name, policy => policy.Requirements.Add(new CustomClaimRequirement(name)));
    }

});



//Adding authorization data providers to the applicaiton
builder.Services.AddScoped<IAuthorizationHandler, CustomClaimCheckerHandler>();

builder.Services.AddScoped<ICustomClaimChecker, CustomClaimChecker>();


var app = builder.Build();
app.UseRouting();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
       string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
  
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseCors(MyAllowSpecificOrigins);

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("index.html");



app.Run();
