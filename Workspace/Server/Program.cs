global using Workspace.Shared;
global using Microsoft.EntityFrameworkCore;
global using Workspace.Server.Services.ResourceFacilityService;

using Microsoft.AspNetCore.ResponseCompression;
using Workspace.Server.Data;
using Workspace.Server.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// DB Connection 
builder.Services.AddDbContext<WorkspaceDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// > > From Service Extension classb
//builder.Services.ConfigureIISIntegration();

//Add the database exception filter
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// CORS configuration > > From Service Extension class
//builder.Services.ConfigureCors();

// Nlog > > from Contract Class Library
//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// NLog > > From Service Extension Class
//builder.Services.ConfigureLoggerService();

// Register the Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//  System.Text.Json.JsonException: A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


builder.Services.AddScoped<IReFaRequestService, ReFaRequestService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
