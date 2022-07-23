


namespace Workspace.Server.Extensions
{
    public static class ServiceExtensions
    {
        //CORS Configuration
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


        //IIS Configuration
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });


        // Implement NLog
        //public static void ConfigureLoggerService(this IServiceCollection services)
           // => services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
