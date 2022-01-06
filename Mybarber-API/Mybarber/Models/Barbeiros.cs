using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mybarber.Models
{
    public class Barbeiros
    {

        [Key()]
        public int IdBarbeiro { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado")]
        public string NameBarbeiro { get; set; }
       
        public virtual ICollection<ServicosBarbeiros> ServicosBarbeiros { get; set; }


        [ForeignKey("Barbearias")]
        public int BarbeariasForeignKey { get; set; }
        public virtual Barbearias Barbearias { get; set; }

        

        public Barbeiros()
        {

            ServicosBarbeiros = new HashSet<ServicosBarbeiros>();
        }
        




    }
}
