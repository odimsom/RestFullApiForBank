using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestFullApiForBank.Core.Application.Behaviours;
using RestFullApiForBank.Core.Application.Wrappers;
using System.Reflection;

namespace RestFullApiForBank.Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Reguistrer automaper, fluentvalidator and mediatr
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            #endregion
        }
    }
}