namespace WebApi.Models
{
    public class FilmesInputModel
    {
        public int FilmeId { get; set; }
        public int? ProdutoraId { get; set; }
        public string Nome { get; set; } = null!;
        public string? Genero { get; set; }
        public string? Resumo { get; set; }
        public DateOnly? AnoLancamento { get; set; }
        public string? Nacionalidade { get; set; }
    }
}
