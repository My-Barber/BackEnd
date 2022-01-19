using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mybarber.Presenter;
using Mybarber.Presenters;
using Mybarber.Presenters.Interfaces;
using Mybarber.Repositories;
using Mybarber.Repository;
using Mybarber.Services;

namespace Mybarber.Config
{
    public static class Scopeds
    {
        public static void GetScoped(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

            services.AddScoped<IBarbeiroImagemServices, BarbeiroImagemServices>();

            services.AddScoped<IBarbeiroImagemPresenter, BarbeiroImagemPresenter>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IAgendasServices, AgendasServices>();
            services.AddScoped<IAgendasPresenter, AgendasPresenter>();


        }
    }
}
