﻿using System;

namespace Mybarber.Abstracts.Agendamento
{
    public class AbstractAgendamentosRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public DateTime Horario { get; set; }
        public int ServicosId { get; set; }
        public int BarbeirosId { get; set; }
        public int BarbeariaId { get; set; }
    }
}