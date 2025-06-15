using Asp.Versioning;

namespace RestFullApiForBank.Presentation.Api.SwaggerApi.Extensions
{
    public static class ServiceExtencions
    {
        public static void AddApiVersioningExtensions(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}