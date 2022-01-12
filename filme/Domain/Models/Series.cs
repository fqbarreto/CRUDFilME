using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Series
    {
        public Series()
        {
            Elencos = new HashSet<Elenco>();
            Infos = new HashSet<Info>();
            Ratings = new HashSet<Rating>();
        }

        public int SerieId { get; set; }
        public int? ProdutoraId { get; set; }
        public string Nome { get; set; } = null!;
        public string? Genero { get; set; }
        public string? Resumo { get; set; }
        public DateOnly? AnoLancamento { get; set; }
        public DateOnly? AnoFinal { get; set; }
        public string? Nacionalicade { get; set; }
        public int? NumeroSeasons { get; set; }
        public int? NumeroEpisodios { get; set; }

        public virtual Produtora? Produtora { get; set; }
        public virtual ICollection<Elenco> Elencos { get; set; }
        public virtual ICollection<Info> Infos { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
