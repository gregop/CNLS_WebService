using CNSL_WepService.APIResponses;
using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.Engines;
using FitnessApp.Core.Orchestrators;
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
