using Mybarber.Helpers;
using Mybarber.Models;
using Mybarber.Repositories.Interface;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IServicosServices _repoServico;
        private readonly IBarbeirosServices _repoBarbeiro;
        //private readonly IHTMLRepository _repoHTML;
        public EmailServices(IServicosServices repoServico, IBarbeirosServices repoBarbeiro) { 
            this._repoBarbeiro = repoBarbeiro;
            this._repoServico = repoServico;

        }

        public async Task<Servicos> GetServicoForEmail(int idServico)
        {
            var Servico = await  _repoServico.GetServicoAsyncById(idServico);

            return Servico;


        }

        public async Task<Barbeiros> GetBarbeiroForEmail(int idBarbeiro)
        {
            var Barbeiro = await _repoBarbeiro.GetBarbeiroAsyncById(idBarbeiro);

            return Barbeiro;
        }

       

        public void SendEmail(Agendamentos agendamentos, string tipoHtml)
        {
            try { 
            var nomeBarbeiro = GetBarbeiroForEmail(agendamentos.BarbeirosId).Result.NameBarbeiro;

            var nomeServico =  GetServicoForEmail(agendamentos.ServicosId).Result.NomeServico;

            var nomeBarbearia = GetBarbeiroForEmail(agendamentos.BarbeirosId).Result.Barbearias.NomeBarbearia;

               


                
            Email.Send(agendamentos.Email, Email.CreateBody(agendamentos.Name, nomeServico, nomeBarbeiro, agendamentos.Horario,nomeBarbearia, tipoHtml), Email.CreateSubtitle(tipoHtml));
        }catch(Exception ex)
            { throw new Exception(ex.Message); }
        
        
        
        }

    }
}
