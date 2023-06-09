global using DataAccessLayer;
global using Microsoft.EntityFrameworkCore;
global using Workspace.Server.Services.LoginService;
global using Workspace.Server.Services.ResourceFacilityService;
global using Workspace.Shared;
global using Workspace.Shared.Entities.Readonly;
global using Workspace.Shared.Entities;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Workspace.Server.AuthorizationService.CustomPolicyDataProvider;
using Workspace.Server.AuthorizationService.Policies;
using Workspace.Server.AuthorizationService.PolicyHandler;
using Workspace.Server.Services.ClaimProviderService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// DB Connection 
//builder.Services.AddDbContext<WorkspaceDbContext>(options =>
//   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<WorkspaceDbContext>();

//DB connection for authorization requirements
//builder.Services.AddDbContext<AuthDbContext>(options =>
//   options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDb")));


builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// > > From Service Extension class
//builder.Services.ConfigureIISIntegration();

//Add the database exception filter
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// CORS configuration > > From Service Extension class
//builder.Services.ConfigureCors();

// Nlog > > from Contract Class Library
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// NLog > > From Service Extension Class
//builder.Services.ConfigureLoggerService();


//add auth policy
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:TokenKey").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,


        };
    });


builder.Services.AddHttpContextAccessor();

List<string> PoliciesList = new List<string>();
PoliciesList.Add("VSPolicy");

builder.Services.AddAuthorization(options =>
{
    foreach (string policy in PoliciesList)
    {
        string name = policy;
        options.AddPolicy(name, policy => policy.Requirements.Add(new CustomPolicy(name)));
    }
});


builder.Services.AddScoped<IAuthorizationHandler, CustomPolicyHandler>();

builder.Services.AddScoped<ICustomPolicyDataProvider, CustomPolicyDataProvider>();

// Register the Swagger services
builder.Services.AddSwaggerDocument();

//// Register the Swagger services
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//  System.Text.Json.JsonException: A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


builder.Services.AddScoped<IReFaRequestService, ReFaRequestService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IClaimProviderService, ClaimProviderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
