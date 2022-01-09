using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mybarber.Helpers;
using Mybarber.Persistencia;
using Mybarber.Presenter;
using Mybarber.Presenters;
using Mybarber.Repositories;
using Mybarber.Repository;
using Mybarber.Services;
using System;

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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<Context>(options =>{options.UseNpgsql(Configuration.GetConnectionString("ConnectionDatabase"));});

            services.AddCors();

            services.AddScoped<IBarbeariasRepository, BarbeariasRepository>();

            services.AddScoped<IBarbeirosRepository, BarbeirosRepository>();

            services.AddScoped<IAgendamentosRepository, AgendamentosRepository>();

            services.AddScoped<IServicosRepository, ServicosRepository>();

            services.AddScoped<IServicosServices, ServicosServices>();

            services.AddScoped<IBarbeariasServices, BarbeariasServices>();

            services.AddScoped<IBarbeirosServices, BarbeirosServices>();

            services.AddScoped<IAgendamentosServices, AgendamentosServices>();

            services.AddScoped<IAgendamentosPresenter, AgendamentosPresenter>();

            services.AddScoped<IBarbeariasPresenter, BarbeariasPresenter>();

            services.AddScoped<IServicosPresenter, ServicosPresenter>();

            services.AddScoped<IBarbeirosPresenter, BarbeirosPresenter>();

            services.AddScoped<IGenerallyRepository, GenerallyRepository>();
            services.AddScoped<IRelacionamentosPresenter, RelacionamentosPresenter>();

            services.AddScoped<IServicoImagemServices, ServicoImagemServices>();

            services.AddScoped<IServicoImagemPresenter, ServicoImagemPresenter>();



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

            app.UseCors(option => option.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()

           );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
