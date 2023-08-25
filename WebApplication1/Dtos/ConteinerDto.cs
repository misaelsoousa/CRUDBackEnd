using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public class ConteinerDto
    {
        public int Id { get; set; }

        public int? Cliente { get; set; }

        public string? NomeCliente { get; set; }

        public string? Numero { get; set; }

        public string? Tipo { get; set; }

        public string? Status { get; set; }

        public string? Categoria { get; set; }  
    }
}
