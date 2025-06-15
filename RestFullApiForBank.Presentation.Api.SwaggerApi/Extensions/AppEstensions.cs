using RestFullApiForBank.Presentation.Api.SwaggerApi.Middleware;

namespace RestFullApiForBank.Presentation.Api.SwaggerApi.Extensions
{
    public static class AppEstensions
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
