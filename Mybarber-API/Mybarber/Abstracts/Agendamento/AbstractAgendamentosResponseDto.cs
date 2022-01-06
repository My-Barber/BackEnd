using Mybarber.Models;
using System;

namespace Mybarber.Abstracts.Agendamento
{
    public class AbstractAgendamentosResponseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public DateTime Horario { get; set; }
        public Servicos servicos { get; set; }
        public Barbeiros Barbeiros { get; set; }
        public Barbearias Barbearias { get; set; }



    }
}
