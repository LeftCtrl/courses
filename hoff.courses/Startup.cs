using hoff.courses.BL.Services;
using hoff.courses.BL.Services.Implementation;
using hoff.courses.Core.Cbr;
using hoff.courses.Core.Cbr.Implementation;
using hoff.courses.Core.DataProvider;
using hoff.courses.Core.DataProvider.Implementation;
using hoff.courses.Core.Geometry;
using hoff.courses.Core.Geometry.Implementation;
using hoff.courses.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace hoff.courses
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services
        .AddControllers()
        .AddJsonOptions(options =>
        {
          options.JsonSerializerOptions.Converters.Add(new LocalDateJsonConverter("yyyyMMdd"));
        });

      IConfigurationSection? hoffConfig = Configuration.GetSection("hoff");
      services
        .Configure<CourseOptions>(hoffConfig)
        .Configure<CbrOptions>(hoffConfig);

      services
        .AddSingleton<IGeometryService, GeometryService>()
        .AddSingleton<ICbrService, CbrService>()
        .AddSingleton<IDataProvider, DataProvider>()
        .AddSingleton<ICourseService, CourseService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
