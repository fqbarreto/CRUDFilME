using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Elencos = new HashSet<Elenco>();
        }

        public int PessoaId { get; set; }
        public string Nome { get; set; } = null!;
        public int? Idade { get; set; }
        public string? Nacionalidade { get; set; }
        public string Funcao { get; set; } = null!;

        public virtual ICollection<Elenco> Elencos { get; set; }
    }
}
