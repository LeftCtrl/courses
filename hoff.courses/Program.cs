using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace hoff.courses
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) 
    {
      return Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) =>
        {
          builder.AddJsonFile("hoff.json");
        })
        .ConfigureLogging((hostingContext, builder) =>
        {
          IConfigurationSection? configuration = hostingContext.Configuration.GetSection("Logging");
          builder.AddFile(configuration);
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
    }
  }
}
