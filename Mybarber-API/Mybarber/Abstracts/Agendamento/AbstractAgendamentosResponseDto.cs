using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Servico;
using Mybarber.Models;
using System;

namespace Mybarber.Abstracts.Agendamento
{
    public class AbstractAgendamentosResponseDto
    {
        public int IdAgendamento { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public DateTime Horario { get; set; }
        public virtual ServicosForAgendamentos Servicos { get; set; }
        public virtual BarbeirosResponseDto Barbeiros { get; set; }
    


    }
}
