using System;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
//using Microsoft.OpenApi.Models;


namespace CNSL_WepService
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("Initiating WebBuilder");
                    webBuilder.UseStartup<StartUp>();
                })
                .Build();

            host.Run();

        }

    }
    
}