using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Listum
    {
        public Listum()
        {
            Infos = new HashSet<Info>();
        }

        public int ListaId { get; set; }
        public int UserId { get; set; }
        public string Nome { get; set; } = null!;
        public DateOnly DataCriacao { get; set; }

        public virtual Usuario User { get; set; } = null!;
        public virtual ICollection<Info> Infos { get; set; }
    }
}
