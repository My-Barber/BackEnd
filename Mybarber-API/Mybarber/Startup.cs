using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Mybarber.Config;
using Mybarber.Helpers;
using Mybarber.Persistencia;
using Mybarber.Presenter;
using Mybarber.Presenters;
using Mybarber.Repositories;
using Mybarber.Repository;
using Mybarber.Services;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mybarber
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

            services.AddControllers()
               .AddNewtonsoftJson(opt => opt.SerializerSettings
               .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            Authentication.AddAuthentication(services);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            Cors.AddCors(services);

            Scopeds.GetScoped(services);

            Swagger.AddSwager(services);

            DbContextClass.AddDbContext(services, Configuration);

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            Cors.AppUseCors(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Swagger.AddAppSwagger(app);
        }
    }
}
