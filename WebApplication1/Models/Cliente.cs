using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }    
        public string? CNPJ { get; set; }   
        public string? CEP { get; set; }
        public string? Contato { get; set; }
    }
}
