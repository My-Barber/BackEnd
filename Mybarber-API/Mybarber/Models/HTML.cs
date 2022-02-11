using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class HTML
    {
        [Key]
        public int IdHTML { get; set; }

        public string HTMLContent { get; set; }    
    }
}
