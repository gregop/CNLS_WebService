﻿using CNSL_WepService.APIResponses;
using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.Engines;
using FitnessApp.Core.Orchestrators;
using FitnessApp.Core.ResourceAccess;
using Microsoft.Extensions.DependencyInjection;


namespace WebService.Core.Web
{
    public static class CoreApplicationServiceCollectionExtensions
    {

        public static IServiceCollection AddCoreApplicationResourceAccess(this IServiceCollection services)
        {
            services.AddTransient<WorkoutItemResourceAccess>();

            return services;
        }

        public static IServiceCollection AddCoreApplicationOrchestrators(this IServiceCollection services)
        {
            services.AddTransient<WorkoutMessagesOrchestrator>();

            return services;
        }

        public static IServiceCollection AddCoreApplicationEngines(this IServiceCollection services)
        {
            services.AddTransient<WorkoutItemEngine>();

            return services;
        }


        public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services) 
        {
            return services
                .AddCoreApplicationResourceAccess()
                .AddCoreApplicationOrchestrators()
                .AddCoreApplicationEngines();
        }
    }
}