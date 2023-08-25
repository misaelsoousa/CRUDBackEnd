using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Movimento
    {
        public int Id { get; set; }

        [ForeignKey("Conteiner")]
        public int? Conteiner { get; set; }

        public string? Tipo { get; set; }

        public string? DataIni { get; set; }

        public string? DataFim { get; set; }

    }
}
