using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public partial class Filmes
    {
        public Filmes()
        {
            Elencos = new HashSet<Elenco>();
            Infos = new HashSet<Info>();
            Ratings = new HashSet<Rating>();
        }
        [Key]
        public int FilmeId { get; set; }
        public int? ProdutoraId { get; set; }
        public string Nome { get; set; } = null!;
        public string? Genero { get; set; }
        public string? Resumo { get; set; }
        public DateOnly? AnoLancamento { get; set; }
        public string? Nacionalidade { get; set; }

        public virtual Produtora? Produtora { get; set; }
        public virtual ICollection<Elenco> Elencos { get; set; }
        public virtual ICollection<Info> Infos { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
