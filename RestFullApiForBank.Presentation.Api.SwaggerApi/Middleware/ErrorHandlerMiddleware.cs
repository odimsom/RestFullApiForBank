using RestFullApiForBank.Core.Application.Exeptions;
using RestFullApiForBank.Core.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace RestFullApiForBank.Presentation.Api.SwaggerApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string> { Succeeded = false, Message = error!.Message };
                switch (error)
                {
                    case ApiExeptions e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationExeptions e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                };

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
