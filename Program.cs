using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancePagination.Demo.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AdvancePagination.Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           IHost host = CreateHostBuilder(args).Build();
            //Run SeedUsers method from ApplicationDbContext
            using (var scope = host.Services.CreateScope())
            {
                System.Console.WriteLine("Seeding Sample Post");;
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                await PostsSeeder.SeedPosts(context);
               
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
