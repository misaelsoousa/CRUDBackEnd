namespace WebApplication1.Models
{
    public class Relatorio
    {
        public string? NomeCliente { get; set; }
        public int? Embarque { get; set; } = 0;
        public int? Descarga { get; set; } = 0;
        public int? Gatein { get; set; } = 0;
        public int? Gateout { get; set; } = 0;
        public int? Reposicionamento { get; set; } = 0;
        public int? Pesagem { get; set; } = 0;
        public int? Scanner { get; set; } = 0;
        public int? Importacao { get; set; } = 0;
        public int? Exportacao { get; set; } = 0;
    }
}
