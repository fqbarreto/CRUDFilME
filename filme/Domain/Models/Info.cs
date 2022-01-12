using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Info
    {
        public int InfoId { get; set; }
        public int FilmeId { get; set; }
        public int SerieId { get; set; }
        public int ListaId { get; set; }

        public virtual Filmes Filme { get; set; } = null!;
        public virtual Listum Lista { get; set; } = null!;
        public virtual Series Serie { get; set; } = null!;
    }
}
