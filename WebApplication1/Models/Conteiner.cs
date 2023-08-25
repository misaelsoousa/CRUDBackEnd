using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Conteiner
    {
        [Key]
        public int Id { get; set; }

        public int? Cliente { get; set; }

        public string? Numero { get; set; }

        public string? Tipo {  get; set; }

        public string? Status {  get; set; }

        public string? Categoria {  get; set; }
    }
}
