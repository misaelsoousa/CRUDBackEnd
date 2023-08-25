using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Dtos
{
    public class MovimentoDto
    {
        public int Id { get; set; }

        [ForeignKey("Conteiner")]
        public int? Conteiner { get; set; }

        public string? Numero { get; set; }

        public string? Tipo { get; set; }

        public string? DataIni { get; set; }

        public string? DataFim { get; set; }
    }
}
