using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Mybarber.Helpers;

namespace Mybarber
{
    public class Program
    {
        public static void Main(string[] args)
       {
            
            CreateHostBuilder(args).Build().Run();


           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
