using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Produtora
    {
        public Produtora()
        {
            Filmes = new HashSet<Filmes>();
            Series = new HashSet<Series>();
        }

        public int ProdutoraId { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Filmes> Filmes { get; set; }
        public virtual ICollection<Series> Series { get; set; }
    }
}
