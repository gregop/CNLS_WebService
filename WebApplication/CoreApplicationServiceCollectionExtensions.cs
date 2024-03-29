﻿using CNSL_WepService.APIResponses;
using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.Engines;
using FitnessApp.Core.Engines.Interfaces;
using FitnessApp.Core.Orchestrators;
using FitnessApp.Core.Orchestrators.Interfaces;
using FitnessApp.Core.ResourceAccess;
using FitnessApp.Core.ResourceAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace WebService.Core.Web
{
    public static class CoreApplicationServiceCollectionExtensions
    {

        public static IServiceCollection AddCoreApplicationResourceAccess(this IServiceCollection services)
        {
            services.AddTransient<IWorkoutItemResourceAccess, WorkoutItemResourceAccess>();
            services.AddTransient<IExerciseItemResourceAccess, ExerciseItemResourceAccess>();
            services.AddTransient<IExerciseSetsResourceAccess, ExerciseSetsResourceAccess>();
            services.AddTransient<IUserLoginActivityResourceAccess, UserLoginActivityResourceAccess>();
            services.AddTransient<IUserResourceAccess, UserResourceAccess>();
            services.AddTransient<IWorkoutExercisesHistoryResourceAccess, WorkoutExercisesHistoryResourceAccess>();
            services.AddTransient<IExerciseTypeResourceAccess, ExerciseTypeResourceAccess>();
            return services;
        }

        public static IServiceCollection AddCoreApplicationOrchestrators(this IServiceCollection services)
        {
            services.AddTransient<IWorkoutMessagesOrchestrator, WorkoutMessagesOrchestrator>();
            services.AddTransient<IExerciseMessagesOrchestrator, ExerciseMessagesOrchestrator>();
            return services;
        }

        public static IServiceCollection AddCoreApplicationEngines(this IServiceCollection services)
        {
            services.AddTransient<IWorkoutItemEngine, WorkoutItemEngine>();
            services.AddTransient<IExerciseItemEngine, ExerciseItemEngine>();
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
