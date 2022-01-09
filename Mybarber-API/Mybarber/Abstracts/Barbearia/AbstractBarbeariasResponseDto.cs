using Mybarber.Abstracts.Barbeiro;
using Mybarber.Abstracts.Servico;
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.DataTransferObject.Servico;
using Mybarber.Models;
using System.Collections.Generic;

namespace Mybarber.Abstracts
{
    public class AbstractBarbeariasResponseDto
    {
        public int IdBarbearia { get; set; }
        public string NomeBarbearia { get; set; }
        public virtual ICollection<ServicosResponseDto> Servicos { get; set; }

        public virtual ICollection<BarbeirosResponseDto> Barbeiros { get; set; }

        public virtual ICollection<AgendamentosResponseDto> Agendamentos { get; set; }
     




    }
}
