using Mybarber.Models;
using System;
using System.Collections.Generic;

namespace Mybarber.Abstracts.Servico
{
    public class AbstractServicosRequestDto
    {
        public string NomeServico { get; set; }
        public DateTime TempoServico { get; set; }
        public float PrecoServico { get; set; }
        public int BarbeariasId { get; set; }

        public int ServicoImagemId { get; set; }
    }
}
