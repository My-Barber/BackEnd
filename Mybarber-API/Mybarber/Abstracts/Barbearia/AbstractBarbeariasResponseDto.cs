using Mybarber.Abstracts.Barbeiro;
using Mybarber.Abstracts.Servico;
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
        public ICollection<ServicosResponseDto> Servicos { get; set; }

        public ICollection<BarbeirosResponseDto> Barbeiros { get; set; }
        public virtual ICollection<ServicosBarbeirosResponseDto> ServicosBarbeiros { get; set; }




    }
}
