using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using CNSL_WepService.APIResponses;
using FitnessApp.Core.ResourceAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using sysCongif = System.Configuration;
using FitnessApp.Core.ResourceAccess;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.Orchestrators;
using FitnessApp.Core.Engines;

namespace CNSL_WepService
{
    public class StartUp
    {

        public static void ConfigureServices(IServiceCollection services)
        {

            //WebApplicationBuilder builder = WebApplication.CreateBuilder();

            /* Validation errors automatically trigger an HTTP 400 response.
            * e.g. 
            * {
            *   "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            *   "title": "One or more validation errors occurred.",
            *   "status": 400,
            *   "traceId": "00-15f1e9bcd75d2e0afdbf9cbe657f16d9-6e5f8d80a4acb7c2-00",
            *   "errors": {
            *   "Id": [
            *           "The value '11.5' is not valid for Id."
            *       ]
            *   }
            * }
            * 
            * -> Turn off this feature
            */
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.SuppressMapClientErrors = true;
            });

            /*
             * DBContexts             
             */
            services.AddDbContext<WorkoutItemDbContext>(options =>
            {
                options.UseSqlServer(sysCongif.ConfigurationManager
                    .ConnectionStrings["FitnessWebServiceDb"]
                    .ConnectionString);
            });


            services.AddTransient<IGetWorkoutApiRes, GetWorkoutApiRes>();
            services.AddTransient<IRegisterWorkoutApiRes, RegisterWorkoutApiRes>();
            services.AddTransient<WorkoutItemResourceAccess>();
            services.AddTransient<WorkoutMessagesOrchestrator>();
            services.AddTransient<WorkoutItemEngine>();


            Console.WriteLine("ConfigureServices");
            services.AddControllers();
            //services.AddHttpContextAccessor();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine("Adding API Behaviours");

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        static void Main(string[] args)
        {

            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("Initiating WebBuilder");

                    // Adding hosting.json to configuration from Project Directory
                    IConfigurationBuilder configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)
                        .AddJsonFile($"hosting.json");

                    // Build hosting configuration
                    IConfiguration hostConfig = configuration.Build();

                    try
                    {
                        // retreiving host url
                        string hostUrl = hostConfig["hosts:default"].ToString();
                        webBuilder.UseStartup<StartUp>();
                        webBuilder.UseUrls(hostUrl);

                    } catch (Exception ex) 
                    {
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine("Couldn't retrieve host. Check hosting.json file");
                        System.Environment.Exit(1);
                    }
                  
                })
                .Build();

            host.Run();

        }
    }
}
