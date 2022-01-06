using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class BarbeiroImagem
    {
        [Key()]
        public int IdBarbeiroImagem { get; set; }
        public string ContentType { get; set; }
        public byte Dados { get; set; }








    }
}
