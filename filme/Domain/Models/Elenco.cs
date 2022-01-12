using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Elenco
    {
        public int ElencoId { get; set; }
        public int PessoaId { get; set; }
        public int? FilmeId { get; set; }
        public int? SerieId { get; set; }

        public virtual Filmes? Filme { get; set; }
        public virtual Pessoa Pessoa { get; set; } = null!;
        public virtual Series? Serie { get; set; }
    }
}
