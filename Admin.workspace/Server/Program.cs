global using admin.workspace.Server.Authorization;
global using admin.workspace.Server.Authorization.DataProviderInterfaces;
global using admin.workspace.Server.Authorization.DataProviders;
global using admin.workspace.Server.Authorization.Handlers;
global using DataAccessLayer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using Workspace.Shared.AuthData;
global using Workspace.Shared.Entities;
global using Workspace.Shared.Entities.Readonly;
using admin.workspace.Server.Services.ReadOnly;
using ApprovalPath_Utils.ApprovalPathService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NSwag.Generation.Processors.Security;
using NSwag;
using System.Text;
using System.Text.Json.Serialization;

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
//builder.Services.AddDbContext<WorkspaceDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddDbContext<WorkspaceDbContext>();


//Swapped NewtonJson to System.Text.Json.Serialization namespace
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles


);
builder.Services.AddRazorPages();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//    {
//        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey
//    });

//    options.OperationFilter<SecurityRequirementsOperationFilter>();
//});

// Register the Swagger services
builder.Services.AddSwaggerDocument();



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



//Adding approval path services
builder.Services.AddApprovalPathProvider();



#region SAP Read Only tables

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISapEmployeeExtraction, SapEmployeeExtraction>();


#endregion SAP Read Only tables



var app = builder.Build();
app.UseRouting();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
       string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));
    app.UseWebAssemblyDebugging();
    //app.UseSwagger();
    //app.UseSwaggerUI();

    // Register the Swagger generator and the Swagger UI middlewares
    app.UseOpenApi();
    app.UseSwaggerUi3();

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
