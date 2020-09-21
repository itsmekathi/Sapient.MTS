using Microsoft.Extensions.DependencyInjection;
using Sapient.MTS.Application.Repositories;
using Sapient.MTS.Application.Repositories.Interfaces;
using Sapient.MTS.Application.Services;
using Sapient.MTS.Application.Services.Interfaces;
using Sapient.MTS.Common.Infrastructure;
using Sapient.MTS.Common.Interfaces;
using Sapient.MTS.Persistence.Context;

namespace Sapient.MTS.WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddAllApplicationServices(this IServiceCollection services)
        {
            services.AddApplicationDbContext();
            services.AddApplicationServices();
            return services;
        }
        private static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
        {
            services.AddScoped<MedicinesContext>();
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ILogger, ConsoleLogger>();
            services.AddScoped<IMedicinesRepository, MedicinesRepository>();
            services.AddScoped<IMedicinesService, MedicinesService>();
            return services;
        }
    }
}
