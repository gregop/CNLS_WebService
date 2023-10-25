using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using sysConfig = System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Core.ResourceAccess.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace WebService.Core.Web
{
    public static class CoreApplicationDbContextExtensions
    {
        private static readonly string _sqlConnectionString = sysConfig.ConfigurationManager
                    .ConnectionStrings["FitnessWebServiceDb"]
                    .ConnectionString;

        public static IServiceCollection AddSqlServerApplicationDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<WorkoutItemDbContext>(options =>
            {
                options.UseSqlServer(_sqlConnectionString);
            });

            services.AddDbContext<ExerciseItemDbContext>(options =>
            {
                options.UseSqlServer(_sqlConnectionString);
            });

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(_sqlConnectionString);
            });

            return services;
        }

        public static IServiceCollection AddCoreApplicationDbContexts(this IServiceCollection services)
        {
            return services
                .AddSqlServerApplicationDbContexts();
        }
    }
}
